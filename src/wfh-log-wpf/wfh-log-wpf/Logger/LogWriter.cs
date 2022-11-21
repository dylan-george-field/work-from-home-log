using System.IO;
using System.Text.Json;
using wfh_log_wpf.Models;

namespace wfh_log_wpf.Logger
{
    public class LogWriter : BaseLog
    {
        public void Log(bool isWorkingFromHome)
        {
            var streamWriter = File.AppendText(path);
            var entry = new LogEntry(isWorkingFromHome);


            streamWriter.WriteLine(JsonSerializer.Serialize(entry));

            streamWriter.Dispose();
        }
    }
}
