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
    /// 回复（讨论）
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class ReplyController : ApiController
    {
        /// <summary>
        /// 评论分页
        /// api/Reply/GetReplyByPage?typeValue={works}&amp;workId={1}&amp;currentPage={1}
        /// </summary>
        /// <param name="typeValue">类型  类型的可取值：作品（works）活动（activity）合作（reprint）</param>
        /// <param name="workId">文章id</param>
        /// <param name="currentPage">当前页</param>
        /// <returns></returns>
        // GET api/Reply/GetReplyByPage?typeValue=works&workId=1?currentPage=1
        [AcceptVerbs("GET")]
        public object GetReplyByPage(string typeValue,string workId, int currentPage)
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

            string strWhere = $"Status='1' and type='{typeValue}' and workId='{workId}'";
            totalRowsAmount = ReplyBll.Instance.GetRecordCount(strWhere);
            DataTable worksTable = ReplyBll.Instance.GetListByPage(strWhere, "ReleaseTime desc,ReplyId desc", pageStartRow, pageEndRow).Tables[0];

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

        /// <summary>
        /// 评论,例
        /// api/Reply/PostComment?uid={30}&amp;cv={works}&amp;aid={1}      body: "1"
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="cv">类型,类型的可取值：作品（works）活动（activity）合作（reprint）,兑换(share)</param>
        /// <param name="aid">文章id</param>
        /// <param name="cont">评论内容，不要超过150个字</param>
        /// <returns></returns>
        // POST api/Reply/PostComment?uid=30&cv=works&aid=1
        [AcceptVerbs("POST")]
        public object PostComment(string uid, string cv, string aid, [FromBody]string cont)
        {
            string userId = uid;
            string type = cv;
            string workId = aid;
            string replyContent = cont;
            int i = -1;
            ReplyEntity replyEntity = new ReplyEntity();
            replyEntity.User_id = userId;
            replyEntity.type = type;
            replyEntity.workId = workId;
            replyEntity.ReplyContent = replyContent;
            replyEntity.ReleaseTime = DateTime.Now;
            //插入回复表
            if (ReplyBll.Instance.Add(replyEntity) > 0)
            {
                //更新作品时间
                if (cv == "works")
                {
                    WorksEntity worksEntity = WorksBll.Instance.GetModel(int.Parse(aid));
                    worksEntity.UpdateTime = DateTime.Now;
                    WorksBll.Instance.Update(worksEntity);
                }

                return new Dictionary<string, StatusEnum> {{"Status", StatusEnum.success}};
            }
            else
            {
                return new Dictionary<string, StatusEnum> { { "Status", StatusEnum.error } };
            }
        }

        /// <summary>
        /// 根据userid获得评论
        /// api/Works/GetReplyByUserId?userId={4}&amp;num={10}
        /// </summary>
        /// <param name="userId">会员id</param>
        /// <param name="num">数量</param>
        /// <returns></returns>
        // get api/Works/GetReplyByUserId?userId=4&num=10
        [AcceptVerbs("GET")]
        public object GetReplyByUserId(string userId,int num)
        {

            DataTable worksTable = ReplyBll.Instance.GetList(num, $"User_id='{userId}' AND Status>0 ", "ReleaseTime desc,ReplyId desc");

            DataTableModels dataTableModels = new DataTableModels
            {
                Dt = worksTable,
                Status = StatusEnum.success
            };
            return dataTableModels;
        }
    }
}
