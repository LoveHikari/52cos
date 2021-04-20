using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// 活动
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class ActivityController : ApiController
    {
        /// <summary>
        /// 获得活动列表，例：
        /// api/Activity/GetActivity?num={4}
        /// </summary>
        /// <param name="num">数量</param>
        /// <returns>{"Dt":[],"Status":200}</returns>
        // GET api/Activity/GetActivity?num=4
        [AcceptVerbs("GET")]
        public object GetActivity(int num)
        {
            DataTable activityTable = ActivityBll.Instance.GetList(num, "Status='1'", "ReleaseTime DESC,id DESC");  //活动
            //获得封面
            for (int i = 0; i < activityTable.Rows.Count; i++)
            {
                if (activityTable.Rows[i]["cover"].ToString() != "")
                {
                    activityTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(activityTable.Rows[i]["cover"])).ImgUrl;
                }
            }
            return new DataTableModels()
            {
                Dt = activityTable,
                Status = StatusEnum.success
            };
        }
        /// <summary>
        /// 活动分页
        /// api/Activity/GetActivityByPage?currentPage={4}
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <returns>{"CurrentPage":4,"TypeValue":"","PageSize":10,"PageStartRow":31,"PageEndRow":40,"NextPage":5,"TotalRowsAmount":0,"TotalPages":0,"HasNext":false,"PreviousPage":3,"HasPrevious":true,"Dt":[],"Status":200}</returns>
        // GET api/Activity/GetActivityByPage?currentPage=4
        [AcceptVerbs("GET")]
        public object GetActivityByPage(int currentPage)
        {
            string typeValue = "";  //类型
            int pageSize = 10;  //每页行数
            int pageStartRow = (currentPage - 1) * pageSize + 1;  //开始行数
            int pageEndRow = currentPage * pageSize;  //结束行数
            int nextPage = currentPage + 1; //下一页
            int totalRowsAmount;  //总行数
            int totalPages;  //总页数
            bool hasNext;  //下一页
            int previousPage = currentPage - 1;  //上一页
            bool hasPrevious = previousPage >= 1;  //上一页

            totalRowsAmount = ActivityBll.Instance.GetRecordCount("Status='1'");
            DataTable activityTable = ActivityBll.Instance.GetListByPage("Status='1'", "ReleaseTime DESC,id DESC", pageStartRow, pageEndRow);
            //获得封面
            for (int i = 0; i < activityTable.Rows.Count; i++)
            {
                if (activityTable.Rows[i]["cover"].ToString() != "")
                {
                    activityTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(activityTable.Rows[i]["cover"])).ImgUrl;
                }
            }
            totalPages = int.Parse(Math.Ceiling(totalRowsAmount / 10.0).ToString(CultureInfo.InvariantCulture));
            hasNext = nextPage <= totalPages;

            DataTablePageModels dataTablePageModels = new DataTablePageModels
            {
                CurrentPage = currentPage,
                TypeValue = typeValue,
                PageSize = pageSize,
                PageStartRow = pageStartRow,
                PageEndRow = pageEndRow,
                NextPage = nextPage,
                TotalRowsAmount = totalRowsAmount,
                TotalPages = totalPages,
                HasNext = hasNext,
                PreviousPage = previousPage,
                HasPrevious = hasPrevious,
                Dt = activityTable,
                Status = StatusEnum.success
            };
            return dataTablePageModels;
        }
        /// <summary>
        /// 获得活动实体信息
        /// api/Activity/GetActivityEntity?aid={1}
        /// </summary>
        /// <param name="aid">活动id</param>
        /// <returns></returns>
        // GET api/Activity/GetActivityEntity?aid=1
        [AcceptVerbs("GET")]
        public object GetActivityEntity(int aid)
        {
            ActivityEntity activityEntity = ActivityBll.Instance.GetModel(aid);
            if (activityEntity == null)
            {
                return new Dictionary<string, string>() { { "status", "204" }, { "message", "无内容" } };
            }
            return new DataTableModels
            {
                Dt = activityEntity,
                Status = StatusEnum.success
            };
        }
    }
}
