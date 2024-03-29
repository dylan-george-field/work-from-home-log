﻿using System;

namespace wfh_log_wpf.Models
{
    /// <summary>
    /// The same as LogEntry.cs but with strings.
    /// Used to change log output by adding tabs
    /// before properties to make it look pretty
    /// </summary>
    public class LogEntryPretty
    {
        public DateTime Time { get; set; }
        public string IsWorkingFromHome { get; set; }
        public string ConnectedNetwork { get; set; }

        public LogEntryPretty(LogEntry entry)
        {
            Time = entry.Time;
            IsWorkingFromHome = "       " + entry.IsWorkingFromHome;
            ConnectedNetwork = entry.IsWorkingFromHome
                                    ? "                   " + entry.ConnectedNetwork.ToString()
                                    : "                  " + entry.ConnectedNetwork.ToString();
        }
    }
}
