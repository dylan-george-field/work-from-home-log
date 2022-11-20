using System.IO;
using System.Text.Json;
using wfh_log_wpf.Models;

namespace wfh_log_wpf.Logger
{
    public class LogWriter : BaseLog
    {
        public void Log(string message)
        {
            var streamWriter = File.AppendText(path);
            var entry = new LogEntry(message);

            streamWriter.WriteLine(JsonSerializer.Serialize(entry));

            streamWriter.Dispose();
        }
    }
}
