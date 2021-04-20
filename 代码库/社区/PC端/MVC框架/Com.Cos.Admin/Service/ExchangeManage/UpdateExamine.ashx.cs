using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.BLL;
using Com.Cos.Common;

namespace Com.Cos.Admin.Service.ExchangeManage
{
    /// <summary>
    /// UpdateExamine 的摘要说明
    /// 修改审核状态
    /// </summary>
    public class UpdateExamine : IHttpHandler
    {
        private readonly Com.Cos.IBLL.IExchangeService _exchangeService;

        public UpdateExamine()
        {
            _exchangeService = new ExchangeService();
        }
        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            int id = context.Request.Form.Get("Id").ToInt32();  //兑换id
            string examine = context.Request.Form.Get("Examine");  //兑换状态
            string official = context.Request.Form.Get("Official");  //最终值
            if (examine == "1")  //如果状态是审核中
            {
                ShenHe(id, official);
            }
            if (examine == "2")  //如果状态是回收中，则执行回收操作
            {
                HuiShou(id);
            }
            if (examine == "4")  //如果状态为已兑换，则执行重新发布操作
            {
                Start(id);
            }
            if (examine == "-1") //执行下架
            {
                Stop(id);
            }
            s = Com.Cos.Common.Public.MessageJson(true, "成功");
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.Write(s);
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="official">最终值</param>
        private void ShenHe(int id, string official)
        {
            var exchange = _exchangeService.Find(id);
            exchange.Official = official;  //设置最终值
            exchange.Examine = "1";
            _exchangeService.Update(exchange);
        }
        /// <summary>
        /// 确认回收
        /// </summary>
        /// <param name="id">兑换id</param>
        private void HuiShou(int id)
        {
            var exchange = _exchangeService.Find(id);
            exchange.Examine = "3";  //将状态改为可兑换
            _exchangeService.Update(exchange);
        }
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="id">兑换id</param>
        private void Start(int id)
        {
            var exchange = _exchangeService.Find(id);
            exchange.Examine = "3";  //将状态改为可兑换
            _exchangeService.Update(exchange);
        }
        /// <summary>
        /// 下架
        /// </summary>
        /// <param name="id">兑换id</param>
        private void Stop(int id)
        {
            var exchange = _exchangeService.Find(id);
            exchange.Examine = "0";  //将状态改为已结束
            _exchangeService.Update(exchange);
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