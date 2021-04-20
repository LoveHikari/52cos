using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using Api.Models;
using Com.Cos.Bll;

namespace Api.Controllers
{
    /// <summary>
    /// 系统表
    /// </summary>
    [System.Web.Mvc.AllowAnonymous]
    [System.Web.Mvc.Authorize]
    public class SysParaController : ApiController
    {
        /// <summary>
        /// 获得全部系统配置
        /// api/SysPara/GetAllSysPara
        /// </summary>
        /// <returns></returns>
        // GET api/SysPara/GetAllSysPara
        [AcceptVerbs("GET")]
        public object GetAllSysPara()
        {
            DataTable dt = SysParaBll.Instance.GetList("status='1'");
            return new DataTableModels()
            {
                Dt = dt,
                Status = StatusEnum.success
            };
        }
        /// <summary>
        /// 获得指定类型的系统配置
        /// api/SysPara/GetSysPara?rt={ordersClass}
        /// </summary>
        /// <param name="rt">RefType</param>
        /// <returns></returns>
        // GET api/SysPara/GetSysPara?rt=ordersClass
        [AcceptVerbs("GET")]
        public object GetSysPara(string rt)
        {
            DataTable dt = SysParaBll.Instance.GetList($"RefType='{rt}' AND Status=1");
            return new DataTableModels()
            {
                Dt = dt,
                Status = StatusEnum.success
            };
        }
    }
}