using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Repository.Interfaces;
using Com.Cos.Application.DTO;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Interfaces;
using Com.Cos.Repository;
using Microsoft.EntityFrameworkCore;

namespace Com.Cos.Application
{
    public class MailingAddressService : BaseService<MailingAddress>, IMailingAddressService
    {

        public MailingAddressService(CosDbContext dbContext) : base(dbContext)
        {
        }
        /// <summary>
        /// 获得用户的通讯地址列表
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public async Task<List<AddressDto>> FindListAsync(string userId)
        {
            var list = await this.MailingAddressRepository.FindList(p => p.UserId == userId).ToListAsync();
            List<AddressDto> addList = new List<AddressDto>();
            foreach (MailingAddress address in list)
            {
                addList.Add(new AddressDto()
                {
                    Id = address.Id,
                    UserId = address.UserId.ToInt32(),
                    Province = address.Province,
                    City = address.City,
                    County = address.County,
                    Address = address.Address,
                    ZipCode = address.ZipCode,
                    Name = address.Name,
                    Phone = address.Phone,
                    IsDefault = address.IsDefault.GetValueOrDefault(false)
                });
            }
            return addList;
        }
        /// <summary>
        /// 添加通讯地址
        /// </summary>
        /// <param name="model">通讯地址传输对象</param>
        /// <returns>添加后的id</returns>
        public async Task<int> AddAsync(AddressDto model)
        {
            MailingAddress address = new MailingAddress()
            {
                UserId = model.UserId.ToString(),
                Province = model.Province,
                City = model.City,
                County = model.County,
                Address = model.Address,
                Name = model.Name,
                Phone = model.Phone,
                ZipCode = model.ZipCode,
                AddTime = DateTime.Now,
                Status = 1
            };
            address = await this.MailingAddressRepository.AddAsync(address);
            return address.Id;
        }

        /// <summary>
        /// 更新用户通讯地址
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model">通讯地址传输对象</param>
        /// <returns>是否更新成功</returns>
        public async Task<bool> UpdateAsync(int id, AddressDto model)
        {
            MailingAddress address = await this.MailingAddressRepository.FindAsync(p => p.Id == id);

            address.UserId = model.UserId.ToString();
            address.Province = model.Province;
            address.City = model.City;
            address.County = model.County;
            address.Address = model.Address;
            address.Name = model.Name;
            address.Phone = model.Phone;
            address.ZipCode = model.ZipCode;

            return await this.MailingAddressRepository.UpdateAsync(address);
        }
        /// <summary>
        /// 删除通讯地址
        /// </summary>
        /// <param name="id">通讯地址id</param>
        /// <returns>是否删除成功</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var model = await this.MailingAddressRepository.FindAsync(p => p.Id == id);
            return await this.MailingAddressRepository.DeleteAsync(model);
        }
        /// <summary>
        /// 设置默认地址
        /// </summary>
        /// <param name="id">地址id</param>
        /// <returns></returns>
        public async Task<bool> SetDefaultAsync(int id)
        {
            var model = await this.MailingAddressRepository.FindAsync(m => m.Id == id);
            int userId = model.UserId.ToInt32();
            var modelList = await this.MailingAddressRepository.FindList(m => m.UserId == userId.ToString()).ToListAsync();
            bool b = false;
            using (var tran = await this.DbContext.Database.BeginTransactionAsync())
            {

                    foreach (MailingAddress address in modelList)
                    {
                        if (address.Id == id)
                        {
                            address.IsDefault = true;
                        }
                        else
                        {
                            address.IsDefault = false;
                        }
                        b = this.MailingAddressRepository.Update(address);
                    }
                    tran.Commit();
                
            }
            
            return b;
        }
        /// <summary>
        /// 获得默认地址
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public async Task<AddressDto> GetDefaultAsync(int userId)
        {
            var model = await this.MailingAddressRepository.FindAsync(ma=>ma.UserId==userId.ToString() && ma.IsDefault.GetValueOrDefault(true));
            return ConvertHelper.ChangeType<AddressDto>(model);
        }
    }
}