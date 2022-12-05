using ManagedNativeWifi;
using System.Collections.Generic;
using System.Linq;

namespace wfh_log_wpf.Helper
{
    internal static class NetworkHelper
    {
        internal static string GetConnectedNetworkSsid()
        {
            IEnumerable<NetworkIdentifier> connectedNetworkSsids = NativeWifi.EnumerateConnectedNetworkSsids();

            if (!connectedNetworkSsids.Any())
                return "No network connected";

            return connectedNetworkSsids.First().ToString();
        }
    }
}
