using System;

namespace Com.Cos.Entity
{
    /// <summary>
    /// RewardEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RewardEntity
    {
        public RewardEntity()
        { }
        #region Model
        private int _id;
        private string _user_id;
        private string _worksid;
        private decimal? _rewardmoney;
        private int _status = 1;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 打赏会员id
        /// </summary>
        public string User_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 被打赏帖子id
        /// </summary>
        public string worksId
        {
            set { _worksid = value; }
            get { return _worksid; }
        }
        /// <summary>
        /// 打赏金额
        /// </summary>
        public decimal? rewardMoney
        {
            set { _rewardmoney = value; }
            get { return _rewardmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model

    }
}

