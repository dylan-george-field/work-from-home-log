using System;
using System.Timers;

namespace wfh_log_wpf.Timer
{
    public class HourlyTimer
    {
        private readonly System.Timers.Timer timer = new();

        public HourlyTimer()
        {
            timer.AutoReset = true;
            timer.Enabled = true;

            int minutes = DateTime.Now.Minute;
            int adjust = 10 - minutes % 1;
            timer.Interval = adjust * 60 * 100;
        }

        public void Start()
        {
            timer.Start();
        }

        public void AddHandler(ElapsedEventHandler function)
        {
            timer.Elapsed += function;
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}
