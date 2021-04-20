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
    /// 兑换分类
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class ExchangeClassController : ApiController
    {
        /// <summary>
        /// 获得兑换分类，例：
        /// api/ExchangeClass/GetClassData
        /// </summary>
        /// <returns>{"Dt":[{"Id":1,"ClassName":"cos","ClassId":1,"Reserved":null,"Status":1},{"Id":2,"ClassName":"日常","ClassId":2,"Reserved":null,"Status":1},{"Id":3,"ClassName":"loli","ClassId":3,"Reserved":null,"Status":1}],"Status":200}</returns>
        // GET api/ExchangeClass/GetClassData
        [AcceptVerbs("GET")]
        public object GetClassData()
        {
            DataTable dt = ExchangeClassBll.Instance.GetList("status=1").Tables[0];
            return new DataTableModels()
            {
                Dt = dt,
                Status = StatusEnum.success
            };
        }
    }
}