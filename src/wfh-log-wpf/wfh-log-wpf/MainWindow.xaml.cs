using ManagedNativeWifi;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows;
using wfh_log_wpf.Helper;
using wfh_log_wpf.Logger;
using wfh_log_wpf.Settings;
using wfh_log_wpf.Timer;

namespace wfh_log_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LogWriter _logger;
        private readonly HomeNetworkSettings _settings;

        public MainWindow(LogWriter logger, HourlyTimer timer, HomeNetworkSettings settings)
        {
            _logger = logger;
            _settings = settings;

            InitializeComponent();

            Closing += MainWindow_Closing;

            HomeNetworkTextbox.Text = settings.GetHomeNetworkString();

            var currentNetwork = NetworkHelper.GetConnectedNetworkSsid();

            ConnectedNetworkSsid.Text = currentNetwork;

            if (_settings.HomeNetworks.Contains(currentNetwork.ToString()))
            {
                var message = "You are working from home";
                WorkFromHomeStatus.Text = message;
                _logger.Log(isWorkingFromHome: true, currentNetwork);
            }
            else
            {
                var message = "You are not working from home";
                WorkFromHomeStatus.Text = message;
                _logger.Log(isWorkingFromHome: false, currentNetwork);
            }

            timer.AddHandler(HandleTimer);
        }

        private void HandleTimer(object? source, ElapsedEventArgs e)
        {
            var currentNetwork = NetworkHelper.GetConnectedNetworkSsid();

            Dispatcher.Invoke(() => ConnectedNetworkSsid.Text = currentNetwork.ToString());

            if (_settings.HomeNetworks.Contains(currentNetwork.ToString()))
            {
                var message = "You are working from home";
                Dispatcher.Invoke(() => WorkFromHomeStatus.Text = message);
                _logger.Log(isWorkingFromHome: true, currentNetwork);
            }
            else
            {
                var message = "You are not working from home";
                Dispatcher.Invoke(() => WorkFromHomeStatus.Text = message);
                _logger.Log(isWorkingFromHome: false, currentNetwork);
            }
        }

        private void SetHomeNetworkButton_Click(object? source, RoutedEventArgs args)
        {
            // save value
            File.WriteAllText(@"C:\temp\settings.txt", HomeNetworkTextbox.Text);
            _settings.SetHomeNetworks(HomeNetworkTextbox.Text);
            // re-run
            var currentNetwork = NetworkHelper.GetConnectedNetworkSsid();

            Dispatcher.Invoke(() => ConnectedNetworkSsid.Text = currentNetwork);

            if (_settings.HomeNetworks.Contains(currentNetwork.ToString()))
            {
                var message = "You are working from home";
                Dispatcher.Invoke(() => WorkFromHomeStatus.Text = message);
                _logger.Log(isWorkingFromHome: true, currentNetwork);
            }
            else
            {
                var message = "You are not working from home";
                Dispatcher.Invoke(() => WorkFromHomeStatus.Text = message);
                _logger.Log(isWorkingFromHome: false, currentNetwork);
            }
        }

        private void MainWindow_Closing(object? sender, CancelEventArgs e)
        {
                e.Cancel = true;
                Hide();
        }
    }
}
