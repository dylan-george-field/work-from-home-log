using System;
using System.Collections.Generic;
using System.IO;
using wfh_log_wpf.Models;

namespace wfh_log_wpf.Logger
{
    public abstract class BaseLog
    {
        internal readonly string AbsoluteFilePath;
        protected readonly List<LogEntry> _logs = new();

        public BaseLog()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var directory = "wfh-log";
            var filename = "wfh.log";

            AbsoluteFilePath = Path.Combine(appDataPath, directory, filename);
        }
    }
}
