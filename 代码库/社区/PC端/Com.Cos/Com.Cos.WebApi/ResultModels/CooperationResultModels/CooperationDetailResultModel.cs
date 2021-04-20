using System.Collections.Generic;
using Com.Cos.WebApi.Result.ImgResult;

namespace Com.Cos.WebApi.ResultModels.CooperationResultModels
{
    public class CooperationDetailResultModel
    {
        public int Id { get;set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 截止时间
        /// </summary>
        public string EnrollEnd { get; set; }
        /// <summary>
        /// 需求
        /// </summary>
        public string Will { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public List<ExchangeImgResultModel> ImgList { get; set; }
        /// <summary>
        /// 报名人数
        /// </summary>
        public int PersonNum { get; set; }
        /// <summary>
        /// 限制报名人数
        /// </summary>
        public int LimitPerson { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Portrait { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 个人描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 是否报名
        /// </summary>
        public bool Heed { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int CommentNum { get; set; }
        /// <summary>
        /// 分享url
        /// </summary>
        public string ShareURL { get; set; }
    }
}