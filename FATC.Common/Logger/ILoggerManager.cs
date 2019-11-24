using System;
using System.Collections.Generic;
using System.Text;

namespace FATC.Common.Logger
{
    public interface ILoggerManager
    {
        void LogInfo(string message);

        void LogWarn(string message);

        void LogDebug(string message);

        void LogError(string message);

        void Log(LogType logType, Exception ex);

        void LogError(string message, Exception ex);

    }
}
