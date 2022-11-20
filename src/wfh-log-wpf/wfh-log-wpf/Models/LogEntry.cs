using System;

namespace wfh_log_wpf.Models
{
    public class LogEntry
    {
        public DateTime Time { get; set; } = DateTime.Now.ToLocalTime();
        public string Message { get; set; } = "No message";

        public LogEntry(string message)
        {
            Message = message;
        }

        public override string ToString()
        {
            return $"{Time} | {Message}";
        }
    }
}
