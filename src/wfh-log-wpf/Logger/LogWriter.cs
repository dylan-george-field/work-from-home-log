using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using wfh_log_wpf.Models;

namespace wfh_log_wpf.Logger
{
    public class LogWriter : BaseLog
    {
        public void Log(bool isWorkingFromHome, string connectedNetworkName)
        {
            var entry = new LogEntry(isWorkingFromHome, connectedNetworkName);

            _logs.Add(entry);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false // don't write header again
            };

            using (var stream = File.Open(AbsoluteFilePath, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(new List<LogEntry>() { entry });
            }
        }
    }
}
