using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// 兑换回复评论表业务
    /// </summary>
    public class ExchangeReplyService : BaseService<ExchangeReply>, IExchangeReplyService
    {
        public ExchangeReplyService(CosDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 分页查询评论
        /// </summary>
        /// <param name="exId">兑换Id</param>
        /// <param name="userId">登录用户id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据数</param>
        /// <returns></returns>
        public async Task<(PageDto pageDto, List<ExchangeReplyDto> dtoList)> FindListAsync(int exId, int userId, int pageIndex, int pageSize)
        {
            var isLike = new Func<string, string, bool>((s, b) => !string.IsNullOrWhiteSpace(s) && s.Split(",", StringSplitOptions.RemoveEmptyEntries)
                                                                      .Contains(b));
            /*SELECT m.Portrait,m.nickname,er.Text,er.AddTime,er.LikeNum,m2.nickname,er2.UserId FROM dbo.sns_exchangeReply er
                LEFT JOIN dbo.cos_member m ON m.User_id=er.UserId
                LEFT JOIN sns_exchangeReply er2 ON er2.Id=er.ParentId
                LEFT JOIN dbo.cos_member m2 ON m2.User_id=er2.UserId*/
            var v = from er in this.DbContext.ExchangeReplies
                    join m in this.DbContext.Members on er.UserId equals m.Id into mi
                    from m in mi.DefaultIfEmpty()
                    join er2 in this.DbContext.ExchangeReplies on er.ParentId equals er2.Id into er2i
                    from er2 in er2i.DefaultIfEmpty()
                    join m2 in this.DbContext.Members on er2.UserId equals m2.Id into m2i
                    from m2 in m2i.DefaultIfEmpty()
                    where er.ExId == exId
                    orderby er.AddTime descending
                    select new ExchangeReplyDto()
                    {
                        Id = er.Id,
                        ExId = er.ExId,
                        UserId = er.UserId,
                        Portrait = m.Portrait,
                        Nickname = m.Nickname,
                        Text = er.Text,
                        AddTime = SysHelper.GetDateInterval(er.AddTime.ToString(CultureInfo.InvariantCulture)),
                        LikeNum = er.LikeNum,
                        IsLike = isLike(er.LikeUser, userId.ToString()),
                        ReplyUserId = er2 == null ? 0 : er2.UserId,
                        ReplyNickname = m2.Nickname ?? ""
                    };

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
                PageSize = pageSize,
                PageIndex = pageIndex
            };
            var erList =await v.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();



            return (pageDto, erList);
        }
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(ExchangeReplyDto dto)
        {
            var model = new ExchangeReply()
            {
                ExId = dto.ExId,
                UserId = dto.UserId,
                Text = dto.Text,
                ParentId = dto.ParentId,
                LikeNum = 0,
                LikeUser = "",
                AddTime = DateTime.Now,
                Status = 1
            };
            model = await this.ExchangeReplyRepository.AddAsync(model);
            return model.Id > 0;
        }
        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="id">评论id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public async Task<bool> LikeAsync(int id, int userId)
        {
            var model = await this.ExchangeReplyRepository.FindAsync(er => er.Id == id);
            if (!model.LikeUser.Split(',', StringSplitOptions.RemoveEmptyEntries).Contains(userId.ToString()))  //没有点赞，则点赞
            {
                model.LikeNum++;
                model.LikeUser += userId + ",";
            }
            return await this.ExchangeReplyRepository.UpdateAsync(model);
        }
    }
}