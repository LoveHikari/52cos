using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Com.Cos.Bll;

namespace Com.Cos.Web.Service.HomeManage
{
    /// <summary>
    /// GeNoteType2ByNoteType 的摘要说明
    /// 根据一级分类获得二级分类
    /// </summary>
    public class GeNoteType2ByNoteType : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string noteType = context.Request.QueryString["nt"];
            string s = "";
            DataTable dt = SysParaBll.Instance.GetList("id='"+noteType+"'");
            if (dt.Rows.Count > 0)
            {
                noteType = dt.Rows[0]["RefValue"].ToString();

                dt = SysParaBll.Instance.GetList("RefType='noteType2' and RefDesc='" + noteType + "'");
                if (dt.Rows.Count > 0)
                {
                    s = "<select name='ctb[cats][]' class='ctb-cat form-control'>";
                    s += "<option value=''>选择类别</option>";
                    foreach (DataRow row in dt.Rows)
                    {
                        s += "<option value='" + row["id"] + "' title=''>" + row["RefText"] + "</option>";
                    }
                    s += "</select>";
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