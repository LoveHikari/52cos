using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using Com.Cos.Repository;
using Microsoft.EntityFrameworkCore;

namespace Com.Cos.Application
{
    /// <summary>
    ///  分享表业务
    /// </summary>
    public class ExchangeService : BaseService<Exchange>, IExchangeService
    {

        private readonly IIntegralChangeService _integralChangeService;
        public ExchangeService(CosDbContext dbContext) : base(dbContext)
        {
            _integralChangeService = new IntegralChangeService(dbContext);
        }

        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="sea">搜索标题</param>
        /// <param name="classId">分类id</param>
        /// <param name="examineId">状态id</param>
        /// <param name="userId">发布的会员id</param>
        /// <param name="rec">是否推荐</param>
        /// <returns></returns>
        public async Task<(PageDto pageDto, List<ExchangeDto> dto)> FindListAsync(int pageIndex, int pageSize, string sea="", int classId=0, int examineId=0, int userId = 0, bool rec = false)
        {
            var v = from e in this.DbContext.Exchanges
                    join m in this.DbContext.Members on e.UserId equals m.Id.ToString() into mi
                    from m in mi.DefaultIfEmpty()
                    join i in this.DbContext.Imgs on e.Cover equals i.Id.ToString() into ii
                    from i in ii.DefaultIfEmpty()
                    join ee in this.DbContext.ExchangeExamines on e.Examine equals ee.ExamineId into eei
                    from ee in eei.DefaultIfEmpty()
                    where e.Status > 0
                    orderby e.AddTime descending
                    select new ExchangeDto()
                    {
                        Id = e.Id,
                        Title = e.Title,
                        Official = e.Official,
                        Status = e.Status,
                        AddTime = e.AddTime,
                        Nickname = m == null ? "" : m.Nickname,
                        Cover = i.ImgSmallUrl,
                        ClassId = e.ClassId.ToInt32(0),
                        ExamineId = e.Examine.ToInt32(0),
                        ExamineName = string.IsNullOrWhiteSpace(ee.ExamineName) ? "审核中" : ee.ExamineName,
                        UserId = m == null ? 0 : m.Id,
                        LogisticCode = e.LogisticCode,
                        Portrait = m.Portrait
                    };

            if (!string.IsNullOrWhiteSpace(sea))
            {
                v = v.Where(p => p.Title.Contains(sea));
            }
            if (classId != 0)
            {
                v = v.Where(p => p.ClassId == classId);
            }
            if (examineId != 0)
            {
                v = v.Where(p => p.ExamineId == examineId);
            }
            if (userId != 0)
            {
                v = v.Where(p => p.UserId == userId);
            }
            if (rec)
            {
                v = v.Where(p => p.Status == 2);
            }
            int totalRecord = await v.CountAsync();
            int pageCount = Convert.ToInt32(Math.Ceiling(totalRecord / Convert.ToDouble(pageSize)));
            int prevPage = pageIndex > 0 ? pageIndex - 1 : 0;
            int nextPage = pageIndex < pageCount ? pageIndex + 1 : 0;

            var exList =await v.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            var pageDto = new PageDto()
            {
                TotalRecord = totalRecord,
                PageCount = pageCount,
                NextPage = nextPage,
                PrevPage = prevPage,
                PageSize = pageSize,
                PageIndex = pageIndex
            };


            return (pageDto, exList);
        }
        /// <summary>
        /// 添加兑换
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(ExchangeDto dto)
        {
            var model = ConvertHelper.ChangeType<Exchange>(dto);
            model.AddTime = DateTime.Now;
            model.Status = 1;
            model.Examine = "1";
            model.Valuation1 = "";
            model.Valuation2 = "";
            model.Valuation3 = "";
            model.Vote1 = 0;
            model.Vote2 = 0;
            model.Vote3 = 0;
            model = await this.ExchangeRepository.AddAsync(model);
            return model.Id > 0;
        }
        /// <summary>
        /// 查询兑换详情
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="userId">查看的用户id</param>
        /// <returns></returns>
        public async Task<ExchangeDto> FindAsync(int id, int userId)
        {
            /*SELECT ex.id,m.nickname,m.Portrait,m.Describe,ex.Title,ee.ExamineName,ec.ClassName,ex.Official,ex.Describe,ex.ImgList,sp.RefText size FROM dbo.sns_exchange ex
            LEFT JOIN dbo.cos_member m ON ex.UserId = m.User_id
            LEFT JOIN dbo.sns_exchangeExamine ee ON ee.ExamineId = ex.Examine
            LEFT JOIN dbo.sns_exchangeClass ec ON ec.ClassId = ex.ClassId
			LEFT JOIN dbo.cos_sysPara sp ON ex.size=sp.RefValue AND sp.RefType='size'
            WHERE ex.Id = 2*/
            var v = from ex in DbContext.Exchanges
                    join m in DbContext.Members on ex.UserId equals m.Id.ToString() into mi
                    from m in mi.DefaultIfEmpty()
                    join ee in DbContext.ExchangeExamines on ex.Examine equals ee.ExamineId into eei
                    from ee in eei.DefaultIfEmpty()
                    join ec in DbContext.ExchangeClasses on ex.ClassId equals ec.ClassId.ToString() into eci
                    from ec in eci.DefaultIfEmpty()
                    join sp in this.DbContext.SysParas on new { Size = ex.Size, RefType = "size" } equals new { Size = sp.RefValue, RefType = sp.RefType } into spi
                    from sp in spi.DefaultIfEmpty()
                    where ex.Id == id
                    select new ExchangeDto()
                    {
                        Id = ex.Id,
                        UserId = ex.UserId.ToInt32(0),
                        Nickname = m.Nickname,
                        Portrait = m.Portrait,
                        Desc = m.Describe,
                        Title = ex.Title,
                        ExamineName = ee.ExamineName,
                        ClassName = ec.ClassName,
                        Official = ex.Price,
                        Describe = ex.Describe,
                        ImgList = ex.ImgList,
                        LikeUser = ex.LikeUser,
                        AddTime = ex.AddTime,
                        Constitute = ex.Constitute,
                        Source = ex.Source,
                        Price = ex.Price,
                        Cover = ex.Cover,
                        Size = sp.RefText
                    };
            var dto = await v.FirstOrDefaultAsync();
            //获得封面
            dto.Cover = (await this.ImgRepository.FindAsync(img => img.Id == dto.Cover.ToInt32(0)))?.ImgSmallUrl ?? "";
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
            var erList = this.ExchangeReplyRepository.FindList(er => er.ExId == id);
            dto.CommentNum = await erList.CountAsync();
            //判断是否关注
            dto.Heed = dto.LikeUser?.Split(',', StringSplitOptions.RemoveEmptyEntries).Contains(userId.ToString()) ?? false;
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
            var model = await this.ExchangeRepository.FindAsync(e => e.Id == id);
            if (model.LikeUser != null && model.LikeUser.Split(",", StringSplitOptions.RemoveEmptyEntries).Contains(userId.ToString()))  //如果已经关注，则取消关注
            {
                model.LikeUser = model.LikeUser.Replace(userId + ",", "");
            }
            else  //否则关注
            {
                model.LikeUser += userId + ",";
            }

            return await this.ExchangeRepository.UpdateAsync(model);
        }
        /// <summary>
        /// 查询兑换
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <returns></returns>
        public async Task<ExchangeDto> FindAsync(int id)
        {
            var v = await this.ExchangeRepository.FindAsync(ex => ex.Id == id);
            ExchangeDto dto = new ExchangeDto()
            {
                Title = v.Title,
                Official = v.Official,
                Postage = v.Postage.GetValueOrDefault(0),
                Rent = v.Rent.GetValueOrDefault(0)
            };
            return dto;
        }
        /// <summary>
        /// 用户是否已经存在租赁
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public async Task<bool> ExistAsync(int userId)
        {
            return await this.ExchangeRepository.ExistAsync(ex => ex.ExchangePerson == userId.ToString() && ex.Examine == "4");
        }
        /// <summary>
        /// 删除兑换（假删）
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var model = await this.ExchangeRepository.FindAsync(ex => ex.Id == id);
            model.Status = 0;
            return await this.ExchangeRepository.UpdateAsync(model);
        }
        /// <summary>
        /// 修改兑换
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(int id, ExchangeDto dto)
        {
            var model = await this.ExchangeRepository.FindAsync(ex => ex.Id == id);

            model.ClassId = dto.ClassId.ToString();
            model.Constitute = dto.Constitute;
            model.Cover = dto.Cover;
            model.Describe = dto.Describe;
            model.ImgList = dto.ImgList;
            model.ItemCharacter = dto.ItemCharacter;
            model.ItemName = dto.ItemName;
            model.Price = dto.Price;
            model.Source = dto.Source;
            model.Title = dto.Title;

            return await this.ExchangeRepository.UpdateAsync(model);
        }
        /// <summary>
        /// 修改审核标志
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="type">修改类型</param>
        /// <returns></returns>
        public async Task<bool> UpdateExamineAsync(int id, string type)
        {
            var model = await this.ExchangeRepository.FindAsync(ex => ex.Id == id);
            if (type == "同意")
            {
                model.Examine = "2";
            }
            if (type == "拒绝")
            {
                model.Examine = "10";
            }
            return await this.ExchangeRepository.UpdateAsync(model);
        }
        /// <summary>
        /// 修改物流单号
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="code">物流单号</param>
        /// <returns></returns>
        public async Task<bool> UpdateLogisticCodeAsync(int id, string code)
        {
            var model = await this.ExchangeRepository.FindAsync(ex => ex.Id == id);
            model.LogisticCode = code;
            return this.ExchangeRepository.Update(model);
        }

        #region 后台
        /// <summary>
        /// 查询所有兑换
        /// </summary>
        /// <returns></returns>
        public List<ExchangeDto> FindList()
        {
            var v = from e in this.DbContext.Exchanges
                    join m in this.DbContext.Members on e.UserId equals m.Id.ToString() into mi
                    from m in mi.DefaultIfEmpty()
                    join i in this.DbContext.Imgs on e.Cover equals i.Id.ToString() into ii
                    from i in ii.DefaultIfEmpty()
                    join ee in this.DbContext.ExchangeExamines on e.Examine equals ee.ExamineId into eei
                    from ee in eei.DefaultIfEmpty()
                    orderby e.AddTime descending
                    select new ExchangeDto()
                    {
                        Id = e.Id,
                        Title = e.Title,
                        Official = e.Official,
                        Status = e.Status,
                        AddTime = e.AddTime,
                        Nickname = m == null ? "" : m.Nickname,
                        Cover = i.ImgSmallUrl,
                        ClassId = e.ClassId.ToInt32(0),
                        ExamineId = e.Examine.ToInt32(0),
                        ExamineName = string.IsNullOrWhiteSpace(ee.ExamineName) ? "审核中" : ee.ExamineName,
                        UserId = m == null ? 0 : m.Id,
                        LogisticCode = e.LogisticCode,
                        Price = e.Price

                    };

            return v.ToList();
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="examine">修改标识</param>
        /// <param name="official">最终值</param>
        /// <returns></returns>
        public bool UpdateExamine(int id, string examine, string official)
        {
            var model = this.ExchangeRepository.Find(ex => ex.Id == id);
            switch (examine)
            {
                case "1":   //审核
                    model.Official = official;  //设置最终值
                    model.Examine = "5";  //设置为审核完成
                    //通知用户
                    RongCloudHelper.PublishSystemBySystem(model.UserId, "您的兑换已审核完成，请查看");
                    break;
                case "2":  //确认回收
                    model.Examine = "3";  //将状态改为可兑换
                    _integralChangeService.AddExchange(model.UserId.ToInt32(), model.Official);
                    //通知用户
                    RongCloudHelper.PublishSystemBySystem(model.UserId, "您的兑换已被确认回收，请查看");
                    break;
                case "3":  //上架
                    model.Examine = "3";  //将状态改为可兑换
                    break;
                case "4":  //下架
                    model.Examine = "10";  //将状态改为已结束
                    //通知用户
                    RongCloudHelper.PublishSystemBySystem(model.UserId, $"您的兑换已下架，下架原因：{official}，请查看");
                    break;
            }

            return this.ExchangeRepository.Update(model);
        }
        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="id">兑换id</param>
        public async Task ClickAsync(int id)
        {
            var model = await this.ExchangeRepository.FindAsync(ex => ex.Id == id);
            model.Clicks = model.Clicks.GetValueOrDefault() + 1;
            this.ExchangeRepository.Update(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete2(int id)
        {
            var model = this.ExchangeRepository.Find(ex => ex.Id == id);
            this.ExchangeRepository.Delete(model);
        }
        /// <summary>
        /// 推荐
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="status"></param>
        public void Recommend(int id, int status)
        {
            var model = this.ExchangeRepository.Find(ex => ex.Id == id);
            if (status == 1)
            {
                model.Status = 2;
            }
            if (status == 2)
            {
                model.Status = 1;
            }
            this.ExchangeRepository.Update(model);
        }

        public bool Update2(int id, ExchangeDto dto)
        {
            var model = this.ExchangeRepository.Find(ex => ex.Id == id);
            model.Title = dto.Title;
            model.Constitute = dto.Constitute;
            model.Source = dto.Source;
            model.ClassId = dto.ClassId.ToString();
            model.Examine = dto.ExamineId.ToString();
            model.Describe = dto.Describe;
            model.Price = dto.Price;
            model.ItemCharacter = dto.ItemCharacter;
            model.ItemName = dto.ItemName;
            model.Official = dto.Official;

            return this.ExchangeRepository.Update(model);
        }

        #endregion

    }
}