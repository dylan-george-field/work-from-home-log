using ManagedNativeWifi;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wfh_log_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ILogger<MainWindow> logger)
        {
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
