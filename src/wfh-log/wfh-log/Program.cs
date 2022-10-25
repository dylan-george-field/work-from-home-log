// See https://aka.ms/new-console-template for more information
Console.WriteLine("Work from Home Log");

var workFromHomeSSID = "";

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

    // check if 9-5 

    // get network ssid and compare

    // log
}
