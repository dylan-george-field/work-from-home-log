using System;

namespace wfh_log_wpf.Models
{
    public class LogEntry
    {
        public DateTime Time { get; set; } = DateTime.Now.ToLocalTime();
        public bool IsWorkingFromHome { get; set; } = false;
        public string ConnectedNetwork { get; set; }

        // needed for csv helper to load headers
        public LogEntry() { }

        public LogEntry(bool isWorkingFromHome, string connectedNetwork)
        {
            IsWorkingFromHome = isWorkingFromHome;
            ConnectedNetwork = connectedNetwork;
        }
    }
}
