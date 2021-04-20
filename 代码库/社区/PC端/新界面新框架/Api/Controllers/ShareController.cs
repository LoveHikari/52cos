using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Api.Models;
using Com.Cos.Bll;
using Com.Cos.Entity;

namespace Api.Controllers
{
    /// <summary>
    /// 分享/兑换
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class ShareController : ApiController
    {
        /// <summary>
        /// 获得分享
        /// api/Share/GetShare?num={4}
        /// </summary>
        /// <param name="num">数量</param>
        /// <returns></returns>
        // GET api/Share/GetShare?num=4
        [AcceptVerbs("GET")]
        public object GetShare(int num)
        {
            DataTable shareTable = ExchangeBll.Instance.GetList2(num, "a.Status='1'", "a.addTime DESC,a.id DESC").Tables[0];  //分享
            //获得封面
            for (int i = 0; i < shareTable.Rows.Count; i++)
            {
                if (shareTable.Rows[i]["cover"].ToString() != "")
                {
                    shareTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["cover"]))?.ImgUrl;
                }
                if (shareTable.Rows[i]["Certificate"] != null && shareTable.Rows[i]["Certificate"].ToString() != "")
                {
                    shareTable.Rows[i]["Certificate"] = ImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["Certificate"]))?.ImgUrl;
                }
                if (shareTable.Rows[i]["Imgs"].ToString() != "")
                {
                    string[] imgIds = shareTable.Rows[i]["Imgs"].ToString().Split(',');
                    string imgs = "";
                    foreach (string imgId in imgIds)
                    {
                        ImgEntity imgEntity = ImgBll.Instance.GetModel(int.Parse(imgId));
                        imgs += imgEntity.ImgUrl + ",";
                    }
                    shareTable.Rows[i]["Imgs"] = imgs;
                }
            }
            return new DataTableModels()
            {
                Dt = shareTable,
                Status = StatusEnum.success
            };
        }
        /// <summary>
        /// 分享分页
        /// api/Share/GetShareByPage?currentPage={4}
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <returns></returns>
        // GET api/Share/GetShareByPage?currentPage=4
        [AcceptVerbs("GET")]
        public object GetShareByPage(int currentPage)
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

            totalRowsAmount = ExchangeBll.Instance.GetRecordCount("Status='1'");
            DataTable shareTable = ExchangeBll.Instance.GetListByPage2("t.Status='1'", "addTime DESC", pageStartRow, pageEndRow).Tables[0];
            //获得封面
            for (int i = 0; i < shareTable.Rows.Count; i++)
            {
                if (shareTable.Rows[i]["cover"].ToString() != "")
                {
                    shareTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["cover"]))?.ImgUrl;
                }
                if (shareTable.Rows[i]["Certificate"].ToString() != "")
                {
                    shareTable.Rows[i]["Certificate"] = ImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["Certificate"]))?.ImgUrl;
                }
                if (shareTable.Rows[i]["Imgs"].ToString() != "")
                {
                    string[] imgIds = shareTable.Rows[i]["Imgs"].ToString().Split(',');
                    string imgs = "";
                    foreach (string imgId in imgIds)
                    {
                        int imgid;
                        if (int.TryParse(imgId, out imgid))
                        {
                            ImgEntity imgEntity = ImgBll.Instance.GetModel(imgid);
                            imgs += imgEntity.ImgUrl + ",";
                        }
                        
                        
                    }
                    shareTable.Rows[i]["Imgs"] = imgs;
                }
            }
            totalPages = int.Parse(Math.Ceiling(totalRowsAmount / 10.0).ToString());
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
                Dt = shareTable,
                Status = StatusEnum.success
            };
            return dataTablePageModels;
        }
        /// <summary>
        /// 获得分享实体信息
        /// api/Share/GetShareEntity?eid={1}
        /// </summary>
        /// <param name="eid">兑换id</param>
        /// <returns></returns>
        // GET api/Share/GetShareEntity?eid=1
        [AcceptVerbs("GET")]
        public object GetShareEntity(int eid)
        {
            ExchangeEntity shaerEntity = ExchangeBll.Instance.GetModel(eid);
            
            if (shaerEntity == null)
            {
                return new KeyValuePair<string, StatusEnum>("status", StatusEnum.empty);
            }
            if (!string.IsNullOrWhiteSpace(shaerEntity.Cover))
            {
                shaerEntity.Cover = SmallImgBll.Instance.GetModel(Convert.ToInt32(shaerEntity.Cover))?.ImgUrl;
            }
            if (!string.IsNullOrWhiteSpace(shaerEntity.Certificate))
            {
                string[] imgIds = shaerEntity.Certificate.Split(',');
                string imgs = "";
                foreach (string imgId in imgIds)
                {
                    ImgEntity imgEntity = ImgBll.Instance.GetModel(int.Parse(imgId));
                    imgs += imgEntity.ImgUrl + ",";
                }
                shaerEntity.Certificate = imgs;
            }
            if (!string.IsNullOrWhiteSpace(shaerEntity.Imgs))
            {
                string[] imgIds = shaerEntity.Imgs.Split(',');
                string imgs = "";
                foreach (string imgId in imgIds)
                {
                    ImgEntity imgEntity = ImgBll.Instance.GetModel(int.Parse(imgId));
                    imgs += imgEntity.ImgUrl + ",";
                }
                shaerEntity.Imgs = imgs;
            }
            return new DataTableModels
            {
                Dt = shaerEntity,
                Status = StatusEnum.success
            };
        }

        /// <summary>
        /// 分享页估价投票
        /// api/Share/EvaluationVote?ind={1}&amp;eid={1}&amp;uid={1}
        /// </summary>
        /// <param name="ind">价格位置，1/2/3</param>
        /// <param name="eid">分享的id</param>
        /// <param name="uid">会员的id</param>
        /// <returns></returns>
        // POST api/Share/EvaluationVote?ind=1&eid=1&uid=1
        [AcceptVerbs("POST")]
        public object EvaluationVote(string ind,string eid,string uid)
        {

            KeyValuePair<string, string> s = new KeyValuePair<string, string>();
            DataTable exTable = ExchangeVoteBll.Instance.GetList($"UserId='{uid}' AND ExId='{eid}'").Tables[0];
            if (exTable.Rows.Count > 0)
            {
                s = new KeyValuePair<string, string>("status", "已参与");
            }
            else
            {
                ExchangeEntity exchangeEntity = ExchangeBll.Instance.GetModel(int.Parse(eid));
                switch (ind)
                {
                    case "1":
                        exchangeEntity.Vote1 = exchangeEntity.Vote1 + 1;
                        break;
                    case "2":
                        exchangeEntity.Vote2 = exchangeEntity.Vote2 + 1;
                        break;
                    case "3":
                        exchangeEntity.Vote3 = exchangeEntity.Vote3 + 1;
                        break;
                }
                if (ExchangeBll.Instance.Update(exchangeEntity))
                {
                    ExchangeVoteEntity exchangeVoteEntity = new ExchangeVoteEntity();
                    exchangeVoteEntity.UserId = uid;
                    exchangeVoteEntity.ExId = eid;
                    exchangeVoteEntity.AddTime = DateTime.Now;
                    exchangeVoteEntity.Status = 1;
                    if (ExchangeVoteBll.Instance.Add(exchangeVoteEntity) > 0)
                    {
                        s = new KeyValuePair<string, string>("status", "success");
                    }

                }
                else
                {
                    s = new KeyValuePair<string, string>("status", "error");
                }
            }
            return s;
        }

        /// <summary>
        /// 分享报名
        /// api/Share/ShareSignUp?uid={1}&amp;{1}
        /// </summary>
        /// <param name="uid">会员的id</param>
        /// <param name="eid">分享的id</param>
        /// <returns></returns>
        // POST api/Share/ShareSignUp/1/1
        [AcceptVerbs("POST")]
        public object ShareSignUp(string uid,string eid)
        {
            KeyValuePair<string,string> s = new KeyValuePair<string, string>("status", "error");
            ExchangePersonEntity exchangePersonEntity = new ExchangePersonEntity();
            exchangePersonEntity.UserId = uid;
            exchangePersonEntity.ExId = eid;
            exchangePersonEntity.AddTime = DateTime.Now;
            exchangePersonEntity.Examine = "0";
            exchangePersonEntity.Status = 1;
            if (ExchangePersonBll.Instance.Add(exchangePersonEntity) > 0)
            {
                s = new KeyValuePair<string, string>("status", "success");
            }
            return s;
        }
        /// <summary>
        /// 会员分享分页
        /// api/Share/GetShareByPage/{30}/{4}
        /// </summary>
        /// <param name="values">{会员id}/{当前页码}</param>
        /// <returns></returns>
        // GET api/Share/GetShareByPage/30/4
        [AcceptVerbs("GET")]
        public object GetShareByPage(string values)
        {
            string[] s = values.Split('/');
            string userId = s[0];

            string typeValue = "";  //类型
            int currentPage = int.Parse(s[1]);  //当前页
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
            DataTable shareTable = ExchangeBll.Instance.GetListByPage2("t.userId='"+userId+"' and t.Status='1'", "addTime DESC", pageStartRow, pageEndRow).Tables[0];
            //获得封面
            for (int i = 0; i < shareTable.Rows.Count; i++)
            {
                if (shareTable.Rows[i]["cover"].ToString() != "")
                {
                    shareTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["cover"]))?.ImgUrl;
                }
                if (shareTable.Rows[i]["Certificate"].ToString() != "")
                {
                    shareTable.Rows[i]["Certificate"] = ImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["Certificate"])).ImgUrl;
                }
                if (shareTable.Rows[i]["Imgs"].ToString() != "")
                {
                    string[] imgIds = shareTable.Rows[i]["Imgs"].ToString().Split(',');
                    string imgs = "";
                    foreach (string imgId in imgIds)
                    {
                        ImgEntity imgEntity = ImgBll.Instance.GetModel(int.Parse(imgId));
                        imgs += imgEntity.ImgUrl + ",";
                    }
                    shareTable.Rows[i]["Imgs"] = imgs;
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
                Dt = shareTable,
                Status = StatusEnum.success
            };
            return dataTablePageModels;
        }
        /// <summary>
        /// 获得会员分享
        /// api/Share/GetShare/{30}/{4}
        /// </summary>
        /// <param name="values">{会员id}/{数量}</param>
        /// <returns></returns>
        // GET api/Share/GetShare/30/4
        [AcceptVerbs("GET")]
        public object GetShare(string values)
        {
            string[] s = values.Split('/');
            string userId = s[0];
            int top = int.Parse(s[1]);
            DataTable shareTable = ExchangeBll.Instance.GetList2(top, "a.userId='"+userId+"' and a.Status='1'", "a.addTime DESC,a.id DESC").Tables[0];  //分享
            //获得封面
            for (int i = 0; i < shareTable.Rows.Count; i++)
            {
                if (shareTable.Rows[i]["cover"].ToString() != "")
                {
                    shareTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["cover"]))?.ImgUrl;
                }
                if (shareTable.Rows[i]["Certificate"].ToString() != "")
                {
                    shareTable.Rows[i]["Certificate"] = ImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["Certificate"]))?.ImgUrl;
                }
                if (shareTable.Rows[i]["Imgs"].ToString() != "")
                {
                    string[] imgIds = shareTable.Rows[i]["Imgs"].ToString().Split(',');
                    string imgs = "";
                    foreach (string imgId in imgIds)
                    {
                        ImgEntity imgEntity = ImgBll.Instance.GetModel(int.Parse(imgId));
                        imgs += imgEntity.ImgUrl + ",";
                    }
                    shareTable.Rows[i]["Imgs"] = imgs;
                }
            }
            return new DataTableModels()
            {
                Dt = shareTable,
                Status = StatusEnum.success
            };
        }

        /// <summary>
        /// 分享分页根据分类，例(新版本不用)
        /// api/Share/GetShareByClass/{分类id}/{4}
        /// </summary>
        /// <param name="values">{分类}/{当前页}，分类可根据获得兑换分类接口获得</param>
        /// <returns></returns>
        // GET api/Share/GetShareByClass/分类id/4
        [AcceptVerbs("GET")]
        public object GetShareByCladss(string values)
        {
            string[] s = values.Split('/');
            string typeValue = "";  //类型
            int currentPage = int.Parse(s[1]);  //当前页
            int pageSize = 10;  //每页行数
            int pageStartRow = (currentPage - 1) * pageSize + 1;  //开始行数
            int pageEndRow = currentPage * pageSize;  //结束行数
            int nextPage = currentPage + 1; //下一页
            int totalRowsAmount;  //总行数
            int totalPages;  //总页数
            bool hasNext;  //下一页
            int previousPage = currentPage - 1;  //上一页
            bool hasPrevious = previousPage >= 1;  //上一页

            totalRowsAmount = ExchangeBll.Instance.GetRecordCount("Status='1'");
            DataTable shareTable = ExchangeBll.Instance.GetListByPage2("t.Status='1'", "addTime DESC", pageStartRow, pageEndRow).Tables[0];
            //获得封面
            for (int i = 0; i < shareTable.Rows.Count; i++)
            {
                if (shareTable.Rows[i]["cover"].ToString() != "")
                {
                    shareTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["cover"]))?.ImgUrl;
                }
                if (shareTable.Rows[i]["Certificate"].ToString() != "")
                {
                    shareTable.Rows[i]["Certificate"] = ImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["Certificate"]))?.ImgUrl;
                }
                if (shareTable.Rows[i]["Imgs"].ToString() != "")
                {
                    string[] imgIds = shareTable.Rows[i]["Imgs"].ToString().Split(',');
                    string imgs = "";
                    foreach (string imgId in imgIds)
                    {
                        int imgid;
                        if (int.TryParse(imgId, out imgid))
                        {
                            ImgEntity imgEntity = ImgBll.Instance.GetModel(imgid);
                            imgs += imgEntity.ImgUrl + ",";
                        }


                    }
                    shareTable.Rows[i]["Imgs"] = imgs;
                }
            }
            totalPages = int.Parse(Math.Ceiling(totalRowsAmount / 10.0).ToString());
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
                Dt = shareTable,
                Status = StatusEnum.success
            };
            return dataTablePageModels;
        }

        /// <summary>
        /// 分享分页根据兑换状态和分类，例
        /// api/Share/GetShareByExamine/examine?eid={1}&amp;cid={1}&amp;p={1}
        /// </summary>
        /// <param name="values">examine</param>
        /// <param name="eid">兑换状态</param>
        /// <param name="cid">分类id</param>
        /// <param name="p">当前页</param>
        /// <returns></returns>
        // GET api/Share/GetShareByExamine/examine?eid=1&cid=1&p=1
        [AcceptVerbs("GET")]
        public object GetShareByExamine(string eid,string cid,string p)
        {
            string examine = eid; //兑换状态
            string classId = cid;  //分类
            int currentPage = int.Parse(p);  //当前页
            int pageSize = 10;  //每页行数
            int pageStartRow = (currentPage - 1) * pageSize + 1;  //开始行数
            int pageEndRow = currentPage * pageSize;  //结束行数
            int nextPage = currentPage + 1; //下一页
            int totalRowsAmount;  //总行数
            int totalPages;  //总页数
            bool hasNext;  //下一页
            int previousPage = currentPage - 1;  //上一页
            bool hasPrevious = previousPage >= 1;  //上一页

            StringBuilder strWhere = new StringBuilder("t.status=1 ");
            StringBuilder sb = new StringBuilder("status=1 ");
            if (!string.IsNullOrEmpty(classId) && classId != "0")
            {
                strWhere.Append(" and t.classid=" + classId);
                sb.Append(" and classid=" + classId);
            }
            if (!string.IsNullOrEmpty(examine) && examine != "0")
            {
                strWhere.Append(" and t.examine=" + examine);
                sb.Append(" and examine=" + examine);

            }
            totalRowsAmount = ExchangeBll.Instance.GetRecordCount(sb.ToString());
            DataTable shareTable = ExchangeBll.Instance.GetListByPage2(strWhere.ToString(), "addTime DESC", pageStartRow, pageEndRow).Tables[0];
            //获得封面
            for (int i = 0; i < shareTable.Rows.Count; i++)
            {
                if (shareTable.Rows[i]["cover"].ToString() != "")
                {
                    shareTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["cover"]))?.ImgUrl;
                }
                if (shareTable.Rows[i]["Certificate"].ToString() != "")
                {
                    shareTable.Rows[i]["Certificate"] = ImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["Certificate"]))?.ImgUrl;
                }
                if (shareTable.Rows[i]["Imgs"].ToString() != "")
                {
                    string[] imgIds = shareTable.Rows[i]["Imgs"].ToString().Split(',');
                    string imgs = "";
                    foreach (string imgId in imgIds)
                    {
                        int imgid;
                        if (int.TryParse(imgId, out imgid))
                        {
                            ImgEntity imgEntity = ImgBll.Instance.GetModel(imgid);
                            imgs += imgEntity.ImgUrl + ",";
                        }


                    }
                    shareTable.Rows[i]["Imgs"] = imgs;
                }
            }
            totalPages = int.Parse(Math.Ceiling(totalRowsAmount / 10.0).ToString());
            hasNext = nextPage <= totalPages;

            DataTablePageModels dataTablePageModels = new DataTablePageModels
            {
                CurrentPage = currentPage,
                TypeValue = classId,
                PageSize = pageSize,
                PageStartRow = pageStartRow,
                PageEndRow = pageEndRow,
                NextPage = nextPage,
                TotalRowsAmount = totalRowsAmount,
                TotalPages = totalPages,
                HasNext = hasNext,
                PreviousPage = previousPage,
                HasPrevious = hasPrevious,
                Dt = shareTable,
                Status = StatusEnum.success
            };
            return dataTablePageModels;
        }

        /// <summary>
        /// 搜索分享，例
        /// api/Share/ShareSearch/search?sea={sea}&amp;p={1}
        /// </summary>
        /// <param name="values">固定写search</param>
        /// <param name="sea">搜索的关键词</param>
        /// <param name="p">当前页码</param>
        /// <returns></returns>
        // GET api/Share/ShareSearch/search?sea=sea&p=1
        [AcceptVerbs("GET")]
        public object ShareSearch(string sea,string p)
        {
            int currentPage = int.Parse(p);  //当前页
            int pageSize = 10;  //每页行数
            int pageStartRow = (currentPage - 1) * pageSize + 1;  //开始行数
            int pageEndRow = currentPage * pageSize;  //结束行数
            int nextPage = currentPage + 1; //下一页
            int totalRowsAmount;  //总行数
            int totalPages;  //总页数
            bool hasNext;  //下一页
            int previousPage = currentPage - 1;  //上一页
            bool hasPrevious = previousPage >= 1;  //上一页

            StringBuilder strWhere = new StringBuilder("t.status=1 ");
            StringBuilder sb = new StringBuilder("status=1 ");
            if (!string.IsNullOrEmpty(sea))
            {
                strWhere.Append("and t.title like '%" + sea + "%'");
                sb.Append("and title like '%" + sea + "%'");
            }

            totalRowsAmount = ExchangeBll.Instance.GetRecordCount(sb.ToString());
            DataTable shareTable = ExchangeBll.Instance.GetListByPage2(strWhere.ToString(), "addTime DESC", pageStartRow, pageEndRow).Tables[0];
            //获得封面
            for (int i = 0; i < shareTable.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(shareTable.Rows[i]["cover"].ToString()))
                {
                    shareTable.Rows[i]["cover"] = SmallImgBll.Instance.GetModel(Convert.ToInt32(shareTable.Rows[i]["cover"]))?.ImgUrl;
                }
                if (!string.IsNullOrEmpty(shareTable.Rows[i]["Certificate"].ToString()))
                {
                    string[] imgIds = shareTable.Rows[i]["Certificate"].ToString().Split(',');
                    string imgs = "";
                    foreach (string imgId in imgIds)
                    {
                        int imgid;
                        if (int.TryParse(imgId, out imgid))
                        {
                            ImgEntity imgEntity = ImgBll.Instance.GetModel(imgid);
                            imgs += imgEntity.ImgUrl + ",";
                        }


                    }
                    shareTable.Rows[i]["Certificate"] = imgs;
                }
                if (!string.IsNullOrEmpty(shareTable.Rows[i]["Imgs"].ToString()))
                {
                    string[] imgIds = shareTable.Rows[i]["Imgs"].ToString().Split(',');
                    string imgs = "";
                    foreach (string imgId in imgIds)
                    {
                        int imgid;
                        if (int.TryParse(imgId, out imgid))
                        {
                            ImgEntity imgEntity = ImgBll.Instance.GetModel(imgid);
                            imgs += imgEntity.ImgUrl + ",";
                        }


                    }
                    shareTable.Rows[i]["Imgs"] = imgs;
                }
            }
            totalPages = int.Parse(Math.Ceiling(totalRowsAmount / 10.0).ToString());
            hasNext = nextPage <= totalPages;

            DataTablePageModels dataTablePageModels = new DataTablePageModels
            {
                CurrentPage = currentPage,
                TypeValue = "",
                PageSize = pageSize,
                PageStartRow = pageStartRow,
                PageEndRow = pageEndRow,
                NextPage = nextPage,
                TotalRowsAmount = totalRowsAmount,
                TotalPages = totalPages,
                HasNext = hasNext,
                PreviousPage = previousPage,
                HasPrevious = hasPrevious,
                Dt = shareTable,
                Status = StatusEnum.success
            };
            return dataTablePageModels;
        }

        /// <summary>
        /// 保存兑换
        /// api/Share/SaveShare
        /// </summary>
        /// <param name="exchangeEntity"></param>
        /// <returns>{"status":"200"}{"status":"400","message":"保存失败"}</returns>
        [AcceptVerbs("POST")]
        // POST api/Share/SaveShare
        public object SaveShare([FromBody]ExchangeEntity exchangeEntity)
        {
            exchangeEntity.Vote1 = 0;
            exchangeEntity.Vote2 = 0;
            exchangeEntity.Vote3 = 0;
            exchangeEntity.AddTime = DateTime.Now;
            exchangeEntity.EnterTime = null;
            exchangeEntity.Examine = "1";
            exchangeEntity.Status = 1;
            if (ExchangeBll.Instance.Add(exchangeEntity) > 0)
            {
                return new Dictionary<string, string>() { { "status", "200" } };
            }
            else
            {
                return new Dictionary<string, string>() { { "status", "400" }, { "message", "保存失败" } };
            }
        }
    }
}
