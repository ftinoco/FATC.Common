using log4net;
using System;
using System.Reflection;

namespace FATC.Common.Logger
{
    public class Log4NetManager : ILoggerManager
    {
        private static ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Log4NetManager()
        {
        }

        public void Log(LogType logType, Exception ex)
        {
            switch (logType)
            {
                case LogType.INFO:
                    logger.Info(ex.Message, ex);
                    break;
                case LogType.ERROR:
                    logger.Error(ex.Message, ex);
                    break;
                case LogType.DEBUG:
                    logger.Debug(ex.Message, ex);
                    break;
                case LogType.WARNING:
                    logger.Warn(ex.Message, ex);
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
            logger.Error(message, ex);
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
