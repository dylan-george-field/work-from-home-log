using System;

namespace wfh_log_wpf.Models
{
    public class LogEntry
    {
        public DateTime Time { get; set; } = DateTime.Now.ToLocalTime();
        public bool IsWorkingFromHome { get; set; } = false;

        public LogEntry(bool isWorkingFromHome)
        {
            IsWorkingFromHome = isWorkingFromHome;
        }
    }
}
