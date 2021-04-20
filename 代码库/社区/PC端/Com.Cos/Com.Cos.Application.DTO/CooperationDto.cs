using System;
using System.Collections.Generic;

namespace Com.Cos.Application.DTO
{
    /// <summary>
    /// 合作数据传输对象
    /// </summary>
    public class CooperationDto
    {
        /// <summary>
        /// 合作id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 发布会员id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; set; }

        /// <summary>
        /// 图片列表
        /// </summary>
        public string ImgList { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public List<ImgDto> ImgDtoList { get; set; }
        /// <summary>
        /// 活动时间
        /// </summary>
        public DateTime EnrollEnd { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Portrait { get; set; }
        /// <summary>
        /// 个人描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 需求
        /// </summary>
        public string Will { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Prov { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区/县
        /// </summary>
        public string Dist { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 限制人数
        /// </summary>
        public int LimitPerson { get; set; }
        /// <summary>
        /// 报名人员
        /// </summary>
        public string SignPerson { get; set; }
        /// <summary>
        /// 报名人数
        /// </summary>
        public int PersonNum { get; set; }
        /// <summary>
        /// 是否报名
        /// </summary>
        public bool Heed { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int CommentNum { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 分类id
        /// </summary>
        public int ClassId { get; set; }
    }
}