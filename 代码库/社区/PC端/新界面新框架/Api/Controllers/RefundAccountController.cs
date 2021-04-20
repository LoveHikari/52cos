using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Api.Controllers
{
    /// <summary>
    /// 退款账号
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class RefundAccountController : ApiController
    {
        /// <summary>
        /// 保存退款账号
        /// api/RefundAccount/AddRefundAccount
        /// </summary>
        /// <param name="refundAccountEntity">退款账号实体</param>
        /// <returns><c>{"status":200}
        /// {"status":400,"message":"保存失败"}
        /// </c>
        /// </returns>
        [AcceptVerbs("POST")]
        // POST api/RefundAccount/AddRefundAccount
        public object AddRefundAccount([FromBody]RefundAccountEntity refundAccountEntity)
        {
            Random ran = new Random();
            refundAccountEntity.BatchFee = refundAccountEntity.BatchFee < 0 ? 0 - refundAccountEntity.BatchFee : refundAccountEntity.BatchFee;
            refundAccountEntity.BatchNo = $"{DateTime.Now:yyyyMMdd}" + ran.RandomNumber(16);
            refundAccountEntity.AddTime = DateTime.Now;
            refundAccountEntity.Status = 1;
            if (RefundAccountBll.Instance.Add(refundAccountEntity) > 0)
            {
                MemberBll.Instance.UpdateIntegral(refundAccountEntity.UserId, "Deposit", (refundAccountEntity.BatchFee > 0 ? 0 - refundAccountEntity.BatchFee : refundAccountEntity.BatchFee).ToString());
                return new Dictionary<string, string>() { { "status", "200" } };
            }
            else
            {
                return new Dictionary<string, string>() { { "status", "400" }, { "message", "保存失败" } };
            }
        }

        /// <summary>
        /// 保存退款账号
        /// api/RefundAccount/SaveRefundAccount?uid={uid}&amp;realname={realname}&amp;batchfee={batchfee}&amp;accountname={accountname}&amp;remark={remark}
        /// </summary>
        /// <param name="uid">会员id</param>
        /// <param name="realname">真实姓名</param>
        /// <param name="batchfee">付款金额</param>
        /// <param name="accountname">收款方账号</param>
        /// <param name="remark">备注（可空）</param>
        /// <returns><c>{"status":200}
        /// {"status":400,"message":"保存失败"}
        /// </c>
        /// </returns>
        [AcceptVerbs("GET")]
        // GET api/RefundAccount/SaveRefundAccount?uid={uid}&realname={realname}&batchfee={batchfee}&accountname={accountname}&remark={remark}
        public object SaveRefundAccount(string uid, string realname,string batchfee, string accountname,string remark)
        {
            Random ran = new Random();
            RefundAccountEntity refundAccountEntity = new RefundAccountEntity();
            refundAccountEntity.UserId = uid;
            refundAccountEntity.RealName = realname;
            refundAccountEntity.BatchFee = Convert.ToSingle(batchfee)<0?0- Convert.ToSingle(batchfee): Convert.ToSingle(batchfee);
            refundAccountEntity.AccountName = accountname;
            refundAccountEntity.Remark = remark;
            refundAccountEntity.BatchNo = $"{DateTime.Now:yyyyMMdd}" + ran.RandomNumber(16);
            refundAccountEntity.AddTime = DateTime.Now;
            refundAccountEntity.Status = 1;
            if (RefundAccountBll.Instance.Add(refundAccountEntity) > 0)
            {
                MemberBll.Instance.UpdateIntegral(refundAccountEntity.UserId, "Deposit", (Convert.ToSingle(batchfee) > 0 ? 0 - Convert.ToSingle(batchfee) : Convert.ToSingle(batchfee)).ToString());
                return new Dictionary<string, string>() { { "status", "200" } };
            }
            else
            {
                return new Dictionary<string, string>() { { "status", "400" }, { "message", "保存失败" } };
            }
        }
    }
}
