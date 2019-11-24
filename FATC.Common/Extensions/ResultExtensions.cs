using FATC.Common.Logger;
using FATC.Common.WebUseful;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FATC.Common.Extensions
{
    public static class ResultExtensions
    {
        public static WebApiResult<List<T>> ConvertToWebApiResultList<T>(this Result<List<T>> lstResult, ILoggerManager logger)
        {
            WebApiResult<List<T>> webApiResult = new WebApiResult<List<T>>();
            switch (lstResult.ResultType)
            {
                case ResultType.INFO:
                    webApiResult.ResponseCode = HttpStatusCode.BadRequest;
                    logger.LogInfo(lstResult.Message);
                    break;
                case ResultType.ERROR:
                    webApiResult.ResponseCode = HttpStatusCode.InternalServerError;
                    logger.LogError(lstResult.Message, lstResult.DetailException);
                    break;
                case ResultType.SUCCESS:
                    webApiResult.ResponseCode = HttpStatusCode.OK;
                    logger.LogInfo(lstResult.Message);
                    break;
                case ResultType.WARNING:
                    webApiResult.ResponseCode = HttpStatusCode.NotFound;
                    logger.LogWarn(lstResult.Message);
                    break;
                default:
                    break;
            }

            webApiResult.Data = lstResult.Data;
            webApiResult.Message = lstResult.Message;

            return webApiResult;
        }

        public static WebApiResult<T> ConvertToWebApiResult<T>(this Result<T> result, ILoggerManager logger)
        {
            WebApiResult<T> webApiResult = new WebApiResult<T>();
            switch (result.ResultType)
            {
                case ResultType.INFO:
                    webApiResult.ResponseCode = HttpStatusCode.BadRequest;
                    logger.LogInfo(result.Message);
                    break;
                case ResultType.ERROR:
                    webApiResult.ResponseCode = HttpStatusCode.InternalServerError;
                    logger.LogError(result.Message, result.DetailException);
                    break;
                case ResultType.SUCCESS:
                    webApiResult.ResponseCode = HttpStatusCode.OK;
                    logger.LogInfo(result.Message);
                    break;
                case ResultType.WARNING:
                    webApiResult.ResponseCode = HttpStatusCode.NotFound;
                    logger.LogWarn(result.Message);
                    break;
                default:
                    break;
            }

            webApiResult.Data = result.Data;
            webApiResult.Message = result.Message;

            return webApiResult;
        }

        public static BaseWebApiResult ConvertToWebApiResult(this BaseResult result, ILoggerManager logger)
        {
            BaseWebApiResult webApiResult = new BaseWebApiResult();
            switch (result.ResultType)
            {
                case ResultType.INFO:
                    webApiResult.Message = result.Message;
                    webApiResult.ResponseCode = HttpStatusCode.BadRequest;
                    logger.LogInfo(result.Message);
                    break;
                case ResultType.ERROR:
                    webApiResult.Message = result.Message;
                    webApiResult.ResponseCode = HttpStatusCode.InternalServerError;
                    logger.LogError(result.Message, result.DetailException);
                    break;
                case ResultType.SUCCESS:
                    webApiResult.Message = result.Message;
                    webApiResult.ResponseCode = HttpStatusCode.OK;
                    logger.LogInfo(result.Message);
                    break;
                case ResultType.WARNING:
                    webApiResult.Message = result.Message;
                    webApiResult.ResponseCode = HttpStatusCode.NotFound;
                    logger.LogWarn(result.Message);
                    break;
                default:
                    break;
            }
            return webApiResult;
        }
    }
}
