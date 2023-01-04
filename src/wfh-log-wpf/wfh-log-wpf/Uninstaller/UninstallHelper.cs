using Microsoft.Win32;

namespace wfh_log_wpf.Uninstaller
{
    internal static class UninstallHelper
    {
        public static void AddRegUninstallScript()
        {
            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey uninstallKey = Registry.CurrentUser.OpenSubKey(registryKey);

            if (uninstallKey != null)
            {
                foreach (string a in uninstallKey.GetSubKeyNames())
                {
                    RegistryKey subkey = uninstallKey.OpenSubKey(a, true);

                    // Found the Uninstall key for this app.
                    if (subkey.GetValue("DisplayName").Equals("wfh-log"))
                    {
                        string uninstallString = subkey.GetValue("UninstallString").ToString();

                        // Wrap uninstall string with my own command
                        // In this case a reg delete command to remove a reg key.
                        string newUninstallString = "cmd /c \"" + uninstallString +
                            " & reg delete HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run /v wfh-log /f\"";
                        subkey.SetValue("UninstallString", newUninstallString);
                        subkey.Close();
                    }
                }

            }
        }
    }
}
