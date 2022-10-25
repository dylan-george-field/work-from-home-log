using ManagedNativeWifi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using wfh_log;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Work from Home Log");

        var logger = LogManager.GetCurrentClassLogger();
        try
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(System.IO.Directory.GetCurrentDirectory()) //From NuGet Package Microsoft.Extensions.Configuration.Json
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

            using var servicesProvider = new ServiceCollection()
                .AddTransient<Runner>() // Runner is the custom class
                .AddLogging(loggingBuilder =>
                {
                    // configure Logging with NLog
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggingBuilder.AddNLog(config);
                }).BuildServiceProvider();

            var runner = servicesProvider.GetRequiredService<Runner>();

            runner.Run(args);

            Console.WriteLine("Press ANY key to exit");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            // NLog: catch any exception and log it.
            logger.Error(ex, "Stopped program because of exception");
            throw;
        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            LogManager.Shutdown();
        }
    }
}