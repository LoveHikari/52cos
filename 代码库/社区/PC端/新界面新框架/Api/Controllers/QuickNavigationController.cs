using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Models;
using Com.Cos.Bll;
using Com.Cos.Utility;

namespace Api.Controllers
{
    /// <summary>
    /// 快捷导航
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class QuickNavigationController : ApiController
    {
        /// <summary>
        /// 获得快捷导航
        /// api/QuickNavigation/GetQuickNavigation?stitlie={用户协议}
        /// </summary>
        /// <param name="stitlie">短标题</param>
        /// <returns></returns>
        // GET api/QuickNavigation/GetQuickNavigation?stitlie=用户协议
        [AcceptVerbs("GET")]
        public object GetQuickNavigation(string stitlie)
        {
            DataTable dt = QuickNavigationBll.Instance.GetList("SmallTitle='"+ stitlie + "' AND Status='1'").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[0]["Cont"] = PubUbbFunc.EditorContentDelHTML(dt.Rows[0]["Cont"].ToString());
            }
            return new DataTableModels()
            {
                Dt = dt,
                Status = StatusEnum.success
            };
        }
    }
}
