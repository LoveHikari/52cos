using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 分享表业务接口
    /// </summary>
    public interface IExchangeService : IBaseService<Exchange>
    {
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
        Task<(PageDto pageDto, List<ExchangeDto> dto)> FindListAsync(int pageIndex, int pageSize, string sea = "", int classId = 0, int examineId = 0, int userId = 0, bool rec = false);
        /// <summary>
        /// 添加兑换
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> AddAsync(ExchangeDto dto);
        /// <summary>
        /// 查询兑换详情
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="userId">查看的用户id</param>
        /// <returns></returns>
        Task<ExchangeDto> FindAsync(int id, int userId);
        /// <summary>
        /// 关注兑换
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<bool> LikeAsync(int id, int userId);
        /// <summary>
        /// 查询兑换
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <returns></returns>
        Task<ExchangeDto> FindAsync(int id);

        /// <summary>
        /// 用户是否已经存在租赁
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<bool> ExistAsync(int userId);
        /// <summary>
        /// 删除兑换（假删）
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
        Task<bool> UpdateAsync(int id, ExchangeDto dto);

        /// <summary>
        /// 修改审核标志
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="type">修改类型</param>
        /// <returns></returns>
        Task<bool> UpdateExamineAsync(int id, string type);

        /// <summary>
        /// 修改物流单号
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="code">物流单号</param>
        /// <returns></returns>
        Task<bool> UpdateLogisticCodeAsync(int id, string code);
        /// <summary>
        /// 查询所有兑换
        /// </summary>
        /// <returns></returns>
        List<ExchangeDto> FindList();

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="examine">修改标识</param>
        /// <param name="official">最终值</param>
        /// <returns></returns>
        bool UpdateExamine(int id, string examine, string official);

        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="id">兑换id</param>
        Task ClickAsync(int id);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">兑换id</param>
        void Delete2(int id);

        /// <summary>
        /// 推荐
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="status"></param>
        void Recommend(int id, int status);

        bool Update2(int id, ExchangeDto dto);
    }
}