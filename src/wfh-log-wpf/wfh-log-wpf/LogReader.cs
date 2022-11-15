using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wfh_log_wpf
{
    public class LogReader
    {
        public List<LogEntry> logs = new List<LogEntry>();

        public LogReader(string path)
        {
            var lines = File.ReadAllLines(path);

            foreach(var line in lines)
            {
                logs.Add(JsonSerializer.Deserialize<LogEntry>(line));
            }
        }

        public int Count()
        {
            return logs.Count;
        }
    }

    public class LogEntry
    {
        public string time { get; set; }
        public string message { get; set; }
    }
}
