using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Cos.Domain.Entity
{
    /// <summary>
    /// 会员表
    /// </summary>
    [Serializable, Table("cos_member")]
    public partial class Member : IAggregateRoot
    {
        public Member()
        { }
        #region Model
        /// <summary>
        /// 
        /// </summary>
        [Key,Column("User_id")]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "User_id")]
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "用户名")]
        public string User_name { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Column]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "密码")]
        public string Password { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "真实姓名")]
        public string Real_name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "性别")]
        public string Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "生日")]
        public string Birthday { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "电话")]
        public string Phone_tel { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "手机")]
        public string Phone_mob { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "QQ")]
        public string Im_qq { get; set; }
        /// <summary>
        /// MSN
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "MSN")]
        public string Im_msn { get; set; }
        /// <summary>
        /// SKYPE
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "SKYPE")]
        public string In_skype { get; set; }
        /// <summary>
        /// 雅虎
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "雅虎")]
        public string Im_yahoo { get; set; }
        /// <summary>
        /// 阿里旺旺
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "阿里旺旺")]
        public string Im_aliww { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "微信")]
        public string ImWechat { get; set; }
        /// <summary>
        /// 新浪
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "新浪")]
        public string ImSina { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        [Column]
        [Display(Name = "注册时间")]
        public DateTime? Reg_time { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Column]
        [Display(Name = "最后登录时间")]
        public DateTime? Last_login { get; set; }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "最后登录IP")]
        public string Last_ip { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        [Column]
        [DefaultValue(0)]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "登录次数")]
        public int Logins { get; set; }
        /// <summary>
        /// 会员级别
        /// </summary>
        [Column]
        [DefaultValue(1)]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "会员级别")]
        public int Ugrade { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        [Column]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "头像地址")]
        public string Portrait { get; set; }
        /// <summary>
        /// 登出ID
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "登出ID")]
        public string Outer_id { get; set; }
        /// <summary>
        /// 激活
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "激活")]
        public string Activation { get; set; }
        /// <summary>
        /// 订阅配置
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "订阅配置")]
        public string Feed_config { get; set; }
        /// <summary>
        /// 启用状态
        /// </summary>
        [Column]
        [DefaultValue(1)]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "启用状态")]
        public int Status { get; set; }
        /// <summary>
        /// 总打赏数
        /// </summary>
        [Column]
        [DefaultValue(0)]
        [Display(Name = "总打赏数")]
        public int? Reward { get; set; }
        /// <summary>
        /// CN币
        /// </summary>
        [Column]
        [DefaultValue(0)]
        [Display(Name = "CN币")]
        public int? CNbi { get; set; }
        /// <summary>
        /// 节操
        /// </summary>
        [Column]
        [DefaultValue(0)]
        [Required(ErrorMessage = "必填", AllowEmptyStrings = true)]
        [Display(Name = "节操")]
        public int Integral { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "昵称")]
        public string Nickname { get; set; }
        /// <summary>
        /// 热心
        /// </summary>
        [Column]
        [Display(Name = "热心")]
        public int? Ardent { get; set; }
        /// <summary>
        /// 会员成长值
        /// </summary>
        [Column]
        [Display(Name = "会员成长值")]
        public int? Growth { get; set; }
        /// <summary>
        /// 邮箱验证code
        /// </summary>
        [Column]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "邮箱验证code")]
        public string Code { get; set; }
        /// <summary>
        /// 个人描述
        /// </summary>
        [Column]
        [StringLength(2147483647, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "个人描述")]
        public string Describe { get; set; }
        /// <summary>
        /// 身价
        /// </summary>
        [Column]
        [Display(Name = "身价")]
        public Decimal? Shenjia { get; set; }
        /// <summary>
        /// 豆子
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "豆子")]
        public string Bean { get; set; }
        /// <summary>
        /// 会员开始时间
        /// </summary>
        [Column]
        [Display(Name = "会员开始时间")]
        public DateTime? Stime { get; set; }
        /// <summary>
        /// 会员结束时间
        /// </summary>
        [Column]
        [Display(Name = "会员结束时间")]
        public DateTime? Etime { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        [Column]
        [Display(Name = "会员等级")]
        public int? Lv { get; set; }
        /// <summary>
        /// 兑换次数总数
        /// </summary>
        [Column]
        [Display(Name = "兑换次数总数")]
        public int? Conversions { get; set; }
        /// <summary>
        /// 剩余兑换次数
        /// </summary>
        [Column]
        [Display(Name = "剩余兑换次数")]
        public int? RemainingConversions { get; set; }
        /// <summary>
        /// 押金
        /// </summary>
        [Column]
        [Display(Name = "押金")]
        public Decimal? Deposit { get; set; }
        /// <summary>
        /// 融云token
        /// </summary>
        [Column]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "融云token")]
        public string RongToken { get; set; }
        /// <summary>
        /// 支付宝账号
        /// </summary>
        [Column]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "{2}到{1}个字符")]
        [Display(Name = "支付宝账号")]
        public string ImAlipay { get; set; }
        #endregion Model

    }
}