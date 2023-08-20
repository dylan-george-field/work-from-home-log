using ManagedNativeWifi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private readonly WorkNetworkSettings _settings;

        public MainWindow(LogWriter logger, HourlyTimer timer, WorkNetworkSettings settings)
        {
            _logger = logger;
            _settings = settings;

            InitializeComponent();

            Closing += MainWindow_Closing;

            var appDirectory = AppContext.BaseDirectory + "wfh-log.exe";
            var productVersion = FileVersionInfo.GetVersionInfo(appDirectory).ProductVersion;
            VersionTextBox.Text = productVersion;

            WorkNetworkTextbox.Text = settings.GetHomeNetworkString();

            var currentNetwork = NetworkHelper.GetConnectedNetworkSsid();

            ConnectedNetworkSsid.Text = currentNetwork;

            Dispatch_IsWorkingFromHome_Message(_settings.WorkNetworks.Contains(currentNetwork.ToString()));

            timer.AddHandler(HandleTimer);
        }

        private void HandleTimer(object? source, ElapsedEventArgs e)
        {
            var currentNetwork = NetworkHelper.GetConnectedNetworkSsid();

            Dispatcher.Invoke(() => ConnectedNetworkSsid.Text = currentNetwork.ToString());

            Dispatch_IsWorkingFromHome_Message(_settings.WorkNetworks.Contains(currentNetwork.ToString()));
        }

        private void SetWorkNetworkButton_Click(object? source, RoutedEventArgs args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\wfh-log";
            string filename = "settings.txt";

            if (!File.Exists(path + "\\" + filename))
            {
                Directory.CreateDirectory(path);
                var filestream = File.Create(path + "\\" + filename);
                filestream.Dispose();
            }

            File.WriteAllText(path + "\\" + filename, WorkNetworkTextbox.Text);
            _settings.SetWorkNetworks(WorkNetworkTextbox.Text);
            
            var currentNetwork = NetworkHelper.GetConnectedNetworkSsid();

            Dispatcher.Invoke(() => ConnectedNetworkSsid.Text = currentNetwork);

            Dispatch_IsWorkingFromHome_Message(_settings.WorkNetworks.Contains(currentNetwork.ToString()));
        }

        private void Dispatch_IsWorkingFromHome_Message(bool isWorkingFromHome)
        {
            var currentNetwork = NetworkHelper.GetConnectedNetworkSsid();

            if (isWorkingFromHome)
            {
                var message = "You're at the office 🏢";
                Dispatcher.Invoke(() => WorkFromHomeStatus.Text = message);
                _logger.Log(isWorkingFromHome: false, currentNetwork);
            }
            else
            {
                var message = "You're working from home 🏡";
                Dispatcher.Invoke(() => WorkFromHomeStatus.Text = message);
                _logger.Log(isWorkingFromHome: true, currentNetwork);
            }
        }

        private void MainWindow_Closing(object? sender, CancelEventArgs e)
        {
                e.Cancel = true;
                Hide();
        }
    }
}
