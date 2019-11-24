using System;
using System.Collections.Generic;
using System.Text;

namespace FATC.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static int GetLineNumber(this Exception e)
        {
            int linenum = 0;
            try
            {
                //For Localized Visual Studio ... In other languages stack trace  doesn't end with ":Line 12"
                linenum = Convert.ToInt32(e.StackTrace.Substring(e.StackTrace.LastIndexOf(' ')));
            }
            catch
            {
                //Stack trace is not available!
            }

            return linenum;
        }

        public static Exception GetInnerException(this Exception ex)
        {
            if (ex.InnerException != null)
                return ex.InnerException.GetInnerException();
            else
                return ex;
        }
    }
}
