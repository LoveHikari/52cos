using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 合作表业务接口
    /// </summary>
    public interface ICooperationService : IBaseService<Cooperation>
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> AddAsync(CooperationDto dto);
        /// <summary>
        /// 分页取出数据
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数量</param>
        /// <param name="userId">发布的会员id</param>
        /// <param name="cid">分类id</param>
        /// <param name="city">市</param>
        /// <returns></returns>
        Task<(PageDto pageDto, List<CooperationDto> dtoList)> FindListAsync(int pageIndex, int pageSize, int userId = 0, int cid = 0, string city = "");
        /// <summary>
        /// 合作详情
        /// </summary>
        /// <param name="id">合作id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<CooperationDto> FindAsync(int id, int userId);

        /// <summary>
        /// 关注兑换
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<bool> LikeAsync(int id, int userId);

        /// <summary>
        /// 删除合作（假删）
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 修改兑换
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(int id, CooperationDto dto);
        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="id">兑换id</param>
        Task ClickAsync(int id);
    }
}