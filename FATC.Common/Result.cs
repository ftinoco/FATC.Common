namespace FATC.Common
{
    public class Result<TData> : BaseResult
    {
        public Result() : base()
        {
        }

        public TData Data { get; set; }
    }
}
