using System;

namespace Entity
{
    /// <summary>
    /// MemberEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class MemberEntity
    {
        public MemberEntity()
        { }
        #region Model
        private int _user_id = 0;
        private string _user_name = "";
        private string _email = "";
        private string _password = "";
        private string _real_name = "";
        private string _gender = "";
        private string _birthday = "";
        private string _phone_tel = "";
        private string _phone_mob = "";
        private string _im_qq = "";
        private string _im_msn = "";
        private string _in_skype = "";
        private string _im_yahoo = "";
        private string _im_aliww = "";
        private DateTime? _reg_time = null;
        private DateTime? _last_login = null;
        private string _last_ip = "";
        private int _logins = 0;
        private int _ugrade = 1;
        private string _portrait = "";
        private string _outer_id = "";
        private string _activation = "";
        private string _feed_config = "";
        private int _status = 1;
        private int? _reward = 0;
        private int? _cnbi = 0;
        private int _integral = 0;
        private string _nickname = "";
        private int? _ardent = 0;
        private int? _growth = 0;
        private string _code = "";
        /// <summary>
        /// 
        /// </summary>
        public int User_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string User_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Real_name
        {
            set { _real_name = value; }
            get { return _real_name; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone_tel
        {
            set { _phone_tel = value; }
            get { return _phone_tel; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone_mob
        {
            set { _phone_mob = value; }
            get { return _phone_mob; }
        }
        /// <summary>
        /// QQ
        /// </summary>
        public string Im_qq
        {
            set { _im_qq = value; }
            get { return _im_qq; }
        }
        /// <summary>
        /// MSN
        /// </summary>
        public string Im_msn
        {
            set { _im_msn = value; }
            get { return _im_msn; }
        }
        /// <summary>
        /// SKYPE
        /// </summary>
        public string In_skype
        {
            set { _in_skype = value; }
            get { return _in_skype; }
        }
        /// <summary>
        /// 雅虎
        /// </summary>
        public string Im_yahoo
        {
            set { _im_yahoo = value; }
            get { return _im_yahoo; }
        }
        /// <summary>
        /// 阿里旺旺
        /// </summary>
        public string Im_aliww
        {
            set { _im_aliww = value; }
            get { return _im_aliww; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? Reg_time
        {
            set { _reg_time = value; }
            get { return _reg_time; }
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? Last_login
        {
            set { _last_login = value; }
            get { return _last_login; }
        }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string Last_ip
        {
            set { _last_ip = value; }
            get { return _last_ip; }
        }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int Logins
        {
            set { _logins = value; }
            get { return _logins; }
        }
        /// <summary>
        /// 会员级别
        /// </summary>
        public int Ugrade
        {
            set { _ugrade = value; }
            get { return _ugrade; }
        }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string Portrait
        {
            set { _portrait = value; }
            get { return _portrait; }
        }
        /// <summary>
        /// 登出ID
        /// </summary>
        public string Outer_id
        {
            set { _outer_id = value; }
            get { return _outer_id; }
        }
        /// <summary>
        /// 激活
        /// </summary>
        public string Activation
        {
            set { _activation = value; }
            get { return _activation; }
        }
        /// <summary>
        /// 订阅配置
        /// </summary>
        public string Feed_config
        {
            set { _feed_config = value; }
            get { return _feed_config; }
        }
        /// <summary>
        /// 启用状态
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 总打赏数
        /// </summary>
        public int? reward
        {
            set { _reward = value; }
            get { return _reward; }
        }
        /// <summary>
        /// CN币
        /// </summary>
        public int? CNbi
        {
            set { _cnbi = value; }
            get { return _cnbi; }
        }
        /// <summary>
        /// 节操
        /// </summary>
        public int integral
        {
            set { _integral = value; }
            get { return _integral; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nickname
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 热心
        /// </summary>
        public int? ardent
        {
            set { _ardent = value; }
            get { return _ardent; }
        }
        /// <summary>
        /// 会员成长值
        /// </summary>
        public int? Growth
        {
            set { _growth = value; }
            get { return _growth; }
        }
        /// <summary>
        /// 邮箱验证code
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        #endregion Model

    }
}

