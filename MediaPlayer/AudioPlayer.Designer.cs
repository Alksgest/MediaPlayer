namespace MediaPlayer
{
    partial class AudioPlayer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxMedia = new System.Windows.Forms.ListBox();
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.TrackBarAudio = new System.Windows.Forms.TrackBar();
            this.SoundLevelTrackBar = new System.Windows.Forms.TrackBar();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.checkBoxRepeatCircle = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCurrentListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNI = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TotalDurationLabel = new System.Windows.Forms.Label();
            this.checkBoxSavePathToFolder = new System.Windows.Forms.CheckBox();
            this.RemoveFilesButton = new System.Windows.Forms.Button();
            this.AddFilesButton = new System.Windows.Forms.Button();
            this.ReplayButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.ButtonRollUp = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.titlePictureBox = new System.Windows.Forms.PictureBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarAudio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoundLevelTrackBar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripNI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titlePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxMedia
            // 
            this.listBoxMedia.AllowDrop = true;
            this.listBoxMedia.Location = new System.Drawing.Point(12, 366);
            this.listBoxMedia.Name = "listBoxMedia";
            this.listBoxMedia.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMedia.Size = new System.Drawing.Size(465, 199);
            this.listBoxMedia.TabIndex = 0;
            this.listBoxMedia.SelectedIndexChanged += new System.EventHandler(this.listBoxMedia_SelectedIndexChanged);
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.BackgroundImage = global::MediaPlayer.Properties.Resources.openFolder;
            this.OpenFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenFolderButton.Location = new System.Drawing.Point(483, 366);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(30, 30);
            this.OpenFolderButton.TabIndex = 3;
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // TrackBarAudio
            // 
            this.TrackBarAudio.Location = new System.Drawing.Point(0, 312);
            this.TrackBarAudio.Maximum = 1000;
            this.TrackBarAudio.Name = "TrackBarAudio";
            this.TrackBarAudio.Size = new System.Drawing.Size(477, 45);
            this.TrackBarAudio.TabIndex = 4;
            // 
            // SoundLevelTrackBar
            // 
            this.SoundLevelTrackBar.Location = new System.Drawing.Point(483, 27);
            this.SoundLevelTrackBar.Maximum = 100;
            this.SoundLevelTrackBar.Name = "SoundLevelTrackBar";
            this.SoundLevelTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SoundLevelTrackBar.Size = new System.Drawing.Size(45, 253);
            this.SoundLevelTrackBar.TabIndex = 5;
            this.SoundLevelTrackBar.Value = 100;
            this.SoundLevelTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.AutoSize = true;
            this.VolumeLabel.Location = new System.Drawing.Point(473, 283);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(42, 13);
            this.VolumeLabel.TabIndex = 6;
            this.VolumeLabel.Text = "Volume";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(27, 347);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(49, 13);
            this.TimeLabel.TabIndex = 7;
            this.TimeLabel.Text = "00:00:00";
            // 
            // checkBoxRepeatCircle
            // 
            this.checkBoxRepeatCircle.AutoSize = true;
            this.checkBoxRepeatCircle.Location = new System.Drawing.Point(392, 283);
            this.checkBoxRepeatCircle.Name = "checkBoxRepeatCircle";
            this.checkBoxRepeatCircle.Size = new System.Drawing.Size(75, 17);
            this.checkBoxRepeatCircle.TabIndex = 8;
            this.checkBoxRepeatCircle.Text = "Repeat All";
            this.checkBoxRepeatCircle.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(520, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFilesToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.clearCurrentListToolStripMenuItem,
            this.ChooseToolStripMenuItem,
            this.dsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFilesToolStripMenuItem
            // 
            this.openFilesToolStripMenuItem.Name = "openFilesToolStripMenuItem";
            this.openFilesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.openFilesToolStripMenuItem.Text = "Open files";
            this.openFilesToolStripMenuItem.Click += new System.EventHandler(this.openFilesToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.openFolderToolStripMenuItem.Text = "Open folder";
            this.openFolderToolStripMenuItem.ToolTipText = "Выбор папки с аудиофайлами";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // clearCurrentListToolStripMenuItem
            // 
            this.clearCurrentListToolStripMenuItem.Name = "clearCurrentListToolStripMenuItem";
            this.clearCurrentListToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.clearCurrentListToolStripMenuItem.Text = "Clear current list";
            this.clearCurrentListToolStripMenuItem.ToolTipText = "Очищает текущий список воспроизведения";
            this.clearCurrentListToolStripMenuItem.Click += new System.EventHandler(this.clearCurrentListToolStripMenuItem_Click);
            // 
            // ChooseToolStripMenuItem
            // 
            this.ChooseToolStripMenuItem.Name = "ChooseToolStripMenuItem";
            this.ChooseToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.ChooseToolStripMenuItem.Text = "Choose color scheme";
            this.ChooseToolStripMenuItem.Click += new System.EventHandler(this.chooseColorToolStripMenuItem_Click);
            // 
            // dsToolStripMenuItem
            // 
            this.dsToolStripMenuItem.Name = "dsToolStripMenuItem";
            this.dsToolStripMenuItem.Size = new System.Drawing.Size(185, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "But it is still working";
            this.notifyIcon.BalloonTipTitle = "Program was hiding.";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStripNI;
            this.notifyIcon.Text = "MediaPlayer";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStripNI
            // 
            this.contextMenuStripNI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandToolStripMenuItem,
            this.playToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.nextToolStripMenuItem,
            this.previousToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStripNI.Name = "contextMenuStripNI";
            this.contextMenuStripNI.Size = new System.Drawing.Size(120, 158);
            // 
            // expandToolStripMenuItem
            // 
            this.expandToolStripMenuItem.Name = "expandToolStripMenuItem";
            this.expandToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.expandToolStripMenuItem.Text = "Expand";
            this.expandToolStripMenuItem.Click += new System.EventHandler(this.expandToolStripMenuItem_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.nextToolStripMenuItem.Text = "Next";
            this.nextToolStripMenuItem.Click += new System.EventHandler(this.nextToolStripMenuItem_Click);
            // 
            // previousToolStripMenuItem
            // 
            this.previousToolStripMenuItem.Name = "previousToolStripMenuItem";
            this.previousToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.previousToolStripMenuItem.Text = "Previous";
            this.previousToolStripMenuItem.Click += new System.EventHandler(this.previousToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // TotalDurationLabel
            // 
            this.TotalDurationLabel.AutoSize = true;
            this.TotalDurationLabel.Location = new System.Drawing.Point(428, 344);
            this.TotalDurationLabel.Name = "TotalDurationLabel";
            this.TotalDurationLabel.Size = new System.Drawing.Size(49, 13);
            this.TotalDurationLabel.TabIndex = 16;
            this.TotalDurationLabel.Text = "00:00:00";
            // 
            // checkBoxSavePathToFolder
            // 
            this.checkBoxSavePathToFolder.AutoSize = true;
            this.checkBoxSavePathToFolder.Location = new System.Drawing.Point(270, 283);
            this.checkBoxSavePathToFolder.Name = "checkBoxSavePathToFolder";
            this.checkBoxSavePathToFolder.Size = new System.Drawing.Size(116, 17);
            this.checkBoxSavePathToFolder.TabIndex = 17;
            this.checkBoxSavePathToFolder.Text = "Save path to folder";
            this.checkBoxSavePathToFolder.UseVisualStyleBackColor = true;
            // 
            // RemoveFilesButton
            // 
            this.RemoveFilesButton.BackgroundImage = global::MediaPlayer.Properties.Resources.minus;
            this.RemoveFilesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveFilesButton.Location = new System.Drawing.Point(483, 438);
            this.RemoveFilesButton.Name = "RemoveFilesButton";
            this.RemoveFilesButton.Size = new System.Drawing.Size(30, 30);
            this.RemoveFilesButton.TabIndex = 22;
            this.RemoveFilesButton.UseVisualStyleBackColor = true;
            this.RemoveFilesButton.Click += new System.EventHandler(this.buttonRemoveFiles_Click);
            // 
            // AddFilesButton
            // 
            this.AddFilesButton.BackgroundImage = global::MediaPlayer.Properties.Resources.plus;
            this.AddFilesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddFilesButton.Location = new System.Drawing.Point(483, 402);
            this.AddFilesButton.Name = "AddFilesButton";
            this.AddFilesButton.Size = new System.Drawing.Size(30, 30);
            this.AddFilesButton.TabIndex = 21;
            this.AddFilesButton.UseVisualStyleBackColor = true;
            this.AddFilesButton.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // ReplayButton
            // 
            this.ReplayButton.BackgroundImage = global::MediaPlayer.Properties.Resources.replay;
            this.ReplayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReplayButton.Location = new System.Drawing.Point(190, 283);
            this.ReplayButton.Name = "ReplayButton";
            this.ReplayButton.Size = new System.Drawing.Size(30, 30);
            this.ReplayButton.TabIndex = 20;
            this.ReplayButton.UseVisualStyleBackColor = true;
            this.ReplayButton.Click += new System.EventHandler(this.buttonReplay_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.BackgroundImage = global::MediaPlayer.Properties.Resources.back_1;
            this.PreviousButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviousButton.Location = new System.Drawing.Point(118, 283);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(30, 30);
            this.PreviousButton.TabIndex = 19;
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // NextButton
            // 
            this.NextButton.BackgroundImage = global::MediaPlayer.Properties.Resources.next_1;
            this.NextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NextButton.Location = new System.Drawing.Point(154, 283);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(30, 30);
            this.NextButton.TabIndex = 18;
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // ButtonRollUp
            // 
            this.ButtonRollUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonRollUp.Image = global::MediaPlayer.Properties.Resources.minus;
            this.ButtonRollUp.Location = new System.Drawing.Point(469, 4);
            this.ButtonRollUp.Name = "ButtonRollUp";
            this.ButtonRollUp.Size = new System.Drawing.Size(20, 20);
            this.ButtonRollUp.TabIndex = 14;
            this.ButtonRollUp.UseVisualStyleBackColor = false;
            this.ButtonRollUp.Click += new System.EventHandler(this.ButtonRollUp_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonClose.Image = global::MediaPlayer.Properties.Resources.cancel;
            this.ButtonClose.Location = new System.Drawing.Point(495, 4);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(20, 20);
            this.ButtonClose.TabIndex = 13;
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.BackgroundImage = global::MediaPlayer.Properties.Resources.pause;
            this.PauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PauseButton.Location = new System.Drawing.Point(46, 283);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(30, 30);
            this.PauseButton.TabIndex = 11;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // titlePictureBox
            // 
            this.titlePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.titlePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titlePictureBox.Location = new System.Drawing.Point(12, 27);
            this.titlePictureBox.Name = "titlePictureBox";
            this.titlePictureBox.Size = new System.Drawing.Size(465, 250);
            this.titlePictureBox.TabIndex = 10;
            this.titlePictureBox.TabStop = false;
            // 
            // StopButton
            // 
            this.StopButton.BackgroundImage = global::MediaPlayer.Properties.Resources.stop;
            this.StopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StopButton.Location = new System.Drawing.Point(82, 283);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(30, 30);
            this.StopButton.TabIndex = 2;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackgroundImage = global::MediaPlayer.Properties.Resources.play_button;
            this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayButton.Location = new System.Drawing.Point(10, 283);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(30, 30);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // AudioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(520, 580);
            this.Controls.Add(this.RemoveFilesButton);
            this.Controls.Add(this.AddFilesButton);
            this.Controls.Add(this.ReplayButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.checkBoxSavePathToFolder);
            this.Controls.Add(this.TotalDurationLabel);
            this.Controls.Add(this.ButtonRollUp);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.titlePictureBox);
            this.Controls.Add(this.checkBoxRepeatCircle);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.SoundLevelTrackBar);
            this.Controls.Add(this.TrackBarAudio);
            this.Controls.Add(this.OpenFolderButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.listBoxMedia);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(520, 680);
            this.MinimumSize = new System.Drawing.Size(520, 580);
            this.Name = "AudioPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AudioPlayer";
            this.Load += new System.EventHandler(this.AudioPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarAudio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoundLevelTrackBar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripNI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.titlePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMedia;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button OpenFolderButton;
        private System.Windows.Forms.TrackBar TrackBarAudio;
        private System.Windows.Forms.TrackBar SoundLevelTrackBar;
        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.CheckBox checkBoxRepeatCircle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearCurrentListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.PictureBox titlePictureBox;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonRollUp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNI;
        private System.Windows.Forms.ToolStripMenuItem expandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label TotalDurationLabel;
        private System.Windows.Forms.CheckBox checkBoxSavePathToFolder;
        private System.Windows.Forms.ToolStripMenuItem ChooseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator dsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFilesToolStripMenuItem;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button ReplayButton;
        private System.Windows.Forms.Button AddFilesButton;
        private System.Windows.Forms.Button RemoveFilesButton;
    }
}

