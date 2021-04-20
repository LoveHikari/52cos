using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Microsoft.Owin.BuilderProperties;
using Api.Models;

namespace Api.Controllers
{
    /// <summary>
    /// 收货地址
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class MailingAddressController : ApiController
    {
        /// <summary>
        /// 添加收货地址
        /// api/MailingAddress/Address
        /// </summary>
        /// <param name="mailingAddressEntity">在body中传递content-type为application/json {
        ///"_userid": "2",   会员id
        ///"_province": "3",  省
        ///"_city": "4",     市
        /// "_county": "5",  区/县
        ///"_address": "6",  详细地址
        ///"_zipcode": "7",  邮政编码
        ///"_name": "8",    姓名
        /// "_phone": "9"   手机号码
        ///}</param>
        /// <returns></returns>
        // POST api/MailingAddress/Address
        [AcceptVerbs("POST")]
        public object Address([FromBody]MailingAddressEntity mailingAddressEntity)
        {
            //MailingAddressEntity mailingAddressEntity = new MailingAddressEntity();
            //mailingAddressEntity.UserId = userId;
            //mailingAddressEntity.Province = province;
            //mailingAddressEntity.City = city;
            //mailingAddressEntity.County = county;
            //mailingAddressEntity.Address = address;
            //mailingAddressEntity.ZipCode = zipCode;
            //mailingAddressEntity.Name = name;
            //mailingAddressEntity.Phone = phone;
            mailingAddressEntity.AddTime = DateTime.Now;
            mailingAddressEntity.Status = 1;
            if (MailingAddressBll.Instance.Add(mailingAddressEntity) > 0)
            {
                return new Dictionary<string, string>() { { "status", "200" } };
            }
            else
            {
                return new Dictionary<string, string>() { { "status", "500" } };
            }
        }
        /// <summary>
        /// 修改收货地址
        /// api/MailingAddress/UpdateAddress
        /// </summary>
        /// <param name="mailingAddressEntity">在body中传递content-type为application/json {
        /// "_id":"1",      地址id
        ///"_userid": "2",   会员id
        ///"_province": "3",  省
        ///"_city": "4",     市
        /// "_county": "5",  区/县
        ///"_address": "6",  详细地址
        ///"_zipcode": "7",  邮政编码
        ///"_name": "8",    姓名
        /// "_phone": "9"   手机号码
        ///}</param>
        /// <returns></returns>
        // POST api/MailingAddress/UpdateAddress
        [AcceptVerbs("POST")]
        public object UpdateAddress([FromBody]MailingAddressEntity mailingAddressEntity)
        {
            //string[] s = values.Split('/');
            //string id = s[0];
            //string userId = s[1];  //会员id会员id
            //string province = s[2];  //省
            //string city = s[3];  //市
            //string county = s[4];  //区 / 县
            //string address = s[5];  //详细地址
            //string zipCode = s[6];  //邮政编码
            //string name = s[7];  //姓名
            //string phone = s[8];  //手机号码
            //MailingAddressEntity mailingAddressEntity = MailingAddressBll.Instance.GetModel(int.Parse(id));
            //mailingAddressEntity.UserId = userId;
            //mailingAddressEntity.Province = province;
            //mailingAddressEntity.City = city;
            //mailingAddressEntity.County = county;
            //mailingAddressEntity.Address = address;
            //mailingAddressEntity.ZipCode = zipCode;
            //mailingAddressEntity.Name = name;
            //mailingAddressEntity.Phone = phone;
            mailingAddressEntity.AddTime = DateTime.Now;
            mailingAddressEntity.Status = 1;
            if (MailingAddressBll.Instance.Update(mailingAddressEntity))
            {
                return new Dictionary<string, string>() { { "status", "200" } };
            }
            else
            {
                return new Dictionary<string, string>() { { "status", "500" } };
            }
        }
        /// <summary>
        /// 查询收货地址数量
        /// api/MailingAddress/GetRecordCount?uid={1}
        /// </summary>
        /// <param name="uid">会员id</param>
        /// <returns></returns>
        // GET api/MailingAddress/GetRecordCount?uid=1
        [AcceptVerbs("GET")]
        public object GetRecordCount(int uid)
        {
            int count = MailingAddressBll.Instance.GetRecordCount("userid='"+ uid + "'");
            return new Dictionary<string, string>() { { "status", "200" }, {"count",count.ToString()} };
        }
        /// <summary>
        /// 根据会员id查询收货地址
        /// api/MailingAddress/GetAllTable?uid={1}
        /// </summary>
        /// <param name="uid">会员id</param>
        /// <returns></returns>
        // GET api/MailingAddress/GetAllTable?uid=1
        [AcceptVerbs("GET")]
        public object GetAllTable(int uid)
        {
            DataTable addressTable = MailingAddressBll.Instance.GetList("UserId='"+uid+"'").Tables[0];
            return new DataTableModels()
            {
                Dt = addressTable,
                Status = StatusEnum.success
            };
        }
    }
}
