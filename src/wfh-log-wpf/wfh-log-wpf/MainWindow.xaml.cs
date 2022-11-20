using ManagedNativeWifi;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows;
using wfh_log_wpf.Logger;
using wfh_log_wpf.Timer;

namespace wfh_log_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LogWriter _logger;
        private string HomeNetwork = "Dylan's Pad 🐇";

        public MainWindow(LogWriter logger, HourlyTimer timer)
        {
            _logger = logger;

            InitializeComponent();

            Closing += MainWindow_Closing;

            HomeNetwork = File.ReadAllText(@"C:\temp\settings.txt");
            HomeNetworkTextbox.Text = HomeNetwork;

            var connectedNetworkSsids = NativeWifi.EnumerateConnectedNetworkSsids();

            if (!connectedNetworkSsids.Any())
                return;

            var currentNetwork = connectedNetworkSsids.First();


            ConnectedNetworkSsid.Text = currentNetwork.ToString();

            if (currentNetwork.ToString() == HomeNetwork)
            {
                var message = "You are working from home";
                WorkFromHomeStatus.Text = message;
                _logger.Log(message);
            }
            else
            {
                var message = "You are not working from home";
                WorkFromHomeStatus.Text = message;
                _logger.Log(message);
            }

            timer.AddHandler(HandleTimer);
        }

        private void HandleTimer(object? source, ElapsedEventArgs e)
        {
            var connectedNetworkSsids = NativeWifi.EnumerateConnectedNetworkSsids();

            if (!connectedNetworkSsids.Any())
                return;

            var currentNetwork = connectedNetworkSsids.First();

            Dispatcher.Invoke(() => ConnectedNetworkSsid.Text = currentNetwork.ToString());

            if (currentNetwork.ToString() == HomeNetwork)
            {
                var message = "You are working from home";
                Dispatcher.Invoke(() => WorkFromHomeStatus.Text = message);
                _logger.Log(message);
            }
            else
            {
                var message = "You are not working from home";
                Dispatcher.Invoke(() => WorkFromHomeStatus.Text = message);
                _logger.Log(message);
            }
        }

        private void SetHomeNetworkButton_Click(object? source, RoutedEventArgs args)
        {
            // save value
            File.WriteAllText(@"C:\temp\settings.txt", HomeNetworkTextbox.Text);
            HomeNetwork = HomeNetworkTextbox.Text;
            // re-run
            var connectedNetworkSsids = NativeWifi.EnumerateConnectedNetworkSsids();

            if (!connectedNetworkSsids.Any())
                return;

            var currentNetwork = connectedNetworkSsids.First();

            Dispatcher.Invoke(() => ConnectedNetworkSsid.Text = currentNetwork.ToString());

            if (currentNetwork.ToString() == HomeNetwork)
            {
                var message = "You are working from home";
                Dispatcher.Invoke(() => WorkFromHomeStatus.Text = message);
                _logger.Log(message);
            }
            else
            {
                var message = "You are not working from home";
                Dispatcher.Invoke(() => WorkFromHomeStatus.Text = message);
                _logger.Log(message);
            }
        }

        private void MainWindow_Closing(object? sender, CancelEventArgs e)
        {
                e.Cancel = true;
                Hide();
        }
    }
}
