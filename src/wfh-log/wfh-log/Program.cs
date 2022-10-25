using ManagedNativeWifi;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Work from Home Log");

        var workFromHomeSSID = "Dylan's Pad 🐇";

        if (args.Length > 0)
        {
            Console.WriteLine($"Work from home SSID: {args[0]}");
            workFromHomeSSID = args[0];
        }

        // start loop
        var timer = new System.Timers.Timer(5000); // 5 second interval
        timer.Elapsed += Timer_Elapsed;
        timer.Enabled = true;
        timer.AutoReset = true;

        Console.ReadLine();

        void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Timer elapsed at {0:HH:mm:ss.fff}", e.SignalTime);

            var connectedNetworkSsids = NativeWifi.EnumerateConnectedNetworkSsids();

            if (!connectedNetworkSsids.Any())
                return;

            var currentNetwork = connectedNetworkSsids.First();

            Console.WriteLine(currentNetwork);

            var isWorkingFromHome = currentNetwork.ToString() == workFromHomeSSID;

            if (isWorkingFromHome)
                Console.WriteLine("You are working from home");
            else
                Console.WriteLine("You are not working from home");
        }
    }
}