using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace wfh_log_wpf
{
    public class LogReader
    {
        public List<LogEntry> logs = new();

        public LogReader()
        {
            var path = @"C:\temp\wfh.log";

            if (!File.Exists(path))
                throw new FileNotFoundException(path);


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
