namespace SteamRPC
{
    partial class SettingsWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.tabs = new System.Windows.Forms.TabControl();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.settingsCheck_Autorun = new System.Windows.Forms.CheckBox();
            this.loggedPanel = new System.Windows.Forms.Panel();
            this.steamInGameStatus = new System.Windows.Forms.Label();
            this.steamWhoLogged = new System.Windows.Forms.Label();
            this.steamAvatar = new System.Windows.Forms.PictureBox();
            this.tabs.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.loggedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.steamAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.settingsPage);
            this.tabs.Location = new System.Drawing.Point(15, 13);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(501, 140);
            this.tabs.TabIndex = 1;
            // 
            // settingsPage
            // 
            this.settingsPage.Controls.Add(this.button2);
            this.settingsPage.Controls.Add(this.button1);
            this.settingsPage.Controls.Add(this.settingsCheck_Autorun);
            this.settingsPage.Location = new System.Drawing.Point(4, 22);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPage.Size = new System.Drawing.Size(493, 114);
            this.settingsPage.TabIndex = 0;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(250, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Override Discord Application ID per Game";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(6, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exclude Games from RPC";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // settingsCheck_Autorun
            // 
            this.settingsCheck_Autorun.AutoSize = true;
            this.settingsCheck_Autorun.Location = new System.Drawing.Point(6, 62);
            this.settingsCheck_Autorun.Name = "settingsCheck_Autorun";
            this.settingsCheck_Autorun.Size = new System.Drawing.Size(153, 17);
            this.settingsCheck_Autorun.TabIndex = 0;
            this.settingsCheck_Autorun.Text = "Launch at windows startup";
            this.settingsCheck_Autorun.UseVisualStyleBackColor = true;
            // 
            // loggedPanel
            // 
            this.loggedPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loggedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loggedPanel.Controls.Add(this.steamInGameStatus);
            this.loggedPanel.Controls.Add(this.steamWhoLogged);
            this.loggedPanel.Controls.Add(this.steamAvatar);
            this.loggedPanel.Location = new System.Drawing.Point(-6, 161);
            this.loggedPanel.Name = "loggedPanel";
            this.loggedPanel.Size = new System.Drawing.Size(540, 57);
            this.loggedPanel.TabIndex = 2;
            // 
            // steamInGameStatus
            // 
            this.steamInGameStatus.AutoSize = true;
            this.steamInGameStatus.ForeColor = System.Drawing.Color.White;
            this.steamInGameStatus.Location = new System.Drawing.Point(55, 25);
            this.steamInGameStatus.Name = "steamInGameStatus";
            this.steamInGameStatus.Size = new System.Drawing.Size(58, 13);
            this.steamInGameStatus.TabIndex = 2;
            this.steamInGameStatus.Text = "Game Title";
            // 
            // steamWhoLogged
            // 
            this.steamWhoLogged.AutoSize = true;
            this.steamWhoLogged.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.steamWhoLogged.ForeColor = System.Drawing.Color.White;
            this.steamWhoLogged.Location = new System.Drawing.Point(55, 9);
            this.steamWhoLogged.Name = "steamWhoLogged";
            this.steamWhoLogged.Size = new System.Drawing.Size(63, 13);
            this.steamWhoLogged.TabIndex = 1;
            this.steamWhoLogged.Text = "Username";
            // 
            // steamAvatar
            // 
            this.steamAvatar.Location = new System.Drawing.Point(21, 8);
            this.steamAvatar.Name = "steamAvatar";
            this.steamAvatar.Size = new System.Drawing.Size(32, 32);
            this.steamAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.steamAvatar.TabIndex = 0;
            this.steamAvatar.TabStop = false;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(528, 211);
            this.Controls.Add(this.loggedPanel);
            this.Controls.Add(this.tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiscordSteamRPC";
            this.tabs.ResumeLayout(false);
            this.settingsPage.ResumeLayout(false);
            this.settingsPage.PerformLayout();
            this.loggedPanel.ResumeLayout(false);
            this.loggedPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.steamAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage settingsPage;
        private System.Windows.Forms.Panel loggedPanel;
        private System.Windows.Forms.Label steamWhoLogged;
        private System.Windows.Forms.PictureBox steamAvatar;
        private System.Windows.Forms.Label steamInGameStatus;
        private System.Windows.Forms.CheckBox settingsCheck_Autorun;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

