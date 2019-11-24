using System;

namespace FATC.Common
{
    public class BaseResult
    {
        public BaseResult()
        {
            Message = " ";
            DetailException = null;
            ResultType = ResultType.SUCCESS;
        }

        public string Message { get; set; }

        public Exception DetailException { get; set; }

        public ResultType ResultType { get; set; }
    }
}