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
    /// 合作
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class CooperationController : ApiController
    {
        /// <summary>
        /// 获得合作
        /// api/Cooperation/GetCoo?num={4}
        /// </summary>
        /// <param name="num">数量</param>
        /// <returns></returns>
        // GET api/Cooperation/GetCoo?num=4
        [AcceptVerbs("GET")]
        public object GetCoo(int num)
        {
            DataTable cooTable = CooperationBll.Instance.GetList(num, "Status='1'", "ReleaseTime DESC,id DESC");  //合作
            //获得封面
            for (int i = 0; i < cooTable.Rows.Count; i++)
            {
                if (cooTable.Rows[i]["cover"].ToString() != "")
                {
                    string[] imgIds = cooTable.Rows[i]["cover"].ToString().Split(',');
                    string imgs = "";
                    foreach (string imgId in imgIds)
                    {
                        ImgEntity imgEntity = ImgBll.Instance.GetModel(int.Parse(imgId));
                        imgs += imgEntity?.ImgUrl + ",";
                    }
                    cooTable.Rows[i]["cover"] = imgs;
                }
            }
            return new DataTableModels()
            {
                Dt = cooTable,
                Status = StatusEnum.success
            };
        }

        /// <summary>
        /// 合作分页
        /// api/Cooperation/GetCooByPage?currentPage={4}
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <returns></returns>
        // GET api/Cooperation/GetCooByPage?currentPage=4
        [AcceptVerbs("GET")]
        public object GetCooByPage(int currentPage)
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

            totalRowsAmount = CooperationBll.Instance.GetRecordCount("Status='1'");
            DataTable cooTable = CooperationBll.Instance.GetListByPage("Status='1'", "ReleaseTime DESC,id DESC", pageStartRow, pageEndRow);
            //获得封面
            for (int i = 0; i < cooTable.Rows.Count; i++)
            {
                string[] imgIds = cooTable.Rows[i]["cover"].ToString().Split(',');
                string imgs = "";
                foreach (string imgId in imgIds)
                {
                    if (!string.IsNullOrEmpty(imgId))
                    {
                        ImgEntity imgEntity = ImgBll.Instance.GetModel(int.Parse(imgId));
                        imgs += imgEntity.ImgUrl + ",";
                    }

                }
                cooTable.Rows[i]["cover"] = imgs;
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
                Dt = cooTable,
                Status = StatusEnum.success
            };
            return dataTablePageModels;
        }
        /// <summary>
        /// 获得合作实体信息
        /// api/Cooperation/GetCooEntity?cid={1}
        /// </summary>
        /// <param name="cid">合作id</param>
        /// <returns></returns>
        // GET api/Cooperation/GetCooEntity?cid=1
        [AcceptVerbs("GET")]
        public object GetCooEntity(int cid)
        {
            CooperationEntity cooperationEntity = CooperationBll.Instance.GetModel(cid);
            if (cooperationEntity == null)
            {
                return new Dictionary<string, string>() { { "status", "204" }, { "massage", "无内容" } };
            }
            return new DataTableModels
            {
                Dt = cooperationEntity,
                Status = StatusEnum.success
            };
        }
        /// <summary>
        /// 保存合作
        /// api/Cooperation/SaveCooperation
        /// </summary>
        /// <param name="cooperationEntity"></param>
        /// <returns></returns>
        [AcceptVerbs("POST")]
        // POST api/Cooperation/SaveCooperation
        public object SaveCooperation([FromBody]CooperationEntity cooperationEntity)
        {

            cooperationEntity.ReleaseTime = DateTime.Now;
            cooperationEntity.Status = 1;
            if (CooperationBll.Instance.Add(cooperationEntity) > 0)
            {
                return new Dictionary<string,string>() { {"status","200"} };
            }
            else
            {
                return new Dictionary<string, string>() { { "status", "400" }, {"message","保存失败"} };
            }
        }
    }
}
