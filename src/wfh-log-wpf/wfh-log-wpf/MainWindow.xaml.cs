using ManagedNativeWifi;
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
        public MainWindow()
        {
            InitializeComponent();

            Closing += MainWindow_Closing;

            var connectedNetworkSsids = NativeWifi.EnumerateConnectedNetworkSsids();

            if (!connectedNetworkSsids.Any())
                return;

            var currentNetwork = connectedNetworkSsids.First();

            var network = new NetworkInformation();
            network.ConnectedNetworkSsid = currentNetwork.ToString();

            var binding = new Binding("ConnectedNetworkSsid");
            binding.Mode = BindingMode.OneWay;
            binding.Source = network;

            BindingOperations.SetBinding(myTarget, TextBlock.TextProperty, binding);
    }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
                e.Cancel = true;
                Hide(); // A hidden window can be shown again, a closed one not
        }
    }

    public class NetworkInformation
    {
        public string ConnectedNetworkSsid { get; set; } = "No network";
    }
}
