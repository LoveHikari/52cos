using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Com.Cos.Common
{
    public static class Public
    {
        /// <summary>
        /// 获得登录后的会员id
        /// </summary>
        /// <returns>未登录时返回-1</returns>
        public static int GetLoginUid()
        {
            IDictionary<string, string> cookies = GetLoginCookie();
            if (cookies.ContainsKey(ClaimTypes.NameIdentifier))
            {
                return cookies[ClaimTypes.NameIdentifier].ToInt32();
            }
            return -1;
        }
        /// <summary>
        /// 获得登录信息cookie
        /// </summary>
        /// <returns>cookie键值对</returns>
        private static IDictionary<string, string> GetLoginCookie()
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //IEnumerable<Claim> claims = identity.Claims;
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            IEnumerable<Claim> claims = identity.Claims;
            return claims.ToDictionary(k => k.Type, k => k.Value);
        }
        /// <summary>
        /// 获得性别
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static string GetGender(object gender)
        {
            string sex = gender?.ToString();
            switch (sex)
            {
                case "0":
                    return "女";
                case "1":
                    return "男";
                default:
                    return "未知";
            }

        }
        /// <summary>
        /// 生成页码
        /// </summary>
        /// <param name="urlHelper">获取或设置已呈现的页的URL</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="routeName">用于生成URL的路由的名称</param>
        /// <param name="routeValues">一个包含路由参数的对象</param>
        /// <returns></returns>
        public static MvcHtmlString GetToPager(this UrlHelper urlHelper, int pageIndex, int pageSize, int totalRecord, string routeName, object routeValues)
        {
            int pageNum = System.Math.Ceiling((double)totalRecord / pageSize).ToInt32();  //总页数=总记录数/每页记录数
            if (pageNum > 0 && pageIndex <= pageNum)
            {
                RouteValueDictionary theObj = new RouteValueDictionary();
                foreach (var item in routeValues.GetType().GetProperties())
                {
                    theObj.Add(item.Name, item.GetValue(routeValues, null));
                }
                if (theObj.Keys.Contains("P"))
                {
                    theObj.Add("P", 1);
                }  //如果没有page，则添加


                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<div class=\"fenyww clearfix\">");
                sb.AppendLine("<ul>");
                string href;
                if (pageIndex > 1)
                {
                    theObj["p"] = 1;
                    href = urlHelper.RouteUrl(routeName, theObj);
                    sb.AppendLine($"<li><a href=\"{href}\"><span><img src=\"/Content/img/backgf.png\" class=\"img-style\" /></span></a></li>");
                }
                if (pageNum <= 6)
                {
                    for (int i = 1; i <= pageNum; i++)
                    {
                        theObj["p"] = i;
                        href = urlHelper.RouteUrl(routeName, theObj);
                        if (pageIndex == i)
                        {
                            sb.AppendLine($"<li class=\"on\"><span>{i}</span></li>");
                        }
                        else
                        {
                            sb.AppendLine($"<li><a href=\"{href}\"><span>{i}</span></a></li>");
                        }

                    }
                }
                else
                {
                    if (pageIndex == 1)
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            theObj["p"] = i;
                            href = urlHelper.RouteUrl(routeName, theObj);
                            if (pageIndex == i)
                            {
                                sb.AppendLine($"<li class=\"on\"><span>{i}</span></li>");
                            }
                            else
                            {
                                sb.AppendLine($"<li><a href=\"{href}\"><span>{i}</span></a></li>");
                            }

                        }
                        theObj["p"] = 5;
                        href = urlHelper.RouteUrl(routeName, theObj);
                        sb.AppendLine($"<li><a href=\"{href}\"><span>...</span></a></li>");
                        theObj["p"] = pageNum;
                        href = urlHelper.RouteUrl(routeName, theObj);
                        sb.AppendLine($"<li><a href=\"{href}\"><span>{pageNum}</span></a></li>");
                    }
                    else if (pageIndex + 2 >= pageNum)
                    {
                        theObj["p"] = 1;
                        href = urlHelper.RouteUrl(routeName, theObj);
                        sb.AppendLine($"<li><a href=\"{href}\"><span>1</span></a></li>");
                        theObj["p"] = 2;
                        href = urlHelper.RouteUrl(routeName, theObj);
                        sb.AppendLine($"<li><a href=\"{href}\"><span>...</span></a></li>");
                        for (int i = pageNum - 3; i <= pageNum; i++)
                        {
                            theObj["p"] = i;
                            href = urlHelper.RouteUrl(routeName, theObj);
                            if (pageIndex == i)
                            {
                                sb.AppendLine($"<li class=\"on\"><span>{i}</span></li>");
                            }
                            else
                            {
                                sb.AppendLine($"<li><a href=\"{href}\"><span>{i}</span></a></li>");
                            }

                        }
                    }
                    else
                    {
                        for (int i = pageIndex - 1; i <= pageIndex + 2; i++)
                        {
                            theObj["p"] = i;
                            href = urlHelper.RouteUrl(routeName, theObj);
                            if (pageIndex == i)
                            {
                                sb.AppendLine($"<li class=\"on\"><span>{i}</span></li>");
                            }
                            else
                            {
                                sb.AppendLine($"<li><a href=\"{href}\"><span>{i}</span></a></li>");
                            }
                        }
                        theObj["p"] = pageIndex + 3;
                        href = urlHelper.RouteUrl(routeName, theObj);
                        sb.AppendLine($"<li><a href=\"{href}\"><span>...</span></a></li>");
                        theObj["p"] = pageNum;
                        href = urlHelper.RouteUrl(routeName, theObj);
                        sb.AppendLine($"<li><a href=\"{href}\"><span>{pageNum}</span></a></li>");
                    }
                }
                if (pageIndex != pageNum)
                {
                    theObj["p"] = pageIndex + 1;
                    href = urlHelper.RouteUrl(routeName, theObj);
                    sb.AppendLine($"<li><a href=\"{href}\"><span style=\"width:73px;\">下一页</span></a></li>");
                }
                theObj["p"] = "page";
                href = urlHelper.RouteUrl(routeName, theObj);
                sb.AppendLine("<li><label>转跳至：</label><input id=\"txtPage\" type=\"text\"><i><a id=\"goPage\">GO</a></i></li>");
                sb.AppendLine("</ul>");
                sb.AppendLine("<script>");
                sb.AppendLine("var text=document.getElementById(\"txtPage\");");
                sb.AppendLine("text.onkeyup=function(){");
                sb.AppendLine("this.value=this.value.replace(/\\D/g, '');");
                sb.AppendLine("if (text.value>" + pageNum + ")");
                sb.AppendLine("{");
                sb.AppendLine("text.value=" + pageNum + ";");
                sb.AppendLine("}");
                sb.AppendLine("}");
                sb.AppendLine("$(\"#goPage\").bind(\"click\", function () {");
                sb.AppendLine("var page = $(\"#txtPage\").val();");
                sb.AppendLine("if (page != \"\" && page !=\"undefined\") {");
                sb.AppendLine("window.location.href = \"" + href + "\".replace(\"page\",page);");
                sb.AppendLine("}");
                sb.AppendLine("return false;");
                sb.AppendLine("});");
                sb.AppendLine("</script>");
                sb.AppendLine("</div>");
                return new MvcHtmlString(sb.ToString());
            }
            return new MvcHtmlString("");
        }

        /// <summary>
        /// 生成页码
        /// </summary>
        /// <param name="urlHelper">获取或设置已呈现的页的URL</param>
        /// <param name="ajaxHelper"></param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="action">方法名称</param>
        /// <param name="controller">控制器名称</param>
        /// <returns></returns>
        public static MvcHtmlString GetToPager(this UrlHelper urlHelper, AjaxHelper ajaxHelper, int pageIndex, int pageSize, int totalRecord, string action, string controller)
        {
            int pageNum = System.Math.Ceiling((double)totalRecord / pageSize).ToInt32();  //总页数=总记录数/每页记录数
            if (pageNum > 0 && pageIndex <= pageNum)
            {
                RouteValueDictionary theObj = new RouteValueDictionary();
                theObj.Add("P", 1);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<div id=\"paegs\" class=\"clearfix\">");
                sb.AppendLine("<ul>");
                if (pageIndex > 1)
                {
                    theObj["p"] = 1;
                    sb.AppendLine("<li>" + ajaxHelper.ActionLink(">>", action, controller, theObj, new AjaxOptions { UpdateTargetId = "tb" }) + "</li>");
                }
                if (pageNum <= 6)
                {
                    for (int i = 1; i <= pageNum; i++)
                    {
                        theObj["p"] = i;
                        if (pageIndex == i)
                        {
                            sb.AppendLine($"<li class=\"on\">{i}</li>");
                        }
                        else
                        {
                            sb.AppendLine("<li>" + ajaxHelper.ActionLink(i.ToString(), action, controller, theObj, new AjaxOptions { UpdateTargetId = "tb" }) + "</li>");
                            //sb.AppendLine($"<li><a href=\"{href}\">{i}</a></li>");
                        }

                    }
                }
                else
                {
                    if (pageIndex == 1)
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            theObj["p"] = i;
                            if (pageIndex == i)
                            {
                                sb.AppendLine($"<li class=\"on\">{i}</li>");
                            }
                            else
                            {
                                sb.AppendLine("<li>" + ajaxHelper.ActionLink(i.ToString(), action, controller, theObj, new AjaxOptions { UpdateTargetId = "tb" }) + "</li>");
                            }

                        }
                        theObj["p"] = 5;
                        sb.AppendLine("<li>" + ajaxHelper.ActionLink("...", action, controller, theObj, new AjaxOptions { UpdateTargetId = "tb" }) + "</li>");
                        theObj["p"] = pageNum;
                        sb.AppendLine("<li>" + ajaxHelper.ActionLink(pageNum.ToString(), action, controller, theObj, new AjaxOptions { UpdateTargetId = "tb" }) + "</li>");
                    }
                    else if (pageIndex + 2 >= pageNum)
                    {
                        theObj["p"] = 1;
                        sb.AppendLine("<li>" + ajaxHelper.ActionLink("1", action, controller, theObj, new AjaxOptions { UpdateTargetId = "tb" }) + "</li>");
                        theObj["p"] = 2;
                        sb.AppendLine("<li>" + ajaxHelper.ActionLink("...", action, controller, theObj, new AjaxOptions { UpdateTargetId = "tb" }) + "</li>");
                        for (int i = pageNum - 3; i <= pageNum; i++)
                        {
                            theObj["p"] = i;
                            if (pageIndex == i)
                            {
                                sb.AppendLine($"<li class=\"on\">{i}</li>");
                            }
                            else
                            {
                                sb.AppendLine("<li>" + ajaxHelper.ActionLink(i.ToString(), action, controller, theObj, new AjaxOptions { UpdateTargetId = "tb" }) + "</li>");
                            }

                        }
                    }
                    else
                    {
                        for (int i = pageIndex - 1; i <= pageIndex + 2; i++)
                        {
                            theObj["p"] = i;
                            if (pageIndex == i)
                            {
                                sb.AppendLine($"<li class=\"on\">{i}</li>");
                            }
                            else
                            {
                                sb.AppendLine("<li>" + ajaxHelper.ActionLink(i.ToString(), action, controller, theObj, new AjaxOptions { UpdateTargetId = "tb" }) + "</li>");
                            }
                        }
                        theObj["p"] = pageIndex + 3;
                        sb.AppendLine("<li>" + ajaxHelper.ActionLink("...", action, controller, theObj, new AjaxOptions { UpdateTargetId = "tb" }) + "</li>");
                        theObj["p"] = pageNum;
                        sb.AppendLine("<li>" + ajaxHelper.ActionLink(pageNum.ToString(), action, controller, theObj, new AjaxOptions { UpdateTargetId = "tb" }) + "</li>");
                    }
                }
                if (pageIndex != pageNum)
                {
                    theObj["p"] = pageIndex + 1;
                    sb.AppendLine("<li>" + ajaxHelper.ActionLink("下一页", action, controller, theObj, new AjaxOptions { UpdateTargetId = "tb" }) + "</li>");
                }
                sb.AppendLine("</ul>");
                sb.AppendLine("</div>");
                return new MvcHtmlString(sb.ToString());
            }
            return new MvcHtmlString("");
        }

        /// <summary>
        /// 显示404页面
        /// </summary>
        public static void Show404()
        {
            string path = HttpContext.Current.Server.MapPath("~/404.htm");
            System.IO.StreamReader reader = new System.IO.StreamReader(path, System.Text.Encoding.UTF8);
            string str = reader.ReadToEnd();
            reader.Close();
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.Status = "404 Not Found";
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 消息json
        /// </summary>
        /// <param name="i">非0即真</param>
        /// <param name="message">提示信息</param>
        /// <returns></returns>
        public static Dictionary<string, string> MessageJson(int i, string message)
        {
            if (i == 0)
            {
                return new Dictionary<string, string>() { { "status", "error" }, { "message", message } };
            }
            else
            {
                return new Dictionary<string, string>() { { "status", "success" }, { "message", message } };

            }

        }
        /// <summary>
        /// 消息json
        /// </summary>
        /// <param name="b">非0即真</param>
        /// <param name="message">提示信息</param>
        /// <returns></returns>
        public static string MessageJson(bool b, string message)
        {
            if (b)
            {
                return "{\"status\":\"success\",\"message\":\"" + message + "\"}";
            }
            else
            {
                return "{\"status\":\"error\",\"message\":\"" + message + "\"}";
            }

        }
    }
}