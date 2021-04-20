using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using Com.Cos.Bll;
using Com.Cos.Utility;
using Com.Cos.Entity;

namespace Com.Cos.Web
{
    /// <summary>
    /// BasePage 的摘要说明
    /// </summary>

    public class BasePage : System.Web.UI.Page
    {
        protected const string SessionTimeOut = "系统超时或未登录, 请重新登录";
        protected const string SystemError = "系统错误, 请联络你的系统管理员";
        //protected const string LOGIN_DEFAULT_PAGE = "/default.aspx";
        //protected const string LOGIN_PAGE = "/Pages/App_Public/Login.aspx";
        protected const string ERROR_PAGE = "/Pages/App_Public/404.html";
        
        #region 字段
        /// <summary>
        /// 登录人的实体对象
        /// </summary>
        public MemberEntity UserInfo
        {
            get
            {
                if (CookieHelper.GetCookieValue("52cos", "user_id") == null)
                {
                    return null;
                }
                string user_id = DEncryptUtils.DESDecrypt(CookieHelper.GetCookieValue("52cos", "user_id")).Replace("\0", "");
                string pwd = CookieHelper.GetCookieValue("52cos", "pwd");
                string strWhere = $@"User_id='{user_id}' and Password='{pwd}'";
                DataTable dt = MemberBll.Instance.GetList(strWhere).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return MemberBll.Instance.GetModel(Convert.ToInt32(user_id));
                }
                else
                {
                    return null;
                }
                
            }
        }
        /// <summary>
        /// 登录人的用户名
        /// </summary>
        public string UserName
        {
            get { return UserInfo.User_name; }
        }
        /// <summary>
        /// 登录人的账号id
        /// </summary>
        public string User_id
        {
            get
            {
                if (UserInfo == null)
                {
                    return null;
                }
                return this.UserInfo.User_id.ToString();
            }
        }
        /// <summary>
        /// 登录人的昵称
        /// </summary>
        public string nickname
        {
            get { return UserInfo.nickname; }
        }
        /// <summary>
        /// 登录人用户名
        /// </summary>
        public string User_name
        {
            get { return UserInfo.User_name; }
        }
        /// <summary>
        /// 登录人邮箱
        /// </summary>
        public string Email
        {
            get { return UserInfo.Email; }
        }

        /// <summary>
        /// 客户端ip
        /// </summary>
        public string ClientIP
        {
            get { return IpHelper.GetUserIp(); }
        }
        #endregion

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
        }
        
        public BasePage()
        {
            Load += new EventHandler(BasePage_Load);
        }


        //判断是否有乱码
        bool isLuan(string txt)
        {
            var bytes = Encoding.UTF8.GetBytes(txt);

            for (var i = 0; i < bytes.Length; i++)
            {
                if (i < bytes.Length - 3)
                    if (bytes[i] == 239 && bytes[i + 1] == 191 && bytes[i + 2] == 189)
                    {
                        return true;
                    }
            }
            return false;
        }

        void BasePage_Load(object sender, EventArgs e)
        {
            //if (Session["UserInfo"] == null)
            //{
            //    string strAppRoot = GetRootURI();
            //    string strUrl = strAppRoot + LOGIN_PAGE;
            //    Response.Redirect(strUrl, true);
            //}

        }



        public void CloseWindow()
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "CloseWindow", "self.close();", true);
        }

        public void CloseWindow(string message)
        {
            this.ShowMessageBox(message);
            this.CloseWindow();
        }

        public void CloseWindow(string message, string returnValue)
        {
            this.ShowMessageBox(message);
            ScriptManager.RegisterClientScriptBlock(this
                , this.GetType()
                , "CloseWindow"
                , string.Format(@"closeDialogWindow('{0}');", returnValue)
                , true);
        }



        public void ShowMessageBox(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                message = message.Replace("'", "");
                message = message.Replace("\r\n", "");
                string script = string.Format("window.alert('{0}');\r\n", message);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
            }
        }


        

        public string GetRootURI()
        {
            string AppPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            HttpRequest Req;
            if (HttpCurrent != null)
            {
                Req = HttpCurrent.Request;

                string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
                if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                    //直接安装在   Web   站点   
                    AppPath = UrlAuthority;
                else
                    //安装在虚拟子目录下   
                    AppPath = UrlAuthority + Req.ApplicationPath;
            }
            if (!AppPath.Substring(AppPath.Length - 1, 1).Equals("/"))
            {
                AppPath = AppPath + "/";
            }
            AppPath = AppPath.Substring(0, AppPath.Length - 1);
            return AppPath;
        }

        protected void GotoErrorPage(string message)
        {
            string strAppRoot = GetRootURI();
            string errorUrl = strAppRoot + ERROR_PAGE;
            Session.Remove("ErrorMessage");
            Session.Add("ErrorMessage", message);
            Response.Write(message);
            Response.Redirect(errorUrl + "?rdm=" + DateTime.Now.Ticks, true);
        }

        protected override void OnError(EventArgs e)
        {
            base.OnError(e);
            HttpContext ctx = HttpContext.Current;
            Exception exception = ctx.Server.GetLastError();

            if (exception == null)
                exception = new Exception("系统错误，请联系系统管理员");
            string errorInfo = "<br>Offending URL: " + ctx.Request.Url.ToString() +
                               "<br>Source: " + exception.Source +
                               "<br>Message: " + exception.Message +
                               "<br>Stack trace: " + exception.StackTrace;

            // --------------------------------------------------
            // To let the page finish running we clear the error
            // --------------------------------------------------
            ctx.Server.ClearError();


            GotoErrorPage(errorInfo);
        }

        protected void HandleException(Exception ex)
        {

        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
        }

    }
}
