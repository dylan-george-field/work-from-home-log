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
            var target = ()LogManager.Configuration.FindTargetByName("memory");
            LogManager.Configuration.RemoveTarget("console");
            Logs = target.Logs;
        }
    }
}
