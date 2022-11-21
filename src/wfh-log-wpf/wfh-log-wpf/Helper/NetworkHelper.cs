using ManagedNativeWifi;
using System.Linq;

namespace wfh_log_wpf.Helper
{
    internal static class NetworkHelper
    {
        public static string GetConnectedNetworkSsid()
        {
            var connectedNetworkSsids = NativeWifi.EnumerateConnectedNetworkSsids();

            if (!connectedNetworkSsids.Any())
                return "No network connected";

            return connectedNetworkSsids.First().ToString();
        }
    }
}
