using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Models;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Api.Controllers
{
    /// <summary>
    /// 兑换人员
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class ExchangePersonController : ApiController
    {
        /// <summary>
        /// 根据会员获得兑换
        /// api/Share/GetShare?uid={4}
        /// </summary>
        /// <param name="uid">会员id</param>
        /// <returns></returns>
        // GET api/ExchangePerson/GetShare?uid=4
        [AcceptVerbs("GET")]
        public object GetShare(int uid)
        {
            DataTable shareTable = ExchangePersonBll.Instance.GetList("m.User_id='"+uid+"' AND ep.Examine=1 AND ep.Status='1'", "ep.AddTime DESC,ep.Id DESC").Tables[0];  //分享
            //获得封面
            for (int i = 0; i < shareTable.Rows.Count; i++)
            {
                if (shareTable.Rows[i]["cover"].ToString() != "")
                {
                    shareTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["cover"]))?.ImgUrl;
                }
            }
            return new DataTableModels()
            {
                Dt = shareTable,
                Status = StatusEnum.success
            };
        }
        /// <summary>
        /// 获得会员兑换情况
        /// api/ExchangePerson/GetShareStatus?uid={4}
        /// </summary>
        /// <param name="uid">会员id</param>
        /// <returns><code>
        /// {"status":4031,"message":"已有兑换"}
        /// {"status":4032,"message":"未交押金"}
        /// {"status":200}
        /// </code></returns>
        // GET api/ExchangePerson/GetShareStatus?uid=4
        [AcceptVerbs("GET")]
        public object GetShareStatus(int uid)
        {
            DataTable dt = ExchangePersonBll.Instance.GetList($"UserId={uid} AND Examine=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return new Dictionary<string,string>() { { "ststus", "4031" } , {"message","已有兑换"} };
            }
            dt = MemberBll.Instance.GetList("User_id=" + uid).Tables[0];
            if (dt.Rows.Count < 1 || string.IsNullOrEmpty(dt.Rows[0]["Deposit"].ToString()) || double.Parse(dt.Rows[0]["Deposit"].ToString()) <=0)
            {
                return new Dictionary<string, string>() { { "ststus", "4032" }, { "message", "未交押金" } };
            }
            return new Dictionary<string, string>() { { "ststus", "200" } };

        }
    }
}
