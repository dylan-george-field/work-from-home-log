using System;
using System.Collections.Generic;
using System.IO;
using wfh_log_wpf.Models;

namespace wfh_log_wpf.Logger
{
    public abstract class BaseLog
    {
        internal readonly string AbsoluteFilePath;
        protected List<LogEntry> _logs = new();

        public BaseLog()
        {
            AbsoluteFilePath = GetLogFilePath();

            Directory.CreateDirectory(GetLogDirectoryPath());
        }

        public static string GetLogFilePath()
        {
            var filename = "wfh.log";

            return Path.Combine(GetLogDirectoryPath(), filename);
        }

        public static string GetLogDirectoryPath()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var directory = "wfh-log";

            return Path.Combine(appDataPath, directory);
        }
    }
}
