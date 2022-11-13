using ManagedNativeWifi;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using System.Windows;
using wfh_log_wpf.Models;

namespace wfh_log_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILogger _logger;

        public MainWindow(ILogger<MainWindow> logger, IOptions<Settings> settings, HourlyTimer timer)
        {
            _logger = logger;

            InitializeComponent();

            logger.LogInformation("Main window started");

            Closing += MainWindow_Closing;

            var connectedNetworkSsids = NativeWifi.EnumerateConnectedNetworkSsids();

            if (!connectedNetworkSsids.Any())
                return;

            var currentNetwork = connectedNetworkSsids.First();

            var network = new NetworkInformation
            {
                ConnectedNetworkSsid = currentNetwork.ToString(),
            };

            if (currentNetwork.ToString() == network.HomeNetwork)
                network.WorkFromHomeStatus = "You are working from home";
            else
                network.WorkFromHomeStatus = "You are not working from home";


            ConnectedNetworkSsid.DataContext = network;
            WorkFromHomeStatus.DataContext = network;
            WorkHoursStatus.DataContext = network;

            timer.AddHandler(HandleTimer);
        }

        public void HandleTimer(Object source, ElapsedEventArgs e)
        {
            _logger.LogInformation("Handle the timer");
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
                e.Cancel = true;
                Hide();
        }
    }

    public class NetworkInformation
    {
        public string ConnectedNetworkSsid { get; set; } = "No network";
        public string HomeNetwork = "Dylan's Pad 🐇";
        public string WorkFromHomeStatus { get; set; } = "You are not working from home";
        public string WorkHoursStatus { get; set; } = "It's outside work hours";
    }
}
