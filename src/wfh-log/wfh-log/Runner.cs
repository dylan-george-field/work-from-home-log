using ManagedNativeWifi;
using Microsoft.Extensions.Logging;

namespace wfh_log
{
    internal class Runner
    {
        private ILogger _logger;

        public Runner(ILogger<Runner> logger)
        {
            _logger = logger;
        }

        public void Run(string[] args)
        {
            _logger.LogInformation("Run work from home logger");

            var workFromHomeSSID = "Dylan's Pad 🐇";

            if (args.Length > 0)
            {
                _logger.LogInformation($"Work from home SSID: {args[0]}");
                workFromHomeSSID = args[0];
            }

            // start loop
            var oneHourInMilliseconds = 60000;
            var timer = new System.Timers.Timer(oneHourInMilliseconds);
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            timer.AutoReset = true;

            Console.ReadLine();

            void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
            {
                _logger.LogInformation("Timer elapsed at {0:HH:mm:ss.fff}", e.SignalTime);

                var connectedNetworkSsids = NativeWifi.EnumerateConnectedNetworkSsids();

                if (!connectedNetworkSsids.Any())
                    return;

                var currentNetwork = connectedNetworkSsids.First();

                _logger.LogInformation(currentNetwork.ToString());

                var isWorkingFromHome = currentNetwork.ToString() == workFromHomeSSID;

                if (isWorkingFromHome)
                    _logger.LogInformation("You are working from home");
                else
                    _logger.LogInformation("You are not working from home");

            }
        }
    }
}
