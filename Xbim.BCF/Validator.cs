using System;

namespace Xbim.BCF
{
    public static class Validator
    {
        public static void RaiseError(string context, string message, LogLevel logLevel = LogLevel.Error)
        {
            if (BCF.Instance != null)
            {
                BCF.Instance.LogEvent(context, message, logLevel);
            }
            else
            {
                throw new ArgumentException($"{logLevel}: {context} - {message}");
            }
        }
    }
}
