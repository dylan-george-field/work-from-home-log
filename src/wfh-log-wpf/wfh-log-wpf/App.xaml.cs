using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel;
using System.Windows;
using wfh_log_wpf.Logger;
using wfh_log_wpf.Models;

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

        public App()
        {
            _host = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                var configrurationRoot = hostContext.Configuration;
                services.Configure<Settings>(configrurationRoot.GetSection(nameof(Settings)));
                services.AddSingleton<MainWindow>();
                services.AddSingleton<HourlyTimer>();
                services.AddSingleton<LogReader>();
                services.AddSingleton<LogWriter>();
            }).Build();

            using (var serviceScope = _host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                
                var reader = _host.Services.GetRequiredService<LogReader>();

                try
                {
                    MainWindow = _host.Services.GetRequiredService<MainWindow>();
                    MainWindow.Closing += MainWindow_Closing;
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

            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            _notifyIcon.Icon = new System.Drawing.Icon("./Assets/house.ico");
            _notifyIcon.Visible = true;

            CreateContextMenu();
        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip =
              new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Open").Click += (s, e) => ShowMainWindow();
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
