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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.loggedPanel = new System.Windows.Forms.Panel();
            this.steamInGameStatus = new System.Windows.Forms.Label();
            this.steamWhoLogged = new System.Windows.Forms.Label();
            this.steamAvatar = new System.Windows.Forms.PictureBox();
            this.WIP = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.loggedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.steamAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(15, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(501, 140);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.WIP);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(493, 114);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // loggedPanel
            // 
            this.loggedPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loggedPanel.Controls.Add(this.steamInGameStatus);
            this.loggedPanel.Controls.Add(this.steamWhoLogged);
            this.loggedPanel.Controls.Add(this.steamAvatar);
            this.loggedPanel.Location = new System.Drawing.Point(-6, 159);
            this.loggedPanel.Name = "loggedPanel";
            this.loggedPanel.Size = new System.Drawing.Size(540, 57);
            this.loggedPanel.TabIndex = 2;
            // 
            // steamInGameStatus
            // 
            this.steamInGameStatus.AutoSize = true;
            this.steamInGameStatus.ForeColor = System.Drawing.Color.White;
            this.steamInGameStatus.Location = new System.Drawing.Point(55, 27);
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
            this.steamWhoLogged.Location = new System.Drawing.Point(55, 11);
            this.steamWhoLogged.Name = "steamWhoLogged";
            this.steamWhoLogged.Size = new System.Drawing.Size(63, 13);
            this.steamWhoLogged.TabIndex = 1;
            this.steamWhoLogged.Text = "Username";
            // 
            // steamAvatar
            // 
            this.steamAvatar.Location = new System.Drawing.Point(21, 10);
            this.steamAvatar.Name = "steamAvatar";
            this.steamAvatar.Size = new System.Drawing.Size(32, 32);
            this.steamAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.steamAvatar.TabIndex = 0;
            this.steamAvatar.TabStop = false;
            // 
            // WIP
            // 
            this.WIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.WIP.Location = new System.Drawing.Point(6, 3);
            this.WIP.Name = "WIP";
            this.WIP.Size = new System.Drawing.Size(481, 108);
            this.WIP.TabIndex = 0;
            this.WIP.Text = "Settings Panel is in WIP";
            this.WIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(528, 211);
            this.Controls.Add(this.loggedPanel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SteamRPC";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.loggedPanel.ResumeLayout(false);
            this.loggedPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.steamAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel loggedPanel;
        private System.Windows.Forms.Label steamWhoLogged;
        private System.Windows.Forms.PictureBox steamAvatar;
        private System.Windows.Forms.Label steamInGameStatus;
        private System.Windows.Forms.Label WIP;
    }
}

