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
            this.TrackBarAudio = new System.Windows.Forms.TrackBar();
            this.SoundLevelTrackBar = new System.Windows.Forms.TrackBar();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.checkBoxRepeatCircle = new System.Windows.Forms.CheckBox();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
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
            this.ClearCurrentPlaylistButton = new System.Windows.Forms.Button();
            this.PlaylistFormButton = new System.Windows.Forms.Button();
            this.RemoveFilesButton = new System.Windows.Forms.Button();
            this.AddFilesButton = new System.Windows.Forms.Button();
            this.ReplayButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.ButtonRollUp = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.titlePictureBox = new System.Windows.Forms.PictureBox();
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.CurrentAudioLabel = new System.Windows.Forms.Label();
            this.contextMenuStripForListBoxItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileDestinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarAudio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoundLevelTrackBar)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.contextMenuStripNI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titlePictureBox)).BeginInit();
            this.contextMenuStripForListBoxItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxMedia
            // 
            this.listBoxMedia.AllowDrop = true;
            this.listBoxMedia.ContextMenuStrip = this.contextMenuStripForListBoxItem;
            this.listBoxMedia.Location = new System.Drawing.Point(12, 366);
            this.listBoxMedia.Name = "listBoxMedia";
            this.listBoxMedia.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxMedia.Size = new System.Drawing.Size(400, 199);
            this.listBoxMedia.TabIndex = 0;
            this.listBoxMedia.SelectedIndexChanged += new System.EventHandler(this.listBoxMedia_SelectedIndexChanged);
            // 
            // TrackBarAudio
            // 
            this.TrackBarAudio.Location = new System.Drawing.Point(0, 312);
            this.TrackBarAudio.Maximum = 0;
            this.TrackBarAudio.Name = "TrackBarAudio";
            this.TrackBarAudio.Size = new System.Drawing.Size(412, 45);
            this.TrackBarAudio.TabIndex = 4;
            // 
            // SoundLevelTrackBar
            // 
            this.SoundLevelTrackBar.Location = new System.Drawing.Point(418, 27);
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
            this.VolumeLabel.Location = new System.Drawing.Point(410, 284);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(42, 13);
            this.VolumeLabel.TabIndex = 6;
            this.VolumeLabel.Text = "Volume";
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(9, 344);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(49, 13);
            this.CurrentTimeLabel.TabIndex = 7;
            this.CurrentTimeLabel.Text = "00:00:00";
            // 
            // checkBoxRepeatCircle
            // 
            this.checkBoxRepeatCircle.AutoSize = true;
            this.checkBoxRepeatCircle.Location = new System.Drawing.Point(310, 283);
            this.checkBoxRepeatCircle.Name = "checkBoxRepeatCircle";
            this.checkBoxRepeatCircle.Size = new System.Drawing.Size(61, 17);
            this.checkBoxRepeatCircle.TabIndex = 8;
            this.checkBoxRepeatCircle.Text = "Repeat";
            this.checkBoxRepeatCircle.UseVisualStyleBackColor = true;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(455, 24);
            this.mainMenuStrip.TabIndex = 9;
            this.mainMenuStrip.Text = "Main menu";
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
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // clearCurrentListToolStripMenuItem
            // 
            this.clearCurrentListToolStripMenuItem.Name = "clearCurrentListToolStripMenuItem";
            this.clearCurrentListToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.clearCurrentListToolStripMenuItem.Text = "Clear current list";
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
            this.TotalDurationLabel.Location = new System.Drawing.Point(363, 344);
            this.TotalDurationLabel.Name = "TotalDurationLabel";
            this.TotalDurationLabel.Size = new System.Drawing.Size(49, 13);
            this.TotalDurationLabel.TabIndex = 16;
            this.TotalDurationLabel.Text = "00:00:00";
            // 
            // checkBoxSavePathToFolder
            // 
            this.checkBoxSavePathToFolder.AutoSize = true;
            this.checkBoxSavePathToFolder.Location = new System.Drawing.Point(226, 283);
            this.checkBoxSavePathToFolder.Name = "checkBoxSavePathToFolder";
            this.checkBoxSavePathToFolder.Size = new System.Drawing.Size(78, 17);
            this.checkBoxSavePathToFolder.TabIndex = 17;
            this.checkBoxSavePathToFolder.Text = "Save path ";
            this.checkBoxSavePathToFolder.UseVisualStyleBackColor = true;
            // 
            // ClearCurrentPlaylistButton
            // 
            this.ClearCurrentPlaylistButton.BackgroundImage = global::MediaPlayer.Properties.Resources.clear;
            this.ClearCurrentPlaylistButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClearCurrentPlaylistButton.Location = new System.Drawing.Point(418, 535);
            this.ClearCurrentPlaylistButton.Name = "ClearCurrentPlaylistButton";
            this.ClearCurrentPlaylistButton.Size = new System.Drawing.Size(30, 30);
            this.ClearCurrentPlaylistButton.TabIndex = 24;
            this.ClearCurrentPlaylistButton.UseVisualStyleBackColor = true;
            this.ClearCurrentPlaylistButton.Click += new System.EventHandler(this.ClearCurrentPlaylistButton_Click);
            // 
            // PlaylistFormButton
            // 
            this.PlaylistFormButton.BackgroundImage = global::MediaPlayer.Properties.Resources.list;
            this.PlaylistFormButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlaylistFormButton.Location = new System.Drawing.Point(418, 312);
            this.PlaylistFormButton.Name = "PlaylistFormButton";
            this.PlaylistFormButton.Size = new System.Drawing.Size(30, 30);
            this.PlaylistFormButton.TabIndex = 23;
            this.PlaylistFormButton.UseVisualStyleBackColor = true;
            this.PlaylistFormButton.Click += new System.EventHandler(this.PlaylistFormButton_Click);
            // 
            // RemoveFilesButton
            // 
            this.RemoveFilesButton.BackgroundImage = global::MediaPlayer.Properties.Resources.minus;
            this.RemoveFilesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RemoveFilesButton.Location = new System.Drawing.Point(418, 438);
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
            this.AddFilesButton.Location = new System.Drawing.Point(418, 402);
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
            this.ButtonRollUp.BackgroundImage = global::MediaPlayer.Properties.Resources.minus;
            this.ButtonRollUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonRollUp.Location = new System.Drawing.Point(406, 4);
            this.ButtonRollUp.Name = "ButtonRollUp";
            this.ButtonRollUp.Size = new System.Drawing.Size(20, 20);
            this.ButtonRollUp.TabIndex = 14;
            this.ButtonRollUp.UseVisualStyleBackColor = false;
            this.ButtonRollUp.Click += new System.EventHandler(this.ButtonRollUp_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonClose.BackgroundImage = global::MediaPlayer.Properties.Resources.cancel;
            this.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonClose.Location = new System.Drawing.Point(432, 4);
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
            this.titlePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.titlePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.titlePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titlePictureBox.Location = new System.Drawing.Point(12, 27);
            this.titlePictureBox.Name = "titlePictureBox";
            this.titlePictureBox.Size = new System.Drawing.Size(400, 250);
            this.titlePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.titlePictureBox.TabIndex = 10;
            this.titlePictureBox.TabStop = false;
            this.titlePictureBox.Click += new System.EventHandler(this.titlePictureBox_Click);
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.BackgroundImage = global::MediaPlayer.Properties.Resources.openFolder;
            this.OpenFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenFolderButton.Location = new System.Drawing.Point(418, 366);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(30, 30);
            this.OpenFolderButton.TabIndex = 3;
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.SelectFolder_Click);
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
            // CurrentAudioLabel
            // 
            this.CurrentAudioLabel.AutoSize = true;
            this.CurrentAudioLabel.Location = new System.Drawing.Point(55, 4);
            this.CurrentAudioLabel.Name = "CurrentAudioLabel";
            this.CurrentAudioLabel.Size = new System.Drawing.Size(67, 13);
            this.CurrentAudioLabel.TabIndex = 25;
            this.CurrentAudioLabel.Text = "Title of Song";
            // 
            // contextMenuStripForListBoxItem
            // 
            this.contextMenuStripForListBoxItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileDestinationToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStripForListBoxItem.Name = "contextMenuStripForListBoxItem";
            this.contextMenuStripForListBoxItem.Size = new System.Drawing.Size(185, 70);
            // 
            // openFileDestinationToolStripMenuItem
            // 
            this.openFileDestinationToolStripMenuItem.Name = "openFileDestinationToolStripMenuItem";
            this.openFileDestinationToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.openFileDestinationToolStripMenuItem.Text = "Open file destination";
            this.openFileDestinationToolStripMenuItem.Click += new System.EventHandler(this.openFileDestinationToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // AudioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(455, 575);
            this.Controls.Add(this.CurrentAudioLabel);
            this.Controls.Add(this.ClearCurrentPlaylistButton);
            this.Controls.Add(this.PlaylistFormButton);
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
            this.Controls.Add(this.CurrentTimeLabel);
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.SoundLevelTrackBar);
            this.Controls.Add(this.TrackBarAudio);
            this.Controls.Add(this.OpenFolderButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.listBoxMedia);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximumSize = new System.Drawing.Size(455, 575);
            this.MinimumSize = new System.Drawing.Size(455, 575);
            this.Name = "AudioPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AudioPlayer";
            this.Load += new System.EventHandler(this.AudioPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarAudio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoundLevelTrackBar)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.contextMenuStripNI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.titlePictureBox)).EndInit();
            this.contextMenuStripForListBoxItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button OpenFolderButton;
        private System.Windows.Forms.TrackBar TrackBarAudio;
        private System.Windows.Forms.TrackBar SoundLevelTrackBar;
        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.Label CurrentTimeLabel;
        private System.Windows.Forms.CheckBox checkBoxRepeatCircle;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
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
        private System.Windows.Forms.Button PlaylistFormButton;
        public System.Windows.Forms.ListBox listBoxMedia;
        private System.Windows.Forms.Button ClearCurrentPlaylistButton;
        private System.Windows.Forms.Label CurrentAudioLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForListBoxItem;
        private System.Windows.Forms.ToolStripMenuItem openFileDestinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}

