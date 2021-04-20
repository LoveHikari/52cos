using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Service.HomeManage
{
    /// <summary>
    /// UploadPortrait 的摘要说明
    /// </summary>
    public class UploadPortrait : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userId = DEncryptUtils.DESDecrypt(CookieHelper.GetCookieValue("52cos", "user_id")).Replace("\0", "");
            string img = context.Request.Form["b4"];
            string strReturn;

            MemberEntity memberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(userId));
            memberEntity.Portrait = UploadFile.UploadImg(img, "Upload\\Portrait\\");
            bool b = MemberBll.Instance.Update(memberEntity);
            if (b)
            {
                strReturn = "{\"status\":\"success\"}";
            }
            else
            {
                strReturn = "{\"status\":\"error\"}";
            }

            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.Write(strReturn);
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