using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Db
{
    /// <summary>
    /// 数据访问类：充值交易记录表
    /// </summary>
    public class TransactionsDb
    {
        #region instance
        private volatile static TransactionsDb _instance = null;
        private static readonly object lockHelper = new object();
        private TransactionsDb() { }
        public static TransactionsDb Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new TransactionsDb();
                    }
                }
                return _instance;
            }
        }
        #endregion
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TransactionsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sns_transactions(");
            strSql.Append("UserId,NotifyTime,NotifyType,NotifyId,SignType,Sign,OutTradeNo,Subject,PaymentType,TradeNo,TradeStatus,GmtCreate,GmtPayment,GmtClose,SellerEmail,SellerId,BuyerEmail,BuyerId,TotalFee,Body,Discount,BusinessScene,ExtraCommonParam,Status)");
            strSql.Append(" values (");
            strSql.Append("@UserId,@NotifyTime,@NotifyType,@NotifyId,@SignType,@Sign,@OutTradeNo,@Subject,@PaymentType,@TradeNo,@TradeStatus,@GmtCreate,@GmtPayment,@GmtClose,@SellerEmail,@SellerId,@BuyerEmail,@BuyerId,@TotalFee,@Body,@Discount,@BusinessScene,@ExtraCommonParam,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.VarChar,50),
                    new SqlParameter("@NotifyTime", SqlDbType.DateTime),
                    new SqlParameter("@NotifyType", SqlDbType.VarChar,50),
                    new SqlParameter("@NotifyId", SqlDbType.VarChar,50),
                    new SqlParameter("@SignType", SqlDbType.VarChar,50),
                    new SqlParameter("@Sign", SqlDbType.VarChar,50),
                    new SqlParameter("@OutTradeNo", SqlDbType.VarChar,64),
                    new SqlParameter("@Subject", SqlDbType.VarChar,256),
                    new SqlParameter("@PaymentType", SqlDbType.VarChar,4),
                    new SqlParameter("@TradeNo", SqlDbType.VarChar,64),
                    new SqlParameter("@TradeStatus", SqlDbType.VarChar,50),
                    new SqlParameter("@GmtCreate", SqlDbType.DateTime),
                    new SqlParameter("@GmtPayment", SqlDbType.DateTime),
                    new SqlParameter("@GmtClose", SqlDbType.DateTime),
                    new SqlParameter("@SellerEmail", SqlDbType.VarChar,100),
                    new SqlParameter("@SellerId", SqlDbType.VarChar,30),
                    new SqlParameter("@BuyerEmail", SqlDbType.VarChar,100),
                    new SqlParameter("@BuyerId", SqlDbType.VarChar,30),
                    new SqlParameter("@TotalFee", SqlDbType.VarChar,50),
                    new SqlParameter("@Body", SqlDbType.VarChar,1000),
                    new SqlParameter("@Discount", SqlDbType.VarChar,50),
                    new SqlParameter("@BusinessScene", SqlDbType.VarChar,50),
                    new SqlParameter("@ExtraCommonParam", SqlDbType.Text),
                    new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = UtilityHelper.SqlNull(model.UserId);
            parameters[1].Value = UtilityHelper.SqlNull(model.NotifyTime);
            parameters[2].Value = UtilityHelper.SqlNull(model.NotifyType);
            parameters[3].Value = UtilityHelper.SqlNull(model.NotifyId);
            parameters[4].Value = UtilityHelper.SqlNull(model.SignType);
            parameters[5].Value = UtilityHelper.SqlNull(model.Sign);
            parameters[6].Value = UtilityHelper.SqlNull(model.OutTradeNo);
            parameters[7].Value = UtilityHelper.SqlNull(model.Subject);
            parameters[8].Value = UtilityHelper.SqlNull(model.PaymentType);
            parameters[9].Value = UtilityHelper.SqlNull(model.TradeNo);
            parameters[10].Value = UtilityHelper.SqlNull(model.TradeStatus);
            parameters[11].Value = UtilityHelper.SqlNull(model.GmtCreate);
            parameters[12].Value = UtilityHelper.SqlNull(model.GmtPayment);
            parameters[13].Value = UtilityHelper.SqlNull(model.GmtClose);
            parameters[14].Value = UtilityHelper.SqlNull(model.SellerEmail);
            parameters[15].Value = UtilityHelper.SqlNull(model.SellerId);
            parameters[16].Value = UtilityHelper.SqlNull(model.BuyerEmail);
            parameters[17].Value = UtilityHelper.SqlNull(model.BuyerId);
            parameters[18].Value = UtilityHelper.SqlNull(model.TotalFee);
            parameters[19].Value = UtilityHelper.SqlNull(model.Body);
            parameters[20].Value = UtilityHelper.SqlNull(model.Discount);
            parameters[21].Value = UtilityHelper.SqlNull(model.BusinessScene);
            parameters[22].Value = UtilityHelper.SqlNull(model.ExtraCommonParam);
            parameters[23].Value = UtilityHelper.SqlNull(model.Status);

            object obj = SqlHelper.Instance.ExecSqlScalar(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
    }
}