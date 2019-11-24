using System;
using System.Collections.Generic;
using System.Text;

namespace FATC.Common
{ 
    public enum ResultType
    {
        INFO,
        ERROR,
        SUCCESS,
        WARNING
    }

    public enum DataAction
    {
        Select = 0,
        Insert = 1,
        Update = 2,
        Delete = 3,
        InsertAndSelect = 4,
        UpdateAndSelect = 5,
        SelectPaginated = 6,
        SelectRecord = 7
    }

    public enum LogType
    {
        INFO,
        ERROR,
        DEBUG,
        WARNING
    }

    public enum Operators
    {
        IsNull,
        NotNull,
        NotEqual,
        EqualTo,
        Less,
        LessOrEqual,
        Greater,
        GreaterOrEqual
    }
}
