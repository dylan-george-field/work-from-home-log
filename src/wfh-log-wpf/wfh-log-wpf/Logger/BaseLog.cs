using System;

namespace wfh_log_wpf.Logger
{
    public abstract class BaseLog
    {
        internal readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            + "\\wfh-log";
        internal const string filename = "wfh.log";
    }
}
