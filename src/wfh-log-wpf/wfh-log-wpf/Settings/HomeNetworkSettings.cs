using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace wfh_log_wpf.Settings
{
    public class HomeNetworkSettings
    {
        public List<string> HomeNetworks = new();
        private const string DefaultSettingsFilePath = @"C:\temp\settings.txt";

        public HomeNetworkSettings()
        {
            ReadHomeNetworksFromFile();
        }

        public void ReadHomeNetworksFromFile()
        {
            var file = File.ReadAllText(DefaultSettingsFilePath);

            SetHomeNetworks(file);
        }

        public void SetHomeNetworks(string list)
        {
            var networks = list.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var item in networks)
            {
                HomeNetworks.Add(item);
            }
        }

        public string GetHomeNetworkString()
        {
            var stringBuilder = new StringBuilder();

            foreach(var network in HomeNetworks)
            {
                stringBuilder.Append(network);
                stringBuilder.Append(';');
            }

            return stringBuilder.ToString();
        }
    }
}
