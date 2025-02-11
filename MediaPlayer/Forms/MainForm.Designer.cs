namespace MediaPlayer.Forms
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            listBoxMedia = new System.Windows.Forms.ListBox();
            contextMenuStripForListBoxItem = new System.Windows.Forms.ContextMenuStrip(components);
            openFileDestinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            CurrentTimeLabel = new System.Windows.Forms.Label();
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearCurrentListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ChooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dsToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            notifyIcon = new System.Windows.Forms.NotifyIcon(components);
            contextMenuStripNI = new System.Windows.Forms.ContextMenuStrip(components);
            expandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            previousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            TotalDurationLabel = new System.Windows.Forms.Label();
            CurrentAudioLabel = new System.Windows.Forms.Label();
            SettingsButton = new System.Windows.Forms.Button();
            CredentialButton = new System.Windows.Forms.Button();
            ClearCurrentPlaylistButton = new System.Windows.Forms.Button();
            PlaylistFormButton = new System.Windows.Forms.Button();
            RemoveFilesButton = new System.Windows.Forms.Button();
            AddFilesButton = new System.Windows.Forms.Button();
            ReplayButton = new System.Windows.Forms.Button();
            PreviousButton = new System.Windows.Forms.Button();
            NextButton = new System.Windows.Forms.Button();
            ButtonRollUp = new System.Windows.Forms.Button();
            ButtonClose = new System.Windows.Forms.Button();
            PlayButton = new System.Windows.Forms.Button();
            TrackBarAudio = new Controls.Slider();
            SoundLevelTrackBar = new Controls.Slider();
            contextMenuStripForListBoxItem.SuspendLayout();
            mainMenuStrip.SuspendLayout();
            contextMenuStripNI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackBarAudio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SoundLevelTrackBar).BeginInit();
            SuspendLayout();
            // 
            // listBoxMedia
            // 
            listBoxMedia.AllowDrop = true;
            listBoxMedia.ContextMenuStrip = contextMenuStripForListBoxItem;
            listBoxMedia.Location = new System.Drawing.Point(13, 41);
            listBoxMedia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listBoxMedia.Name = "listBoxMedia";
            listBoxMedia.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            listBoxMedia.Size = new System.Drawing.Size(320, 169);
            listBoxMedia.TabIndex = 0;
            listBoxMedia.SelectedIndexChanged += listBoxMedia_SelectedIndexChanged;
            // 
            // contextMenuStripForListBoxItem
            // 
            contextMenuStripForListBoxItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { openFileDestinationToolStripMenuItem, removeToolStripMenuItem });
            contextMenuStripForListBoxItem.Name = "contextMenuStripForListBoxItem";
            contextMenuStripForListBoxItem.Size = new System.Drawing.Size(185, 48);
            // 
            // openFileDestinationToolStripMenuItem
            // 
            openFileDestinationToolStripMenuItem.Name = "openFileDestinationToolStripMenuItem";
            openFileDestinationToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            openFileDestinationToolStripMenuItem.Text = "Open file destination";
            openFileDestinationToolStripMenuItem.Click += openFileDestinationToolStripMenuItem_Click;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // CurrentTimeLabel
            // 
            CurrentTimeLabel.AutoSize = true;
            CurrentTimeLabel.Location = new System.Drawing.Point(6, 239);
            CurrentTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            CurrentTimeLabel.Name = "CurrentTimeLabel";
            CurrentTimeLabel.Size = new System.Drawing.Size(49, 15);
            CurrentTimeLabel.TabIndex = 7;
            CurrentTimeLabel.Text = "00:00:00";
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem });
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            mainMenuStrip.Size = new System.Drawing.Size(360, 24);
            mainMenuStrip.TabIndex = 9;
            mainMenuStrip.Text = "Main menu";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openFilesToolStripMenuItem, openFolderToolStripMenuItem, clearCurrentListToolStripMenuItem, settingsToolStripMenuItem, ChooseToolStripMenuItem, dsToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            fileToolStripMenuItem.Visible = false;
            // 
            // openFilesToolStripMenuItem
            // 
            openFilesToolStripMenuItem.Name = "openFilesToolStripMenuItem";
            openFilesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            openFilesToolStripMenuItem.Text = "Open files";
            openFilesToolStripMenuItem.Click += openFilesToolStripMenuItem_Click;
            // 
            // openFolderToolStripMenuItem
            // 
            openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            openFolderToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            openFolderToolStripMenuItem.Text = "Open folder";
            openFolderToolStripMenuItem.Click += openFolderToolStripMenuItem_Click;
            // 
            // clearCurrentListToolStripMenuItem
            // 
            clearCurrentListToolStripMenuItem.Name = "clearCurrentListToolStripMenuItem";
            clearCurrentListToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            clearCurrentListToolStripMenuItem.Text = "Clear current list";
            clearCurrentListToolStripMenuItem.Click += clearCurrentListToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // ChooseToolStripMenuItem
            // 
            ChooseToolStripMenuItem.Name = "ChooseToolStripMenuItem";
            ChooseToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            ChooseToolStripMenuItem.Text = "Choose color scheme";
            ChooseToolStripMenuItem.Click += chooseColorToolStripMenuItem_Click;
            // 
            // dsToolStripMenuItem
            // 
            dsToolStripMenuItem.Name = "dsToolStripMenuItem";
            dsToolStripMenuItem.Size = new System.Drawing.Size(185, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipText = "But it is still working";
            notifyIcon.BalloonTipTitle = "Program was hidden.";
            notifyIcon.ContextMenuStrip = contextMenuStripNI;
            notifyIcon.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "MediaPlayer";
            notifyIcon.Visible = true;
            // 
            // contextMenuStripNI
            // 
            contextMenuStripNI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { expandToolStripMenuItem, playToolStripMenuItem, pauseToolStripMenuItem, stopToolStripMenuItem, nextToolStripMenuItem, previousToolStripMenuItem, closeToolStripMenuItem });
            contextMenuStripNI.Name = "contextMenuStripNI";
            contextMenuStripNI.Size = new System.Drawing.Size(120, 158);
            // 
            // expandToolStripMenuItem
            // 
            expandToolStripMenuItem.Name = "expandToolStripMenuItem";
            expandToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            expandToolStripMenuItem.Text = "Expand";
            expandToolStripMenuItem.Click += expandToolStripMenuItem_Click;
            // 
            // playToolStripMenuItem
            // 
            playToolStripMenuItem.Name = "playToolStripMenuItem";
            playToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            playToolStripMenuItem.Text = "Play";
            playToolStripMenuItem.Click += playToolStripMenuItem_Click;
            // 
            // pauseToolStripMenuItem
            // 
            pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            pauseToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            pauseToolStripMenuItem.Text = "Pause";
            pauseToolStripMenuItem.Click += pauseToolStripMenuItem_Click;
            // 
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            stopToolStripMenuItem.Text = "Stop";
            stopToolStripMenuItem.Click += stopToolStripMenuItem_Click;
            // 
            // nextToolStripMenuItem
            // 
            nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            nextToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            nextToolStripMenuItem.Text = "Next";
            nextToolStripMenuItem.Click += nextToolStripMenuItem_Click;
            // 
            // previousToolStripMenuItem
            // 
            previousToolStripMenuItem.Name = "previousToolStripMenuItem";
            previousToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            previousToolStripMenuItem.Text = "Previous";
            previousToolStripMenuItem.Click += previousToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // TotalDurationLabel
            // 
            TotalDurationLabel.AutoSize = true;
            TotalDurationLabel.Location = new System.Drawing.Point(284, 236);
            TotalDurationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            TotalDurationLabel.Name = "TotalDurationLabel";
            TotalDurationLabel.Size = new System.Drawing.Size(49, 15);
            TotalDurationLabel.TabIndex = 16;
            TotalDurationLabel.Text = "00:00:00";
            // 
            // CurrentAudioLabel
            // 
            CurrentAudioLabel.AutoSize = true;
            CurrentAudioLabel.Location = new System.Drawing.Point(50, 6);
            CurrentAudioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            CurrentAudioLabel.Name = "CurrentAudioLabel";
            CurrentAudioLabel.Size = new System.Drawing.Size(73, 15);
            CurrentAudioLabel.TabIndex = 25;
            CurrentAudioLabel.Text = "Title of Song";
            // 
            // SettingsButton
            // 
            SettingsButton.BackgroundImage = Properties.Resources.settings;
            SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            SettingsButton.Location = new System.Drawing.Point(312, 254);
            SettingsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new System.Drawing.Size(35, 35);
            SettingsButton.TabIndex = 28;
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // CredentialButton
            // 
            CredentialButton.BackgroundImage = Properties.Resources.credentials;
            CredentialButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            CredentialButton.Location = new System.Drawing.Point(220, 12);
            CredentialButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CredentialButton.Name = "CredentialButton";
            CredentialButton.Size = new System.Drawing.Size(23, 23);
            CredentialButton.TabIndex = 27;
            CredentialButton.UseVisualStyleBackColor = false;
            CredentialButton.Visible = false;
            // 
            // ClearCurrentPlaylistButton
            // 
            ClearCurrentPlaylistButton.BackgroundImage = Properties.Resources.clear;
            ClearCurrentPlaylistButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClearCurrentPlaylistButton.Location = new System.Drawing.Point(486, 617);
            ClearCurrentPlaylistButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ClearCurrentPlaylistButton.Name = "ClearCurrentPlaylistButton";
            ClearCurrentPlaylistButton.Size = new System.Drawing.Size(35, 35);
            ClearCurrentPlaylistButton.TabIndex = 24;
            ClearCurrentPlaylistButton.UseVisualStyleBackColor = true;
            ClearCurrentPlaylistButton.Click += ClearCurrentPlaylistButton_Click;
            // 
            // PlaylistFormButton
            // 
            PlaylistFormButton.BackgroundImage = Properties.Resources.list;
            PlaylistFormButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            PlaylistFormButton.Location = new System.Drawing.Point(269, 254);
            PlaylistFormButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PlaylistFormButton.Name = "PlaylistFormButton";
            PlaylistFormButton.Size = new System.Drawing.Size(35, 35);
            PlaylistFormButton.TabIndex = 23;
            PlaylistFormButton.UseVisualStyleBackColor = true;
            PlaylistFormButton.Click += PlaylistFormButton_Click;
            // 
            // RemoveFilesButton
            // 
            RemoveFilesButton.BackgroundImage = Properties.Resources.minus;
            RemoveFilesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            RemoveFilesButton.Location = new System.Drawing.Point(275, 52);
            RemoveFilesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RemoveFilesButton.Name = "RemoveFilesButton";
            RemoveFilesButton.Size = new System.Drawing.Size(25, 25);
            RemoveFilesButton.TabIndex = 22;
            RemoveFilesButton.UseVisualStyleBackColor = true;
            RemoveFilesButton.Click += buttonRemoveFiles_Click;
            // 
            // AddFilesButton
            // 
            AddFilesButton.BackgroundImage = Properties.Resources.plus;
            AddFilesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            AddFilesButton.Location = new System.Drawing.Point(308, 52);
            AddFilesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            AddFilesButton.Name = "AddFilesButton";
            AddFilesButton.Size = new System.Drawing.Size(25, 25);
            AddFilesButton.TabIndex = 21;
            AddFilesButton.UseVisualStyleBackColor = true;
            AddFilesButton.Click += buttonAddFile_Click;
            // 
            // ReplayButton
            // 
            ReplayButton.BackgroundImage = Properties.Resources.replay;
            ReplayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ReplayButton.Location = new System.Drawing.Point(6, 257);
            ReplayButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ReplayButton.Name = "ReplayButton";
            ReplayButton.Size = new System.Drawing.Size(35, 35);
            ReplayButton.TabIndex = 20;
            ReplayButton.UseVisualStyleBackColor = true;
            ReplayButton.Click += buttonReplay_Click;
            // 
            // PreviousButton
            // 
            PreviousButton.BackgroundImage = Properties.Resources.back_1;
            PreviousButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            PreviousButton.Location = new System.Drawing.Point(117, 257);
            PreviousButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PreviousButton.Name = "PreviousButton";
            PreviousButton.Size = new System.Drawing.Size(35, 35);
            PreviousButton.TabIndex = 19;
            PreviousButton.UseVisualStyleBackColor = true;
            PreviousButton.Click += buttonPrevious_Click;
            // 
            // NextButton
            // 
            NextButton.BackgroundImage = Properties.Resources.next_1;
            NextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            NextButton.Location = new System.Drawing.Point(203, 257);
            NextButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NextButton.Name = "NextButton";
            NextButton.Size = new System.Drawing.Size(35, 35);
            NextButton.TabIndex = 18;
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += buttonNext_Click;
            // 
            // ButtonRollUp
            // 
            ButtonRollUp.BackgroundImage = Properties.Resources.minus;
            ButtonRollUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ButtonRollUp.Location = new System.Drawing.Point(293, 12);
            ButtonRollUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ButtonRollUp.Name = "ButtonRollUp";
            ButtonRollUp.Size = new System.Drawing.Size(23, 23);
            ButtonRollUp.TabIndex = 14;
            ButtonRollUp.UseVisualStyleBackColor = false;
            ButtonRollUp.Click += ButtonRollUp_Click;
            // 
            // ButtonClose
            // 
            ButtonClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            ButtonClose.BackgroundImage = Properties.Resources.cancel;
            ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ButtonClose.Location = new System.Drawing.Point(324, 12);
            ButtonClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new System.Drawing.Size(23, 23);
            ButtonClose.TabIndex = 13;
            ButtonClose.UseVisualStyleBackColor = false;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // PlayButton
            // 
            PlayButton.BackgroundImage = Properties.Resources.play_button;
            PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            PlayButton.Location = new System.Drawing.Point(160, 257);
            PlayButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new System.Drawing.Size(35, 35);
            PlayButton.TabIndex = 1;
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Click += ButtonPlay_Click;
            // 
            // TrackBarAudio
            // 
            TrackBarAudio.Location = new System.Drawing.Point(12, 216);
            TrackBarAudio.Maximum = 0;
            TrackBarAudio.MaximumSize = new System.Drawing.Size(0, 20);
            TrackBarAudio.MinimumSize = new System.Drawing.Size(0, 10);
            TrackBarAudio.Name = "TrackBarAudio";
            TrackBarAudio.Size = new System.Drawing.Size(321, 20);
            TrackBarAudio.TabIndex = 29;
            TrackBarAudio.TickStyle = System.Windows.Forms.TickStyle.None;
            TrackBarAudio.Scroll += TrackBarAudio_Scroll;
            // 
            // SoundLevelTrackBar
            // 
            SoundLevelTrackBar.Location = new System.Drawing.Point(335, 41);
            SoundLevelTrackBar.Maximum = 100;
            SoundLevelTrackBar.MaximumSize = new System.Drawing.Size(20, 0);
            SoundLevelTrackBar.MinimumSize = new System.Drawing.Size(0, 10);
            SoundLevelTrackBar.Name = "SoundLevelTrackBar";
            SoundLevelTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            SoundLevelTrackBar.Size = new System.Drawing.Size(20, 169);
            SoundLevelTrackBar.TabIndex = 30;
            SoundLevelTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            SoundLevelTrackBar.Scroll += SoundLevelTrackBar_Scroll;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ButtonHighlight;
            ClientSize = new System.Drawing.Size(360, 300);
            Controls.Add(SoundLevelTrackBar);
            Controls.Add(TrackBarAudio);
            Controls.Add(SettingsButton);
            Controls.Add(CredentialButton);
            Controls.Add(CurrentAudioLabel);
            Controls.Add(ClearCurrentPlaylistButton);
            Controls.Add(PlaylistFormButton);
            Controls.Add(RemoveFilesButton);
            Controls.Add(AddFilesButton);
            Controls.Add(ReplayButton);
            Controls.Add(PreviousButton);
            Controls.Add(NextButton);
            Controls.Add(TotalDurationLabel);
            Controls.Add(ButtonRollUp);
            Controls.Add(ButtonClose);
            Controls.Add(CurrentTimeLabel);
            Controls.Add(PlayButton);
            Controls.Add(listBoxMedia);
            Controls.Add(mainMenuStrip);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MainMenuStrip = mainMenuStrip;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximumSize = new System.Drawing.Size(531, 663);
            Name = "MainForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = resources.GetString("$this.Text");
            Load += MainForm_Load;
            contextMenuStripForListBoxItem.ResumeLayout(false);
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            contextMenuStripNI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TrackBarAudio).EndInit();
            ((System.ComponentModel.ISupportInitialize)SoundLevelTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Label CurrentTimeLabel;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearCurrentListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
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
        private System.Windows.Forms.Button CredentialButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private Controls.Slider TrackBarAudio;
        private Controls.Slider SoundLevelTrackBar;
    }
}

