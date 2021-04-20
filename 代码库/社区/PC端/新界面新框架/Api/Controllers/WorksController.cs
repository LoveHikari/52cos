using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using Api.Models;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Api.Controllers
{
    /// <summary>
    /// 作品
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class WorksController : ApiController
    {
        /// <summary>
        /// 获得作品
        /// api/Works/GetWorks?typeValue={cos}&amp;num={4}
        /// </summary>
        /// <param name="typeValue">类  可取值：cos(cos)日常(daily)绘画(painting)轻小说(photography)</param>
        /// <param name="num">数量</param>
        /// <returns></returns>
        // GET api/Works/GetWorks?typeValue=cos&num=4
        [AcceptVerbs("GET")]
        public object GetWorks(string typeValue,int num)
        {
            DataTable sysTable = SysParaBll.Instance.GetList($"Status='1' and RefType='noteType' and RefValue='{typeValue}'");
            if (sysTable.Rows.Count > 0)
            {
                DataTable worksTable = WorksBll.Instance.GetList(num, $"Status='1' and WorksType='{sysTable.Rows[0]["id"]}'", "UpdateTime desc,WorksId desc");
                //获得类型、封面
                for (int i = 0; i < worksTable.Rows.Count; i++)
                {
                    if (worksTable.Rows[i]["WorksType"].ToString() != "")
                    {
                        worksTable.Rows[i]["WorksType"] = SysParaBll.Instance.GetModel(Convert.ToInt32(worksTable.Rows[i]["WorksType"]))?.RefText;
                    }
                    if (worksTable.Rows[i]["type2"].ToString() != "")
                    {
                        worksTable.Rows[i]["type2"] = SysParaBll.Instance.GetModel(Convert.ToInt32(worksTable.Rows[i]["type2"]))?.RefText;
                    }
                    if (worksTable.Rows[i]["cover"].ToString() != "")
                    {
                        worksTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(worksTable.Rows[i]["cover"])).ImgUrl;
                    }
                }
                DataTableModels dataTableModels = new DataTableModels
                {
                    Dt = worksTable,
                    Status = StatusEnum.success
                };
                return dataTableModels;
            }
            return  new Dictionary<string,string>() { {"status","204"}, {"message","无内容"} };
        }

        /// <summary>
        /// 作品分页
        /// api/Works/GetWorksByPage?typeValue={cos}&amp;currentPage={1}
        /// </summary>
        /// <param name="typeValue">类型  类型的可取值：cos(cos)日常(daily)绘画(painting)轻小说(photography)</param>
        /// <param name="currentPage">当前页</param>
        /// <returns></returns>
        // GET api/Works/GetWorksByPage?typeValue=cos&currentPage=1
        [AcceptVerbs("GET")]
        public object GetWorksByPage(string typeValue,int currentPage)
        {

            int pageSize = 10;  //每页行数
            int pageStartRow = (currentPage - 1) * pageSize + 1;  //开始行数
            int pageEndRow = currentPage * pageSize;  //结束行数
            int nextPage = currentPage + 1; //下一页
            int totalRowsAmount;  //总行数
            int totalPages;  //总页数
            bool hasNext;  //下一页
            int previousPage = currentPage - 1;  //上一页
            bool hasPrevious = previousPage >= 1;  //上一页

            DataTable sysTable = SysParaBll.Instance.GetList($"Status='1' and RefType='noteType' and RefValue='{typeValue}'");
            if (sysTable.Rows.Count > 0)
            {
                string strWhere = $"Status='1' and WorksType='{sysTable.Rows[0]["id"]}'";
                totalRowsAmount = WorksBll.Instance.GetRecordCount(strWhere);
                DataTable worksTable = WorksBll.Instance.GetListByPage(strWhere, "UpdateTime desc,WorksId desc", pageStartRow, pageEndRow);
                //获得类型、封面
                for (int i = 0; i < worksTable.Rows.Count; i++)
                {
                    if (worksTable.Rows[i]["WorksType"].ToString() != "")
                    {
                        worksTable.Rows[i]["WorksType"] = SysParaBll.Instance.GetModel(Convert.ToInt32(worksTable.Rows[i]["WorksType"]))?.RefText;
                    }
                    if (worksTable.Rows[i]["type2"].ToString() != "")
                    {
                        worksTable.Rows[i]["type2"] = SysParaBll.Instance.GetModel(Convert.ToInt32(worksTable.Rows[i]["type2"]))?.RefText;
                    }
                    if (worksTable.Rows[i]["cover"].ToString() != "")
                    {
                        worksTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(worksTable.Rows[i]["cover"])).ImgUrl;
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
                    Dt = worksTable,
                    Status = StatusEnum.success
                };
                return dataTablePageModels;
            }
            return new Dictionary<string, string>() { { "status", "204" }, { "message", "无内容" } };
        }
        /// <summary>
        /// 获得作品实体信息
        /// api/Works/GetWorksEntity?wid={1}
        /// </summary>
        /// <param name="wid">作品id</param>
        /// <returns></returns>
        // GET api/Works/GetWorksEntity?wid=1
        [AcceptVerbs("GET")]
        public object GetWorksEntity(int wid)
        {
            WorksEntity worksEntity = WorksBll.Instance.GetModel(wid);
            if (worksEntity == null)
            {
                return new Dictionary<string, string>() { { "status", "204" }, { "message", "无内容" } };
            }
            return new DataTableModels
            {
                Dt = worksEntity,
                Status = StatusEnum.success
            };
        }
        /// <summary>
        /// 获得萌推荐
        /// api/Works/GetRecommend?num={4}
        /// </summary>
        /// <param name="num">数量</param>
        /// <returns></returns>
        // GET api/Works/GetRecommend?num=4
        [AcceptVerbs("GET")]
        public object GetRecommend(int num)
        {

            DataTable worksTable = WorksBll.Instance.GetList(num, "Status>0 AND Recommend='1'", "ReleaseTime DESC");
            //获得类型、封面
            for (int i = 0; i < worksTable.Rows.Count; i++)
            {
                if (worksTable.Rows[i]["WorksType"].ToString() != "")
                {
                    worksTable.Rows[i]["WorksType"] = SysParaBll.Instance.GetModel(Convert.ToInt32(worksTable.Rows[i]["WorksType"]))?.RefText;
                }
                if (worksTable.Rows[i]["type2"].ToString() != "")
                {
                    worksTable.Rows[i]["type2"] = SysParaBll.Instance.GetModel(Convert.ToInt32(worksTable.Rows[i]["type2"]))?.RefText;
                }
                if (worksTable.Rows[i]["cover"].ToString() != "")
                {
                    worksTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(worksTable.Rows[i]["cover"])).ImgUrl;
                }
            }
            DataTableModels dataTableModels = new DataTableModels
            {
                Dt = worksTable,
                Status = StatusEnum.success
            };
            return dataTableModels;
        }

        /// <summary>
        /// 根据userid获得作品
        /// api/Works/GetWorkByUserId?uid={4}&amp;num={10}
        /// </summary>
        /// <param name="uid">会员id</param>
        /// <param name="num">数量</param>
        /// <returns></returns>
        // GET api/Works/GetWorkByUserId?uid=4&num=10
        [AcceptVerbs("GET")]
        public object GetWorkByUserId(string uid,int num)
        {

            DataTable worksTable = WorksBll.Instance.GetList(num, $"Status>0 AND User_id='{uid}'", "ReleaseTime DESC,WorksId DESC");
            //获得类型、封面
            for (int i = 0; i < worksTable.Rows.Count; i++)
            {
                if (worksTable.Rows[i]["WorksType"].ToString() != "")
                {
                    worksTable.Rows[i]["WorksType"] = SysParaBll.Instance.GetModel(Convert.ToInt32(worksTable.Rows[i]["WorksType"]))?.RefText;
                }
                if (worksTable.Rows[i]["type2"].ToString() != "")
                {
                    worksTable.Rows[i]["type2"] = SysParaBll.Instance.GetModel(Convert.ToInt32(worksTable.Rows[i]["type2"]))?.RefText;
                }
                if (worksTable.Rows[i]["cover"].ToString() != "")
                {
                    worksTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(worksTable.Rows[i]["cover"])).ImgUrl;
                }
            }
            DataTableModels dataTableModels = new DataTableModels
            {
                Dt = worksTable,
                Status = StatusEnum.success
            };
            return dataTableModels;
        }
    }
}