using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using wfh_log_wpf.Models;

namespace wfh_log_wpf.Logger
{
    public class LogReader : BaseLog
    {
        public LogReader()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                ShouldQuote = (args) => false
            };

            if (!File.Exists(AbsoluteFilePath))
            {
                using (var writer = new StreamWriter(AbsoluteFilePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    writer.WriteLine("Time\t\t\tIsWorkingFromHome\tNetwork");
                }
            } 
            else
            {
                using (var reader = new StreamReader(AbsoluteFilePath))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Read();

                    while(csv.Read())
                    {
                        _logs.Add(csv.GetRecord<LogEntry>());
                    }
                }
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
