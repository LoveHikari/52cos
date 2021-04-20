using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Com.Cos.Application
{
    /// <summary>
    /// 合作表业务
    /// </summary>
    public class CooperationService : BaseService<Cooperation>, ICooperationService
    {
        public CooperationService(CosDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(CooperationDto dto)
        {
            var model = ConvertHelper.ChangeType<Cooperation>(dto);
            model.ReleaseTime = DateTime.Now;
            model.Status = 1;
            model.Cont = dto.Describe;
            model = await this.CooperationRepository.AddAsync(model);
            return model.Id > 0;
        }

        /// <summary>
        /// 分页取出数据
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="userId">发布的会员id</param>
        /// <param name="cid">分类id</param>
        /// <param name="city">市</param>
        /// <returns></returns>
        public async Task<(PageDto pageDto, List<CooperationDto> dtoList)> FindListAsync(int pageIndex, int pageSize,int userId=0, int cid=0, string city="")
        {
            var getPersonNum = new Func<string,int>(s => s?.Split(',', StringSplitOptions.RemoveEmptyEntries).Length ?? 0);
            /*SELECT c.id,c.title,m.nickname,c.UserId,i.ImgBigUrl FROM dbo.sns_cooperation c
            LEFT JOIN dbo.cos_member m ON m.User_id=c.UserId
            LEFT JOIN dbo.sns_Img i ON i.Id=c.cover*/
            var v = from c in this.DbContext.Cooperations
                    join m in this.DbContext.Members on c.UserId equals m.Id.ToString() into mi
                    from m in mi.DefaultIfEmpty()
                    join i in this.DbContext.Imgs on c.Cover equals i.Id.ToString() into ii
                    from i in ii.DefaultIfEmpty()
                    where c.Status >0
                    orderby c.ReleaseTime descending
                    select new CooperationDto()
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Nickname = m.Nickname,
                        UserId = c.UserId.ToInt32(0),
                        Cover = i.ImgSmallUrl,
                        City = c.City,
                        PersonNum = getPersonNum(c.SignPerson),
                        AddTime = c.ReleaseTime.GetValueOrDefault(),
                        ClassId = c.ClassId.GetValueOrDefault(0),
                        Portrait = m.Portrait
                    };
            if (userId != 0)
            {
                v = v.Where(p => p.UserId == userId);
            }
            if (cid != 0)
            {
                v = v.Where(p => p.ClassId == cid);
            }
            if (!string.IsNullOrWhiteSpace(city))
            {
                v = v.Where(p => p.City.Contains(city));
            }
            int totalRecord = await v.CountAsync();
            int pageCount = Convert.ToInt32(Math.Ceiling(totalRecord / Convert.ToDouble(pageSize)));
            int prevPage = pageIndex > 0 ? pageIndex - 1 : 0;
            int nextPage = pageIndex < pageCount ? pageIndex + 1 : 0;

            var pageDto = new PageDto()
            {
                TotalRecord = totalRecord,
                PageCount = pageCount,
                NextPage = nextPage,
                PrevPage = prevPage,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var dto = await v.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return (pageDto, dto);
        }
        /// <summary>
        /// 合作详情
        /// </summary>
        /// <param name="id">合作id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public async Task<CooperationDto> FindAsync(int id, int userId)
        {
            var getPersonNum = new Func<string, int>(s => s?.Split(',', StringSplitOptions.RemoveEmptyEntries).Length ?? 0);
            /*SELECT c.title,c.enrollEnd,c.Will,c.Address,c.Cont,c.ImgList,m.Portrait,m.nickname,c.UserId,m.Describe FROM sns_cooperation c
            LEFT JOIN dbo.cos_member m ON m.User_id=c.UserId*/
            var v = from c in this.DbContext.Cooperations
                    join m in this.DbContext.Members on c.UserId equals m.Id.ToString() into mi
                    from m in mi.DefaultIfEmpty()
                    where c.Id == id
                    orderby c.ReleaseTime descending
                    select new CooperationDto
                    {
                        Id = c.Id,
                        Title = c.Title,
                        EnrollEnd = c.EnrollEnd.ToDateTime(),
                        Will = c.Will,
                        Address = c.Address,
                        Describe = c.Cont,
                        ImgList = c.ImgList,
                        Portrait = m.Portrait,
                        Nickname = m.Nickname,
                        UserId = c.UserId.ToInt32(0),
                        Desc = m.Describe,
                        SignPerson = c.SignPerson,
                        PersonNum = getPersonNum(c.SignPerson),
                        LimitPerson = c.LimitPerson
                    };

            var dto = await v.FirstOrDefaultAsync();
            //获得图片列表
            string[] imgs = dto.ImgList.Split(',', StringSplitOptions.RemoveEmptyEntries);
            List<ImgDto> imgDtoList = new List<ImgDto>();
            var imgList = await this.ImgRepository.FindList(i => imgs.Contains(i.Id.ToString())).ToListAsync();
            foreach (Img img in imgList)
            {
                imgDtoList.Add(new ImgDto()
                {
                    Width = img.BigSize.SplitLeft("X").ToInt32(),
                    Height = img.BigSize.SplitRight("X").ToInt32(),
                    ImgPath = img.ImgBigUrl
                });
            }
            dto.ImgDtoList = imgDtoList;
            //获得评论数
            var erList = this.CooperationReplyRepository.FindList(er => er.CoId == id);
            dto.CommentNum = await erList.CountAsync();
            //判断是否关注
            dto.Heed = dto.SignPerson?.Split(',', StringSplitOptions.RemoveEmptyEntries).Contains(userId.ToString()) ?? false;
            return dto;
        }
        /// <summary>
        /// 关注兑换
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public async Task<bool> LikeAsync(int id, int userId)
        {
            var model = await this.CooperationRepository.FindAsync(e => e.Id == id);
            if (model.SignPerson != null && model.SignPerson.Split(",", StringSplitOptions.RemoveEmptyEntries).Contains(userId.ToString()))  //如果已经关注，则取消关注
            {
                model.SignPerson = model.SignPerson.Replace(userId + ",", "");
            }
            else  //否则关注
            {
                if ((model.SignPerson?.Split(',',StringSplitOptions.RemoveEmptyEntries).Length??0)>=model.LimitPerson)  //如果达到报名上线，则不能报名
                {
                    
                }
                else
                {
                    model.SignPerson += userId + ",";
                }
                
            }

            return this.CooperationRepository.Update(model);
        }
        /// <summary>
        /// 删除合作（假删）
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var model = await this.CooperationRepository.FindAsync(ex => ex.Id == id);
            model.Status = 0;
            return await this.CooperationRepository.UpdateAsync(model);
        }
        /// <summary>
        /// 修改兑换
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(int id, CooperationDto dto)
        {
            var model = await this.CooperationRepository.FindAsync(ex => ex.Id == id);

            model.EnrollEnd = dto.EnrollEnd.ToString();
            model.Will = dto.Will;
            model.Cover = dto.Cover;
            model.Cont = dto.Describe;
            model.ImgList = dto.ImgList;
            model.Prov = dto.Prov;
            model.City = dto.City;
            model.Dist = dto.Dist;
            model.Address = dto.Address;
            model.Title = dto.Title;
            model.LimitPerson = dto.LimitPerson;
            model.ClassId = dto.ClassId;

            return await this.CooperationRepository.UpdateAsync(model);
        }
        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="id">兑换id</param>
        public async Task ClickAsync(int id)
        {
            var model = await this.CooperationRepository.FindAsync(ex => ex.Id == id);
            model.Clicks = model.Clicks.GetValueOrDefault() + 1;
            this.CooperationRepository.Update(model);
        }
    }
}