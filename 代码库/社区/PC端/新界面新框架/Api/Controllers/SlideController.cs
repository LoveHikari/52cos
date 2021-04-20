using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Com.Cos.Bll;

namespace Api.Controllers
{
    /// <summary>
    /// 首页幻灯片
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class SlideController : ApiController
    {
        /// <summary>
        /// 获得幻灯片
        /// api/Slide/GetSlide?num={4}
        /// </summary>
        /// <param name="num">数量</param>
        /// <returns></returns>
        // GET api/Slide/GetSlide?num=4
        [AcceptVerbs("GET")]
        public DataTable GetSlide(int num)
        {
            return SlideBll.Instance.GetList(num, "Status='1' AND Sign='1'", "weight ASC,AddTime DESC,Id DESC");
        }
    }
}
