using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Models
{
    /// <summary>
    /// MailingAddressEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// 通讯地址表
    /// </summary>
    [Serializable, Table("sns_mailingAddress")]
    public class MailingAddress
    {
        public MailingAddress()
        { }
        #region Model
        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 会员id
        /// </summary>
        public string UserId { set; get; }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { set; get; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { set; get; }

        /// <summary>
        /// 区/县
        /// </summary>
        public string County { set; get; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZipCode { set; get; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int Status { set; get; }

        #endregion Model
    }
}