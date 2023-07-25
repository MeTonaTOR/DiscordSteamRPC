using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SimpleJSON;
using System.Net;

namespace SteamRPC
{
    public partial class SettingsWindow : Form
    {
        private Timer refreshUI;
        String currentUser = String.Empty;
        String DiscordID = "1133470229050163270";
        private readonly DiscordRpc.RichPresence _presence = new DiscordRpc.RichPresence();

        public SettingsWindow() {
            InitializeComponent();

            checkStatusRPC(null, null);

            refreshUI = new Timer();
            refreshUI.Tick += new EventHandler(checkStatusRPC);
            refreshUI.Interval = 5000; // in miliseconds
            refreshUI.Start();
        }

        private void checkStatusRPC(object sender, EventArgs e) {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Valve\Steam\ActiveProcess");

            String SteamID3 = key.GetValue("ActiveUser").ToString();
            int SteamPID = (int)key.GetValue("pid");

            accountIdLabel.Text = "AccountID: " + SteamID3;
            if(currentUser != String.Empty) {
                accountIdLabel.Text += " [" + currentUser + "]";
            }

            var client = new WebClient();

            String UrlRichPrresence = $"https://steamcommunity.com/miniprofile/{SteamID3}/json";
            Uri StringToUri = new Uri(UrlRichPrresence);

            client.CancelAsync();
            client.DownloadStringAsync(StringToUri);
            client.DownloadStringCompleted += (sender2, e2) => {
                try {
                    JSONNode json = JSON.Parse(e2.Result);

                    currentUser = json["persona_name"];

                    if (json["in_game"]["name"] != null) {
                        var handlers = new DiscordRpc.EventHandlers();
                        DiscordRpc.Initialize(DiscordID, ref handlers, true, "");

                        _presence.details = json["in_game"]["name"];
                        _presence.largeImageKey = "steamlogo";
                        _presence.largeImageText = json["currentUser"];

                        if (json["in_game"]["rich_presence"] != null) {
                            _presence.state = json["in_game"]["rich_presence"];
                        }
                    } else {
                        DiscordRpc.Shutdown();
                    }

                    _presence.instance = true;
                    DiscordRpc.UpdatePresence(_presence);
                } catch (Exception) {
                    //Failed to load steam status
                }
            };
        }
    }
}
