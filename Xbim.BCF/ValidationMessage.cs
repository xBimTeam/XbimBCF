namespace Xbim.BCF
{
    [System.Diagnostics.DebuggerDisplay("{Severity}: {Context} - {Message}")]
    public class ValidationMessage
    {
        public ValidationMessage()
        { }

        public ValidationMessage(string context, string message, LogLevel severity = LogLevel.Error)
        {
            Context = context;
            Message = message;
            Severity = severity;
        }

        public LogLevel Severity { get; set; }
        public string Message { get; set; }
        public string Context { get; set; }
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }
}
