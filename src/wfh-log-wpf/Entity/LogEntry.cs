using System;

namespace wfh_log_wpf.Models
{
    public class LogEntry
    {
        public DateTime Time { get; set; } = DateTime.Now.ToLocalTime();
        public string ConnectedNetwork { get; set; }
        public bool IsWorkingFromHome { get; set; } = false;

        public LogEntry() { } // for csv helper

        public LogEntry(bool isWorkingFromHome, string connectedNetwork)
        {
            IsWorkingFromHome = isWorkingFromHome;
            ConnectedNetwork = connectedNetwork;
        }
    }
}
