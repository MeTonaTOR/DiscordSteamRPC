using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SteamRPC {
    internal static class Program {
        [STAThread]
        static void Main() {
            if(!File.Exists("discord-rpc.dll")) {
                MessageBox.Show("Discord library not found, please re-download the archive from GitHub", "DiscordSteamRPC - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.Start("https://github.com/MeTonaTOR/DiscordSteamRPC/releases/latest");
            }

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Valve\Steam\ActiveProcess");

            if (key != null) {
                key.Close();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SettingsWindow settings = new SettingsWindow();

                using (NotifyIcon icon = new NotifyIcon()) {
                    icon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                    icon.ContextMenu = new ContextMenu(new MenuItem[] {
                        new MenuItem("Check Github", (s, e) => { Process.Start("https://github.com/MeTonaTOR/DiscordSteamRPC"); }),
                        new MenuItem("Settings", (s, e) => { settings.Show();}),
                        new MenuItem("-"),
                        new MenuItem("Close DiscordSteamRPC", (s, e) => { Application.Exit(); }),
                    });
                    icon.Visible = true;
                    icon.DoubleClick += (s, e) => {
                        settings.Show();
                    };

                    Application.Run();
                    icon.Visible = false;
                }
            } else {
                MessageBox.Show("Steam is not installed, please download it from the URL below:\nhttps://store.steampowered.com/", "DiscordSteamRPC - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
