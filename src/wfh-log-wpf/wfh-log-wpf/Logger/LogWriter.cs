using Microsoft.VisualBasic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using wfh_log_wpf.Models;

namespace wfh_log_wpf.Logger
{
    public class LogWriter : BaseLog
    {
        public void Log(bool isWorkingFromHome, string connectedNetworkName)
        {
            var streamWriter = File.AppendText(path);
            
            var entry = new LogEntry(isWorkingFromHome, connectedNetworkName);

            var options = new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };

            streamWriter.WriteLine(JsonSerializer.Serialize(entry, options));

            streamWriter.Dispose();
        }
    }
}
