using System;
using System.Data;
using System.Reflection;
using System.Runtime.Serialization;
using Com.Cos.Entity;

namespace Api.Models
{
    /// <summary>
    /// 数据操作返回的模型
    /// </summary>
    [DataContract]
    [KnownType(typeof(DataTableModels))]
    [KnownType(typeof(DataTable))]
    [KnownType(typeof(WorksEntity))]
    [KnownType(typeof(ActivityEntity))]
    [KnownType(typeof(CooperationEntity))]
    [KnownType(typeof(MemberEntity))]
    [KnownType(typeof(ExchangeEntity))]
    [KnownType(typeof(StatusEnum))]
    public class DataTableModels
    {
        private object _dt;
        private StatusEnum _status;
        [DataMember]
        public object Dt
        {
            get
            {
                return _dt;
            }

            set
            {
                _dt = value;
            }
        }
        [DataMember]
        public StatusEnum Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

    }
}