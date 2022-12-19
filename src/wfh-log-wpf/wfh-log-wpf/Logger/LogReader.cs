using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using wfh_log_wpf.Models;

namespace wfh_log_wpf.Logger
{
    public class LogReader : BaseLog
    {
        private readonly List<LogEntry> _logs = new();

        public LogReader()
        {
            if (!File.Exists(AbsoluteFilePath))
            {
                var filestream = File.Create(AbsoluteFilePath);
                filestream.Dispose();
            }

            var lines = File.ReadAllLines(AbsoluteFilePath);

            foreach (var line in lines)
            {
                _logs.Add(JsonSerializer.Deserialize<LogEntry>(line));
            }
        }

        public IEnumerable<AggregatedLogElement> GetAggregateLogs()
        {
            return _logs
                .GroupBy(x => x.Time.Date)
                .OrderByDescending(grouping => grouping.Key)
                .Select(group => new AggregatedLogElement() { Date = group.Key.ToLongDateString(),
                    Text = group.All(x => x.IsWorkingFromHome) ? "working from home" : "not working from home" });
        }

        public int Count()
        {
            return _logs.Count;
        }
    }

    public class AggregatedLogElement
    {
        public string Date { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Date + ": " + Text;
        }
    }
}
