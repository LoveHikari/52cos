using Com.Cos.Infrastructure;

namespace Com.Cos.Admin.Models
{
    public class MessageBase
    {
        private string _status = Permanent.SUCCESS;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
            }
        }

        public string Message { get; set; }
    }
}