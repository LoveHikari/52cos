using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Service.ShowManage
{
    /// <summary>
    /// EvaluationVote 的摘要说明
    /// 分享页估价投票
    /// </summary>
    public class EvaluationVote : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string index = context.Request.Form["Index"];
            string id = context.Request.Form["Id"];
            string userId = context.Request.Form["UserId"];
            string s = "";
            DataTable exTable = ExchangeVoteBll.Instance.GetList($"UserId='{userId}' AND ExId='{id}'").Tables[0];
            if (exTable.Rows.Count > 0)
            {
                s = "{\"status\":\"已参与\"}";
            }
            else
            {
                ExchangeEntity exchangeEntity = ExchangeBll.Instance.GetModel(int.Parse(id));
                switch (index)
                {
                    case "1":
                        exchangeEntity.Vote1 = exchangeEntity.Vote1 + 1;
                        break;
                    case "2":
                        exchangeEntity.Vote2 = exchangeEntity.Vote2 + 1;
                        break;
                    case "3":
                        exchangeEntity.Vote3 = exchangeEntity.Vote3 + 1;
                        break;
                }
                if (ExchangeBll.Instance.Update(exchangeEntity))
                {
                    ExchangeVoteEntity exchangeVoteEntity = new ExchangeVoteEntity();
                    exchangeVoteEntity.UserId = userId;
                    exchangeVoteEntity.ExId = id;
                    exchangeVoteEntity.AddTime = DateTime.Now;
                    exchangeVoteEntity.Status = 1;
                    if (ExchangeVoteBll.Instance.Add(exchangeVoteEntity) > 0)
                    {
                        s = "{\"status\":\"success\"}";
                    }

                }
                else
                {
                    s = "{\"status\":\"error\"}";
                }
            }


            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.Write(s);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}