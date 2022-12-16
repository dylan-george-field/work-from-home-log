using System;
using System.IO;

namespace wfh_log_wpf.Logger
{
    public abstract class BaseLog
    {
        internal readonly string LogAbsolutePath;

        public BaseLog()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var directory = "\\wpf-log";
            var filename = "wpf.log";

            LogAbsolutePath = Path.Combine(appDataPath, directory, filename);
        }
    }
}
