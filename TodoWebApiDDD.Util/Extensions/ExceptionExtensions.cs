using System;

namespace TodoWebApiDDD.Util.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetExceptionMessage(this Exception ex) => ex.InnerException is null ? ex.Message : GetExceptionMessage(ex.InnerException);
    }
}
}
