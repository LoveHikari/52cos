using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    /// <summary>
    /// 兑换码表业务接口
    /// </summary>
    public interface IVoucherService:IBaseService<Voucher>
    {
        /// <summary>
        /// 兑换
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="code">兑换码</param>
        Task ExchangeAsync(int userId, string code);
        /// <summary>
        /// 是否存在可用的
        /// </summary>
        /// <param name="code">兑换码</param>
        /// <returns></returns>
        Task<bool> ExistAsync(string code);

        /// <summary>
        /// 是否存在可用的
        /// </summary>
        /// <param name="code">兑换码</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<bool> ExistAsync(int voucherId, int userId);
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据数</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<(PageDto pageDto, List<VoucherDto> dto)> FindListAsync(int pageIndex, int pageSize, int userId);

        //void Add();
    }
}