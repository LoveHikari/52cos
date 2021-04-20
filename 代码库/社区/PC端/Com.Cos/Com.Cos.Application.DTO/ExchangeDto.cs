using System;
using System.Collections.Generic;

namespace Com.Cos.Application.DTO
{
    public class ExchangeDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 物品角色
        /// </summary>
        public string ItemCharacter { get; set; }
        /// <summary>
        /// 图片列表字符串
        /// </summary>
        public string ImgList { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public List<ImgDto> ImgDtoList { get; set; }
        /// <summary>
        /// 服装组成
        /// </summary>
        public string Constitute { get; set; }
        /// <summary>
        /// 物品来源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 分类Id
        /// </summary>
        public int ClassId { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 状态Id
        /// </summary>
        public int ExamineId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string ExamineName { get; set; }
        /// <summary>
        /// 最终值
        /// </summary>
        public string Official { get; set; }
        public int Status { get; set; }
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int CommentNum { get; set; }
        /// <summary>
        /// 是否关注
        /// </summary>
        public bool Heed { get; set; }
        /// <summary>
        /// 关注人员
        /// </summary>
        public string LikeUser { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Portrait { get; set; }
        /// <summary>
        /// 个人描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 物流运单号
        /// </summary>
        public string LogisticCode { get; set; }
        /// <summary>
        /// 尺码
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal Postage { get; set; }
        /// <summary>
        /// 租金
        /// </summary>
        public decimal Rent { get; set; }
    }
}