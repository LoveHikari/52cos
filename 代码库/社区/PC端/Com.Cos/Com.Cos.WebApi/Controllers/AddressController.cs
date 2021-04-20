using System;
using Com.Cos.Application;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Cos.WebApi.Models.AddressViewModels;
using Com.Cos.WebApi.ResultModels;
using Com.Cos.WebApi.ResultModels.AddressResultModels;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 通讯地址控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Addresses")]
    [DisableCors]  //禁止跨域
    public class AddressController : Controller
    {
        private readonly IMailingAddressService _mailingAddressService;

        public AddressController(IMailingAddressService mailingAddressService)
        {
            _mailingAddressService = mailingAddressService;
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST /api/Addresses
        [AcceptVerbs("POST"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Post([FromBody]AddressViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            var dto = ConvertHelper.ChangeType<AddressDto>(model);
            int id = await _mailingAddressService.AddAsync(dto);
            result.Data = id;
            return result;
        }
        /// <summary>
        /// 根据用户id获得对应的通讯地址列表
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        // GET /api/Addresses?userId=30
        [AcceptVerbs("GET"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get(int userId)
        {
            MessageBase2 result = new MessageBase2();

            var addressList = new List<AddressResultModel>();
            var dto = await _mailingAddressService.FindListAsync(userId.ToString());
            dto.ForEach(d=>{addressList.Add(ConvertHelper.ChangeType<AddressResultModel>(d));});
            result.Data = addressList;

            return result;
        }

        /// <summary>
        /// 更新用户的通讯地址
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT /api/Addresses/21
        [HttpPut("{id}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Put(int id, [FromBody]AddressViewModel model)
        {
            MessageBase2 result = new MessageBase2();
            var dto = ConvertHelper.ChangeType<AddressDto>(model);
            await _mailingAddressService.UpdateAsync(id, dto);

            return result;
        }
        /// <summary>
        /// 设置默认通讯地址
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // PUT /api/Addresses/Default/1
        [HttpPut, Route("Default/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PutDefault(int id)
        {
            MessageBase2 result = new MessageBase2();
            await _mailingAddressService.SetDefaultAsync(id);

            return result;

        }
        /// <summary>
        /// 删除通讯地址
        /// </summary>
        /// <param name="id">通讯地址id</param>
        /// <returns></returns>
        // DELETE /api/Addresses/21
        [HttpDelete("{id}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Delete(int id)
        {
            MessageBase2 result = new MessageBase2();
            await _mailingAddressService.DeleteAsync(id);

            return result;
        }
    }
}