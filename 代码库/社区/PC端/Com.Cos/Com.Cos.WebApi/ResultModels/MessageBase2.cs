namespace Com.Cos.WebApi.ResultModels
{
    public class MessageBase2
    {
        private string _success = "true";
        public string Success
        {
            get => _success;
            set => _success = value;
        }

        private int _error = 200;
        public int Error
        {
            get => _error;
            set => _error = value;
        }

        public string ErrorMsg { get; set; }

        public object Data { get; set; }
    }
}