using NLog;
using System;

namespace FATC.Common.Logger
{
    public class NLogManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public NLogManager()
        {
        }

        public void Log(LogType logType, Exception ex)
        {
            //Exception e = new Exception();

            //if (ex != null)
            //    e = ex.GetInnerException();

            switch (logType)
            {
                case LogType.INFO:
                    logger.Info(ex, ex.Message);
                    break;
                case LogType.ERROR:
                    logger.Error(ex, ex.Message);
                    break;
                case LogType.DEBUG:
                    logger.Debug(ex, ex.Message);
                    break;
                case LogType.WARNING:
                    logger.Warn(ex, ex.Message);
                    break;
                default:
                    break;
            }
        }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogError(string message, Exception ex)
        {
            logger.Error(ex, message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
