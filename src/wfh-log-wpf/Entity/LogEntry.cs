using System;

namespace wfh_log_wpf.Models
{
    public class LogEntry
    {
        public string ConnectedNetwork { get; set; }
        public bool IsWorkingFromHome { get; set; } = false;
        public DateTime Time { get; set; } = DateTime.Now.ToLocalTime();

        // needed for csv helper to load headers
        public LogEntry() { }

        public LogEntry(bool isWorkingFromHome, string connectedNetwork)
        {
            IsWorkingFromHome = isWorkingFromHome;
            ConnectedNetwork = connectedNetwork;
        }
    }
}
