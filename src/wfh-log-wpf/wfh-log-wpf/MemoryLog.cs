using NLog.Targets;
using NLog;
using System.Collections.Generic;

namespace wfh_log_wpf
{
    public class MemoryLog
    {
        public IList<string> Logs { get; set; }

        public MemoryLog()
        {
            var target = (MemoryTarget)LogManager.Configuration.FindTargetByName("memory");
            Logs = target.Logs;
        }
    }
}
