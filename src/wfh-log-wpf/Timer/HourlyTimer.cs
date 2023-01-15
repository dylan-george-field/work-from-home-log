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

            timer.Interval = GetInterval();
        }

        public void Start()
        {
            timer.Start();
        }

        public static double GetInterval()
        {
            var timeOfDay = DateTime.Now.TimeOfDay;
            var roundedUpToHour = Math.Ceiling(timeOfDay.TotalHours);
            var nextFullHour = TimeSpan.FromHours(roundedUpToHour);
            var delta = (nextFullHour - timeOfDay).TotalMilliseconds;

            return delta;
        }

        public void AddHandler(ElapsedEventHandler function)
        {
            timer.Elapsed += function;
            timer.Elapsed += ResetInterval;
        }

        private void ResetInterval(object? source, ElapsedEventArgs e)
        {
            timer.Interval = GetInterval();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}
