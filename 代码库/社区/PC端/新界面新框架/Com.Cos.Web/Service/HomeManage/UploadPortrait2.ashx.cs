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
    /// UploadPortrait2 的摘要说明
    /// </summary>
    public class UploadPortrait2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userId = context.Request.Form["UserId"];
            string img = context.Request.Form["b4"];
            string strReturn;

            try
            {
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
            }
            catch (System.Exception ex)
            {
                strReturn = "{\"status\":\"" + ex.Message + "\"}";
                WriteLog.WriteError(ex);
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