using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using wfh_log_wpf.Logger;
using wfh_log_wpf.Models;
using wfh_log_wpf.Settings;
using wfh_log_wpf.Timer;
using wfh_log_wpf.Uninstaller;

namespace wfh_log_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _isExit;
        
        private IHost _host;

        //private RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);


        public App()
        {
            /*var location = Directory.GetCurrentDirectory() + "\\wfh-log.exe";
            key.SetValue("wfh-log", "\"" + location + "\"", RegistryValueKind.String);
            UninstallHelper.AddRegUninstallScript();*/

            _host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<HourlyTimer>();
                services.AddSingleton<LogReader>();
                services.AddSingleton<LogWriter>();
                services.AddSingleton<HomeNetworkSettings>();
            }).Build();

            using (var serviceScope = _host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                
                var reader = _host.Services.GetRequiredService<LogReader>();

                try
                {
                    MainWindow = _host.Services.GetRequiredService<MainWindow>();
                    MainWindow.Closing += MainWindow_Closing;
                    // check if it's the first run
                    MainWindow.Show();
                } 
                catch (Exception e)
                {
                    Console.WriteLine("Error occured " + e.Message);
                }
            }
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();

            var assembly = Assembly.GetExecutingAssembly();

            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            _notifyIcon.Text = "wfh-log";
            _notifyIcon.Icon = new System.Drawing.Icon(assembly.GetManifestResourceStream("wfh_log_wpf.Assets.house-white.ico"));
            _notifyIcon.Visible = true;

            CreateContextMenu();
        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Open").Click += (s, e) => ShowMainWindow();
            _notifyIcon.ContextMenuStrip.Items.Add("Open Log File").Click += (s, e) => OpenLogFile();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }
 
        private void ExitApplication()
        {
            _isExit = true;
            MainWindow.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;
        }

        private void ShowMainWindow()
        {
            if (MainWindow.IsVisible)
            {
                if (MainWindow.WindowState == WindowState.Minimized)
                {
                    MainWindow.WindowState = WindowState.Normal;
                }
                MainWindow.Activate();
            }
            else
            {
                MainWindow.Show();
            }
        }

        private void OpenLogFile()
        {
            var absoluteFilePath = BaseLog.GetLogPath();

            var processStartInfo = new ProcessStartInfo
            {
                FileName = absoluteFilePath,
                UseShellExecute = true
            };

            Process.Start(processStartInfo);
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_isExit)
            {
                e.Cancel = true;
                MainWindow.Hide();
            } else
            {
                Shutdown_Application();
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Shutdown();
        }

        private async void Shutdown_Application()
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }

            Shutdown();
        }
    }
}
