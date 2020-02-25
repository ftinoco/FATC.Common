namespace FATC.Common
{
    public class Result<TData> : BaseResult
    {
        public Result() : base()
        {
        }

        public Result(TData data) : base()
        {
            Data = data;
        }
        
        public TData Data { get; set; }
    }
}
