using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 兑换回复评论表业务接口
    /// </summary>
    public interface IExchangeReplyService:IBaseService<ExchangeReply>
    {
        /// <summary>
        /// 分页查询评论
        /// </summary>
        /// <param name="exId">兑换Id</param>
        /// <param name="userId">登录用户id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据数</param>
        /// <returns></returns>
        Task<(PageDto pageDto, List<ExchangeReplyDto> dtoList)> FindListAsync(int exId, int userId, int pageIndex, int pageSize);
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> AddAsync(ExchangeReplyDto dto);
        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="id">评论id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<bool> LikeAsync(int id, int userId);
    }
}