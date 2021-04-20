using System.Data;
using System.Runtime.Serialization;

namespace Api.Models
{
    /// <summary>
    /// 分页数据操作返回的模型
    /// </summary>
    [DataContract]
    [KnownType(typeof(DataTablePageModels))]
    [KnownType(typeof(DataTable))]
    [KnownType(typeof(StatusEnum))]
    public class DataTablePageModels
    {
        private int _currentPage;  //当前页
        private string _typeValue;
        private int _pageSize;  //每页行数
        private int _pageStartRow;  //开始行数
        private int _pageEndRow;  //结束行数
        private int _nextPage;  //下一页
        private int _totalRowsAmount;  //总行数
        private int _totalPages;   //总页数
        private bool _hasNext;  //下一页
        private int _previousPage;  //上一页
        private bool _hasPrevious;  //上一页
        private DataTable _dt;
        private StatusEnum _status;
        /// <summary>
        /// 当前页
        /// </summary>
        [DataMember]
        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }

            set
            {
                _currentPage = value;
            }
        }
        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
        public string TypeValue
        {
            get
            {
                return _typeValue;
            }

            set
            {
                _typeValue = value;
            }
        }
        /// <summary>
        /// 每页行数
        /// </summary>
        [DataMember]
        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                _pageSize = value;
            }
        }
        /// <summary>
        /// 开始行数
        /// </summary>
        [DataMember]
        public int PageStartRow
        {
            get
            {
                return _pageStartRow;
            }

            set
            {
                _pageStartRow = value;
            }
        }
        /// <summary>
        /// 结束行数
        /// </summary>
        [DataMember]
        public int PageEndRow
        {
            get
            {
                return _pageEndRow;
            }

            set
            {
                _pageEndRow = value;
            }
        }
        /// <summary>
        /// 下一页
        /// </summary>
        [DataMember]
        public int NextPage
        {
            get
            {
                return _nextPage;
            }

            set
            {
                _nextPage = value;
            }
        }
        /// <summary>
        /// 总行数
        /// </summary>
        [DataMember]
        public int TotalRowsAmount
        {
            get
            {
                return _totalRowsAmount;
            }

            set
            {
                _totalRowsAmount = value;
            }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        [DataMember]
        public int TotalPages
        {
            get
            {
                return _totalPages;
            }

            set
            {
                _totalPages = value;
            }
        }
        /// <summary>
        /// 下一页
        /// </summary>
        [DataMember]
        public bool HasNext
        {
            get
            {
                return _hasNext;
            }

            set
            {
                _hasNext = value;
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        [DataMember]
        public int PreviousPage
        {
            get
            {
                return _previousPage;
            }

            set
            {
                _previousPage = value;
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        [DataMember]
        public bool HasPrevious
        {
            get
            {
                return _hasPrevious;
            }

            set
            {
                _hasPrevious = value;
            }
        }
        [DataMember]
        public DataTable Dt
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
        /// <summary>
        /// 状态码
        /// </summary>
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