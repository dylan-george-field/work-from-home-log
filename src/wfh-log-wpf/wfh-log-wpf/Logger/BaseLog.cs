using System;
using System.IO;

namespace wfh_log_wpf.Logger
{
    public abstract class BaseLog
    {
        internal readonly string AbsoluteFilePath;

        public BaseLog()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var directory = "wfh-log";
            var filename = "wfh.log";

            AbsoluteFilePath = Path.Combine(appDataPath, directory, filename);
        }
    }
}
