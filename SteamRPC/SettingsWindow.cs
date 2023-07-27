using Microsoft.Win32;
using System;
using System.Net;
using System.Windows.Forms;

using SimpleJSON;
using System.Drawing;

namespace SteamRPC
{
    public partial class SettingsWindow : Form
    {
        private Timer refreshUI;
        private DiscordRpc.RichPresence _presence = new DiscordRpc.RichPresence();

        String DiscordID        = "1133470229050163270";
        JSONNode json_rpc = JSON.Parse(new WebClient().DownloadString("http://dsrpc.metonator.pl/discordappids.json"));

        Int32 color_loggedin    = 0x449bd8;
        Int32 color_ingame      = 0xb0e69f;

        protected override CreateParams CreateParams {
            get {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | 0x200;
                return myCp;
            }
        }

        public SettingsWindow() {
            InitializeComponent();

            loggedPanel.Hide();

            checkStatusRPC(null, null);

            refreshUI = new Timer();
            refreshUI.Tick += new EventHandler(checkStatusRPC);
            refreshUI.Interval = 5000; // in miliseconds
            refreshUI.Start();

        }

        private void checkStatusRPC(object sender, EventArgs e) {
            RegistryKey SteamActiveProcess = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Valve\Steam\ActiveProcess");

            Int32 SteamID3 = (int)SteamActiveProcess.GetValue("ActiveUser");

            if(SteamID3 != 0) {
                loggedPanel.Show();
                loggedPanel.BackColor = Color.FromArgb(255, 22, 29, 36);

                var client = new WebClient();

                String UrlRichPrresence = $"https://steamcommunity.com/miniprofile/{SteamID3}/json";
                Uri StringToUri = new Uri(UrlRichPrresence);

                client.CancelAsync();
                client.DownloadStringAsync(StringToUri);
                client.DownloadStringCompleted += (sender2, e2) => {
                    try {
                        JSONNode json = JSON.Parse(e2.Result);

                        steamWhoLogged.Text = json["persona_name"];
                        steamAvatar.Load(json["avatar_url"]);

                        if (json["in_game"]["name"] != null) {
                            String gamename = json["in_game"]["name"];
                            var handlers = new DiscordRpc.EventHandlers();

                            steamInGameStatus.Text = gamename;
                            steamInGameStatus.ForeColor = Color.FromArgb(color_ingame);
                            steamWhoLogged.ForeColor = Color.FromArgb(color_ingame);

                            if (json_rpc[gamename] != null) {
                                DiscordRpc.Initialize(json_rpc[gamename], ref handlers, true, "");
                                _presence.largeImageKey = "logo";
                                _presence.largeImageText = json["currentUser"];
                            } else {
                                DiscordRpc.Initialize(DiscordID, ref handlers, true, "");
                                _presence.details = json["in_game"]["name"];
                                _presence.largeImageKey = "logo";
                                _presence.largeImageText = json["currentUser"];
                            }

                            if (json["in_game"]["rich_presence"] != String.Empty) {
                                _presence.state = json["in_game"]["rich_presence"];
                                steamInGameStatus.Text += " (" + json["in_game"]["rich_presence"] + ")";
                            }
                        } else {
                            steamInGameStatus.Text = "Online";
                            steamInGameStatus.ForeColor = Color.FromArgb(color_loggedin);
                            steamWhoLogged.ForeColor = Color.FromArgb(color_loggedin);
                            DiscordRpc.Shutdown();
                        }

                        _presence.instance = true;
                        DiscordRpc.UpdatePresence(_presence);
                    } catch (Exception) {
                        //Failed to load steam status
                    }
                };
            } else {
                loggedPanel.Hide();
                //Clean avatar too
            }
        }
    }
}
