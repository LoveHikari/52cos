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
    /// 收藏
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class CollectController : ApiController
    {
        /// <summary>
        /// 添加收藏，例：
        /// api/Collect/AddCollect/Collect?uid=30&amp;aid=1&amp;cid=1
        /// </summary>
        /// <param name="uid">会员id</param>
        /// <param name="aid">文章id</param>
        /// <param name="cid">分类</param>
        /// <returns>返回status。200为成功，500为失败，403为参数不齐；iskeep=1为收藏，iskeep=0为取消收藏</returns>
        // POST api/Collect/AddCollect/Collect?uid=30&aid=1&cid=1
        [AcceptVerbs("POST")]
        public object AddCollect(string uid, string aid, string cid)
        {
            if (string.IsNullOrEmpty(uid) || string.IsNullOrEmpty(aid) || string.IsNullOrEmpty(cid))
            {
                return new KeyValuePair<string, string>("status", "403");   //参数不齐
            }

            //判断是否存在记录
            string strWhere = $"1=1 and userid='{uid}' and articleid='{aid}' and classid='{cid}'";
            DataTable dt = CollectBll.Instance.GetList(strWhere).Tables[0];
            if (dt.Rows.Count>0)
            {
                if (dt.Rows[0]["status"].ToString() == "1")
                {
                    CollectEntity ce = CollectBll.Instance.GetModel(int.Parse(dt.Rows[0]["id"].ToString()));
                    ce.Status = 0;
                    CollectBll.Instance.Update(ce);
                    return new Dictionary<string, string> { { "status", "200" }, { "iskeep", "0" } }; //成功收藏
                }
                else
                {
                    CollectEntity ce = CollectBll.Instance.GetModel(int.Parse(dt.Rows[0]["id"].ToString()));
                    ce.Status = 1;
                    CollectBll.Instance.Update(ce);
                    return new Dictionary<string, string> { { "status", "200" }, { "iskeep", "1" } }; //成功收藏
                }
            }

            CollectEntity collectEntity = new CollectEntity
            {
                UserId = System.Web.HttpUtility.JavaScriptStringEncode(uid),
                ArticleId = System.Web.HttpUtility.JavaScriptStringEncode(aid),
                ClassId = System.Web.HttpUtility.JavaScriptStringEncode(cid),
                AddTime = DateTime.Now
            };
            if (CollectBll.Instance.Add(collectEntity) > 0)
            {
                return new Dictionary<string,string>{ { "status", "200"}, { "iskeep", "1"} }; //成功收藏
            }
            else
            {
                return new Dictionary<string, string> { { "status", "500" } }; //成功收藏
            }
            
        }
        /// <summary>
        /// 根据会员id获得所有收藏，例：
        /// api/Collect/GetCollectByUserId/Collect?uid=30
        /// </summary>
        /// <param name="uid">会员id</param>
        /// <returns></returns>
        // GET api/Collect/GetCollectByUserId/Collect?uid=30
        [AcceptVerbs("GET")]
        public object GetCollectByUserId(string uid)
        {
            string userId = System.Web.HttpUtility.JavaScriptStringEncode(uid);
            DataTable dt = CollectBll.Instance.GetList($"status=1 and userid={userId}", "addtime desc").Tables[0];
             return new DataTableModels()
            {
                Dt = dt,
                Status = StatusEnum.success
            };
        }
    }
}
