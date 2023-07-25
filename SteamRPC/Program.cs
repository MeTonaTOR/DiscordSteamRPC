using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SteamRPC {
    internal static class Program {
        [STAThread]
        static void Main() {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Valve\Steam\ActiveProcess");

            if (key != null) {
                key.Close();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SettingsWindow());
            } else {
                MessageBox.Show("Steam is not installed, please download it from the URL below:\nhttps://store.steampowered.com/", "SteamRPC - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
