using Microsoft.Win32;
using System;
using System.Net;
using System.Windows.Forms;

using SimpleJSON;
using System.Drawing;
using DiscordRPC;
using Button = DiscordRPC.Button;

namespace SteamRPC
{
    public partial class SettingsWindow : Form
    {
        private Timer refreshUI;
        private static DiscordRpcClient discordclient;
        private Boolean discordInitialized = false;

        String DiscordID            = "1133470229050163270";
        JSONNode json_rpc           = JSON.Parse(new WebClient().DownloadString("http://dsrpc.metonator.pl/discordappids.json"));

        Color color_loggedin_text   = Color.FromArgb(68, 155, 216);
        Color color_loggedin_bg     = Color.FromArgb(20, 46, 64);

        Color color_ingame_text     = Color.FromArgb(176, 230, 159);
        Color color_ingame_bg       = Color.FromArgb(26, 34, 23);

        public SettingsWindow() {
            InitializeComponent();

            loggedPanel.Hide();

            checkStatusRPC(null, null);

            refreshUI = new Timer();
            refreshUI.Tick += new EventHandler(checkStatusRPC);
            refreshUI.Interval = 5000;
            refreshUI.Start();

            this.FormClosing += (s, e) => {
                e.Cancel = true;
                Hide();
            };

            /* AUTOSTART SETTING */
            if (DiscordSteamRPC.Properties.Settings.Default.AutorunEnabled) settingsCheck_Autorun.Checked = true;
            settingsCheck_Autorun.CheckedChanged += (s, e) => {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (settingsCheck_Autorun.Checked) {
                    rk.SetValue(Application.ProductName, Application.ExecutablePath);
                    DiscordSteamRPC.Properties.Settings.Default.AutorunEnabled = true;
                } else {
                    rk.DeleteValue(Application.ProductName, false);
                    DiscordSteamRPC.Properties.Settings.Default.AutorunEnabled = false;
                }
                DiscordSteamRPC.Properties.Settings.Default.Save();
            };
        }

        private void checkStatusRPC(object sender, EventArgs e) {
            RegistryKey SteamActiveProcess = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Valve\Steam\ActiveProcess");

            Int32 SteamID3 = (int)SteamActiveProcess.GetValue("ActiveUser");

            if(SteamID3 != 0) {
                ((SettingsWindow)this).Height = 250;
                
                loggedPanel.Show();

                var client = new WebClient();

                String UrlRichPrresence = $"https://steamcommunity.com/miniprofile/{SteamID3}/json";
                Uri StringToUri = new Uri(UrlRichPrresence);

                client.CancelAsync();
                client.DownloadStringAsync(StringToUri);
                client.DownloadStringCompleted += (sender2, e2) => {
                    try {
                        RichPresence presence = new RichPresence();
                        JSONNode json = JSON.Parse(e2.Result);

                        steamWhoLogged.Text = json["persona_name"];
                        steamAvatar.Load(json["avatar_url"]);

                        if (json["in_game"]["name"] != null) {
                            String gamename = json["in_game"]["name"];

                            steamInGameStatus.Text = gamename;
                            steamInGameStatus.ForeColor = color_ingame_text;
                            steamWhoLogged.ForeColor = color_ingame_text;

                            if (json_rpc[gamename] != null) {
                                if (discordInitialized == false) {
                                    discordclient = new DiscordRpcClient(json_rpc[gamename]);
                                    discordclient.SkipIdenticalPresence = true;
                                    discordclient.ShutdownOnly = true;

                                    discordclient.Initialize();
                                    discordInitialized = true;
                                }
                            } else {
                                if (discordInitialized == false) {
                                    discordclient = new DiscordRpcClient(DiscordID);
                                    discordclient.SkipIdenticalPresence = true;
                                    discordclient.ShutdownOnly = true;

                                    discordclient.Initialize();
                                    discordInitialized = true;
                                }

                                presence.Details = json["in_game"]["name"];
                            }

                            presence.Assets = new Assets() {
                                LargeImageKey = "http://dsrpc.metonator.pl/DiscordSteamRPC_Logo.png",
                                LargeImageText = json["persona_name"],
                            };

                            if (json["in_game"]["name"] + "_steamid" != null) {
                                presence.Buttons = new Button[] {
                                    new Button() { Label = "View on Steam", Url = "http://store.steampowered.com/app/" +  json_rpc[(json["in_game"]["name"] + "_steamid")] }
                                };
                            }

                            if (json["in_game"]["rich_presence"] != String.Empty) {
                                presence.State = json["in_game"]["rich_presence"];
                                steamInGameStatus.Text += " (" + json["in_game"]["rich_presence"] + ")";
                            } else {
                                presence.State = "Initializing...";
                            }


                            loggedPanel.BackColor = color_ingame_bg;
                            if (discordInitialized) {
                                discordclient.SetPresence(presence);
                            }
                        } else {
                            steamInGameStatus.Text = "Online";
                            steamInGameStatus.ForeColor = color_loggedin_text;
                            steamWhoLogged.ForeColor = color_loggedin_text;

                            loggedPanel.BackColor = color_loggedin_bg;

                            if(discordInitialized) {
                                discordclient.Dispose();
                                discordInitialized = false;
                            }
                        }
                    } catch (Exception) {
                        //Failed to load steam status
                    }
                };
            } else {
                ((SettingsWindow)this).Height = 205;
                loggedPanel.Hide();
            }
        }
    }
}
