namespace MediaPlayer
{
    partial class PlaylistForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.RenamePlaylistButton = new System.Windows.Forms.Button();
            this.PlaylistLabel = new System.Windows.Forms.Label();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.RemoveFilesButton = new System.Windows.Forms.Button();
            this.AddFilesButton = new System.Windows.Forms.Button();
            this.MainListBox = new System.Windows.Forms.ListBox();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.RenamePlaylistButton);
            this.mainPanel.Controls.Add(this.PlaylistLabel);
            this.mainPanel.Controls.Add(this.ButtonClose);
            this.mainPanel.Controls.Add(this.RemoveFilesButton);
            this.mainPanel.Controls.Add(this.AddFilesButton);
            this.mainPanel.Controls.Add(this.MainListBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.MaximumSize = new System.Drawing.Size(300, 580);
            this.mainPanel.MinimumSize = new System.Drawing.Size(300, 580);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(300, 580);
            this.mainPanel.TabIndex = 0;
            // 
            // RenamePlaylistButton
            // 
            this.RenamePlaylistButton.BackgroundImage = global::MediaPlayer.Properties.Resources.rename;
            this.RenamePlaylistButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RenamePlaylistButton.Location = new System.Drawing.Point(258, 538);
            this.RenamePlaylistButton.Name = "RenamePlaylistButton";
            this.RenamePlaylistButton.Size = new System.Drawing.Size(30, 30);
            this.RenamePlaylistButton.TabIndex = 28;
            this.RenamePlaylistButton.UseVisualStyleBackColor = true;
            this.RenamePlaylistButton.Click += new System.EventHandler(this.RenamePlaylistButton_Click);
            // 
            // PlaylistLabel
            // 
            this.PlaylistLabel.AutoSize = true;
            this.PlaylistLabel.Location = new System.Drawing.Point(13, 10);
            this.PlaylistLabel.Name = "PlaylistLabel";
            this.PlaylistLabel.Size = new System.Drawing.Size(44, 13);
            this.PlaylistLabel.TabIndex = 27;
            this.PlaylistLabel.Text = "Playlists";
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonClose.BackgroundImage = global::MediaPlayer.Properties.Resources.cancel;
            this.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonClose.Location = new System.Drawing.Point(268, 6);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(20, 20);
            this.ButtonClose.TabIndex = 25;
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // RemoveFilesButton
            // 
            this.RemoveFilesButton.BackgroundImage = global::MediaPlayer.Properties.Resources.minus;
            this.RemoveFilesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveFilesButton.Location = new System.Drawing.Point(48, 538);
            this.RemoveFilesButton.Name = "RemoveFilesButton";
            this.RemoveFilesButton.Size = new System.Drawing.Size(30, 30);
            this.RemoveFilesButton.TabIndex = 24;
            this.RemoveFilesButton.UseVisualStyleBackColor = true;
            this.RemoveFilesButton.Click += new System.EventHandler(this.RemoveFilesButton_Click);
            // 
            // AddFilesButton
            // 
            this.AddFilesButton.BackgroundImage = global::MediaPlayer.Properties.Resources.plus;
            this.AddFilesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddFilesButton.Location = new System.Drawing.Point(12, 538);
            this.AddFilesButton.Name = "AddFilesButton";
            this.AddFilesButton.Size = new System.Drawing.Size(30, 30);
            this.AddFilesButton.TabIndex = 23;
            this.AddFilesButton.UseVisualStyleBackColor = true;
            this.AddFilesButton.Click += new System.EventHandler(this.AddFilesButton_Click);
            // 
            // MainListBox
            // 
            this.MainListBox.FormattingEnabled = true;
            this.MainListBox.Location = new System.Drawing.Point(12, 30);
            this.MainListBox.Name = "MainListBox";
            this.MainListBox.Size = new System.Drawing.Size(276, 498);
            this.MainListBox.TabIndex = 0;
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(300, 580);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(300, 580);
            this.MinimumSize = new System.Drawing.Size(300, 580);
            this.Name = "PlaylistForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PlaylistForm";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ListBox MainListBox;
        private System.Windows.Forms.Button RemoveFilesButton;
        private System.Windows.Forms.Button AddFilesButton;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Label PlaylistLabel;
        private System.Windows.Forms.Button RenamePlaylistButton;
    }
}