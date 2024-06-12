namespace platform.empty.ApiContract.Contract
{
    public class ResponseBaseMessage
    {
        public bool Success { get; set; }

        public string MessageCode { get; set; }

        public string Message { get; set; }

        public string UserMessage { get; set; }

        public bool FromCache { get; set; }
    }
}
