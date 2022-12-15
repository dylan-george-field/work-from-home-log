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
            if (!File.Exists(path + "\\" + filename))
            {
                Directory.CreateDirectory(path);
                var filestream = File.Create(path + "\\" + filename);
                filestream.Dispose();
            }

            var lines = File.ReadAllLines(path + "\\" + filename);

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
