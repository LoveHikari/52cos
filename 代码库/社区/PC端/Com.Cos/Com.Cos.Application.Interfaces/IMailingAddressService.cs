using Com.Cos.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    public interface IMailingAddressService : IBaseService<MailingAddress>
    {
        /// <summary>
        /// 获得用户的通讯地址列表
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<List<AddressDto>> FindListAsync(string userId);
        /// <summary>
        /// 添加通讯地址
        /// </summary>
        /// <param name="model">通讯地址传输对象</param>
        /// <returns>添加后的id</returns>
        Task<int> AddAsync(AddressDto model);

        /// <summary>
        /// 更新用户通讯地址
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model">通讯地址传输对象</param>
        /// <returns>是否更新成功</returns>
        Task<bool> UpdateAsync(int id, AddressDto model);

        /// <summary>
        /// 删除通讯地址
        /// </summary>
        /// <param name="id">通讯地址id</param>
        /// <returns>是否删除成功</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 设置默认地址
        /// </summary>
        /// <param name="id">地址id</param>
        /// <returns></returns>
        Task<bool> SetDefaultAsync(int id);

        /// <summary>
        /// 获得默认地址
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<AddressDto> GetDefaultAsync(int userId);
    }
}