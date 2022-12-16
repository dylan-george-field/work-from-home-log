using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using wfh_log_wpf.Models;

namespace wfh_log_wpf.Logger
{
    public class LogReader : BaseLog
    {
        public List<LogEntry> logs = new();

        public LogReader()
        {
            if (!File.Exists(LogAbsolutePath))
            {
                Directory.CreateDirectory(LogAbsolutePath);
                var filestream = File.Create(LogAbsolutePath);
                filestream.Dispose();
            }

            var lines = File.ReadAllLines(LogAbsolutePath);

            foreach (var line in lines)
            {
                logs.Add(JsonSerializer.Deserialize<LogEntry>(line));
            }
        }

        public int Count()
        {
            return logs.Count;
        }
    }
}
