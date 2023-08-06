using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media;

namespace wfh_log_wpf.Settings
{
    public class WorkNetworkSettings
    {
        public List<string> WorkNetworks = new();
        internal readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            + "\\wfh-log"; // duplicate with base log
        private const string filename = "settings.txt";

        public WorkNetworkSettings()
        {
            ReadHomeNetworksFromFile();
        }

        public void ReadHomeNetworksFromFile()
        {
            if (!File.Exists(path + "\\" + filename))
            {
                Directory.CreateDirectory(path);
                var filestream = File.Create(path + "\\" + filename);
                filestream.Dispose();
            }

            var file = File.ReadAllText(path + "\\" + filename);

            SetWorkNetworks(file);
        }

        public void SetWorkNetworks(string list)
        {
            Clear();
            var networks = list.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var item in networks)
            {
                WorkNetworks.Add(item);
            }
        }

        private void Clear()
        {
            WorkNetworks.Clear();
        }

        public string GetHomeNetworkString()
        {
            var stringBuilder = new StringBuilder();

            foreach(var network in WorkNetworks)
            {
                stringBuilder.Append(network);
                stringBuilder.Append(';');
            }

            return stringBuilder.ToString();
        }
    }
}
