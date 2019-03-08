using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace MediaPlayer
{
    public partial class MainForm : Form
    {
        private const string FormatFilter = "Audio Files (*.mp3; *.wav; *.wma; *.flac; *.ogg; *.m4a) " +
                                                        "|*.mp3;*.wav;*.wma;*.flac;*.ogg;*.m4a";

        private PlaylistForm PlaylistForm;
        private SettingsForm SettingsForm;

        private event Action PlaySoundEvent;
        private event Action StopSoundEvent;

        private Point moveStart;
        private System.Windows.Forms.Timer Timer;

        private int CurrentPositionInListMedia = -1;
        private bool isPaused = false;

        public string PathToFolder { get; set; }
        public string PathToImage { get; set; }
        public string PathToDefaultImage { get; set; }
        public bool RollUp { get; set; }
        public bool SavePathToFolder { get; set; }
        public bool RepeatByCircle { get; set; }
        private string currentAudio = null;

        ToolTip openFilesToolTip;
        ToolTip openFolderToolTip;
        ToolTip removeFilesToolTip;
        ToolTip playAudioToolTip;
        ToolTip pauseAudioToolTip;
        ToolTip stopAudioToolTip;
        ToolTip nextAudioToolTip;
        ToolTip previousAudioToolTip;
        ToolTip replayAudioToolTip;
        ToolTip playlistFormButtonToolTip;
        ToolTip clearCurrentPlaylistToolTip;
        ToolTip settingsToolTip;

        private List<string> CurrentPlaylist = new List<string>();

        public MainForm(string[] args)
        {
            InitializeComponent();

            this.CurrentAudioLabel.Text = "";

            this.Timer = new System.Windows.Forms.Timer()
            {
                Enabled = true
            };

            this.Timer.Interval = 1000;

            InitializeToolTips();
            InitializeCustomGraphic();
            RegisterOnEvents();

            OpenWithCommandLine(args);
        }

        private void OpenWithCommandLine(string[] args)
        {
            if (args != null)
            {
                this.listBoxMedia.Items.Clear();
                SavePathToFolder = false;

                PathToFolder = null;
                PathToImage = null;

                foreach (var str in args)
                {
                    if (AcceptedFormat(str))
                    {
                        PathHolder item = new PathHolder(str);
                        this.listBoxMedia.Items.Add(item);
                    }
                }
                PlaySound();
            }
        }

        private void InitializeToolTips()
        {
            openFilesToolTip = new ToolTip();
            openFilesToolTip.SetToolTip(AddFilesButton, "Add audios");

            openFolderToolTip = new ToolTip();
            openFolderToolTip.SetToolTip(OpenFolderButton, "Open folder");

            removeFilesToolTip = new ToolTip();
            removeFilesToolTip.SetToolTip(RemoveFilesButton, "Remove audios");

            playAudioToolTip = new ToolTip();
            playAudioToolTip.SetToolTip(PlayButton, "Play");

            pauseAudioToolTip = new ToolTip();
            pauseAudioToolTip.SetToolTip(PauseButton, "Pause");

            stopAudioToolTip = new ToolTip();
            stopAudioToolTip.SetToolTip(StopButton, "Stop");

            nextAudioToolTip = new ToolTip();
            nextAudioToolTip.SetToolTip(NextButton, "Next");

            previousAudioToolTip = new ToolTip();
            previousAudioToolTip.SetToolTip(PreviousButton, "Previous");

            replayAudioToolTip = new ToolTip();
            replayAudioToolTip.SetToolTip(ReplayButton, "Replay");

            playlistFormButtonToolTip = new ToolTip();
            playlistFormButtonToolTip.SetToolTip(PlaylistFormButton, "Playlists");

            clearCurrentPlaylistToolTip = new ToolTip();
            clearCurrentPlaylistToolTip.SetToolTip(ClearCurrentPlaylistButton, "Clear current playlist");

            settingsToolTip = new ToolTip();
            settingsToolTip.SetToolTip(SettingsButton, "Settings");
        }

        private void RegisterOnEvents()
        {

            this.PlaySoundEvent += PlaySound;
            this.StopSoundEvent += StopAudio;
            this.Timer.Tick += Timer_Tick;


            this.TrackBarAudio.Scroll += TrackBarAudio_Scroll;

            this.listBoxMedia.DoubleClick += ListBoxMedia_DoubleClick;
            this.listBoxMedia.DragDrop += ListBoxMedia_DragDrop;
            this.listBoxMedia.DragEnter += ListBoxMedia_DragEnter;
            this.listBoxMedia.KeyDown += ListBoxMedia_KeyDown;

            this.Resize += AudioPlayer_Resize;
            this.notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

            this.MouseDown += AudioPlayer_MouseDown;
            this.MouseMove += AudioPlayer_MouseMove;

            this.mainMenuStrip.MouseDown += MainMenuStrip_MouseDown;
            this.mainMenuStrip.MouseMove += MainMenuStrip_MouseMove;

            this.FormClosing += AudioPlayer_FormClosing;
            this.LocationChanged += AudioPlayer_LocationChanged;

            this.CurrentAudioLabel.MouseDown += CurrentAudioLabel_MouseDown;
            this.CurrentAudioLabel.MouseMove += CurrentAudioLabel_MouseMove;

            this.Activated += AudioPlayer_Activated;
        }

        private void AudioPlayer_Activated(object sender, EventArgs e) => ResizeUp();

        private void AudioPlayer_LocationChanged(object sender, EventArgs e)
        {
            if (PlaylistForm != null)
                this.PlaylistForm.Location = new Point(this.Location.X + 10 + this.Width, this.Location.Y);
            if (this.SettingsForm != null)
                this.SettingsForm.Location = new Point(this.Location.X - 10 - this.SettingsForm.Width, this.Location.Y);
        }

        private void InitializeCustomGraphic()
        {
            this.contextMenuStripNI.Renderer = new ContextMenuStripExtraRenderer();
            this.contextMenuStripForListBoxItem.Renderer = new ContextMenuStripExtraRenderer();
        }

        private void AudioPlayer_FormClosing(object sender, FormClosingEventArgs e) => SaveSettings();

        private void SaveSettings()
        {
            Properties.Settings.Default.repeatByCircle = this.RepeatByCircle;
            Properties.Settings.Default.savePathToFolder = this.SavePathToFolder;
            Properties.Settings.Default.rollUpTray = this.RollUp;
            Properties.Settings.Default.currentVolume = this.SoundLevelTrackBar.Value;
            Properties.Settings.Default.pathToDefaultImage = this.PathToDefaultImage;

            if (Properties.Settings.Default.savePathToFolder)
            {
                Properties.Settings.Default.pathToFolder = this.PathToFolder;
                Properties.Settings.Default.pathToImage = this.PathToImage;
            }
            else
            {
                Properties.Settings.Default.pathToFolder = null;
                Properties.Settings.Default.pathToImage = null;
            }

            Properties.Settings.Default.Save();
        }

        private void ToolStrip1_MouseMove(object sender, MouseEventArgs e) => MouseMoveHandler(e);
        private void ToolStrip1_MouseDown(object sender, MouseEventArgs e) => MouseDownHandler(e);
        private void MainMenuStrip_MouseMove(object sender, MouseEventArgs e) => MouseMoveHandler(e);
        private void MainMenuStrip_MouseDown(object sender, MouseEventArgs e) => MouseDownHandler(e);
        private void AudioPlayer_MouseMove(object sender, MouseEventArgs e) => MouseMoveHandler(e);
        private void AudioPlayer_MouseDown(object sender, MouseEventArgs e) => MouseDownHandler(e);
        private void CurrentAudioLabel_MouseMove(object sender, MouseEventArgs e) => MouseMoveHandler(e);
        private void CurrentAudioLabel_MouseDown(object sender, MouseEventArgs e) => MouseDownHandler(e);

        private void MouseDownHandler(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.moveStart = new Point(e.X, e.Y);
        }
        private void MouseMoveHandler(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                Point deltaPos = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                this.Location = new Point(this.Location.X + deltaPos.X,
                  this.Location.Y + deltaPos.Y);
            }
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e) => ResizeUp();

        private void ResizeUp()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;

            if (this.PlaylistForm != null)
                this.PlaylistForm.Show();
            if (this.SettingsForm != null)
                this.SettingsForm.Show();
        }

        private void AudioPlayer_Resize(object sender, EventArgs e) => ResizeDown();

        private void ResizeDown()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (RollUp)
                    this.Hide();
                if (this.PlaylistForm != null)
                    this.PlaylistForm.Hide();
                if (this.SettingsForm != null)
                    this.SettingsForm.Hide();
            }
        }

        private void ListBoxMedia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                PlaySoundEvent();
            else if (e.KeyData == Keys.Delete && listBoxMedia.SelectedIndex != -1)
                RemoveFiles();
        }
        private void ListBoxMedia_DragEnter(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (var str in FileList)
            {
                if (AcceptedFormat(str))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void ListBoxMedia_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (var str in FileList)
            {
                if (AcceptedFormat(str))
                {
                    PathHolder item = new PathHolder(str);
                    listBoxMedia.Items.Add(item);
                }
            }
        }

        private bool AcceptedFormat(string str)
        {
            return new Regex(@"(\.mp3)").IsMatch(str) || new Regex(@"(\.wav)").IsMatch(str) ||
                    new Regex(@"(\.wma)").IsMatch(str) || new Regex(@"(\.flac)").IsMatch(str) || 
                    new Regex(@"(\.ogg)").IsMatch(str) || new Regex(@"(\.m4a)").IsMatch(str);
        }

        private void ListBoxMedia_DoubleClick(object sender, EventArgs e)
        {
            int tmpPos = CurrentPositionInListMedia;
            listBoxMedia.ClearSelected();
            listBoxMedia.SetSelected(tmpPos, true);
            StopSoundEvent();
            PlaySoundEvent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.reader != null && !isPaused)
            {
                if (this.TrackBarAudio.Value < this.TrackBarAudio.Maximum)
                    ++this.TrackBarAudio.Value;
                this.CurrentTimeLabel.Text = this.reader.CurrentTime.ToString().Substring(0, 8);
            }
        }
    
        private void TrackBarAudio_Scroll(object sender, EventArgs e)
        {
            if (this.waveOut != null )
            {
                this.reader.CurrentTime = TimeSpan.FromSeconds(this.TrackBarAudio.Value);
            }
        }

        private void ButtonPlay_Click(object sender, EventArgs e) => PlaySoundEvent();


        private void SetupTrackBarAudio()
        {
            this.TrackBarAudio.Value = 0;
            this.TotalDurationLabel.Text = this.reader.TotalTime.ToString().Substring(0, 8);
            this.TrackBarAudio.Maximum = (int)this.reader.TotalTime.TotalSeconds;
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (!isPaused)
                CloseWaveOut();
        }

        private void StopButton_Click(object sender, EventArgs e) => StopSoundEvent();
        private void SelectFolder_Click(object sender, EventArgs e) => OpenFolder();
        private void buttonNext_Click(object sender, EventArgs e) => NextAudio();
        private void buttonPrevious_Click(object sender, EventArgs e) => PreviousAudio();
        private void buttonReplay_Click(object sender, EventArgs e) => Replay();

        private void OpenFolder()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var files = Directory.EnumerateFiles(dialog.SelectedPath, "*.*", SearchOption.TopDirectoryOnly)
                               .Where(s => s.EndsWith(".mp3") || s.EndsWith(".wav") || s.EndsWith(".wma") || s.EndsWith(".flac") || s.EndsWith(".ogg") || s.EndsWith(".m4a"));
                    PathToFolder = dialog.SelectedPath;
                    listBoxMedia.Items.Clear();

                    foreach (var str in files)
                    {
                        PathHolder item = new PathHolder(str);
                        listBoxMedia.Items.Add(item);
                    }
                    if (listBoxMedia.Items.Count != 0)
                        LoadTitleImage();
                    else
                        LoadDefaultImage();                
                }
            }
        }

        private void SoundLevelTrackBar_Scroll(object sender, EventArgs e)
        {
            if (waveOut != null)
                waveOut.Volume = (float)this.SoundLevelTrackBar.Value / 100;
        }

        private void listBoxMedia_SelectedIndexChanged(object sender, EventArgs e) => this.CurrentPositionInListMedia = this.listBoxMedia.SelectedIndex;

        private void AudioPlayer_Load(object sender, EventArgs e)
        {
            LoadPreviousSettings();

            LoadImages();

            LoadPreviousAudioList();

            if (File.Exists(Properties.Settings.Default.pathToImage))
                titlePictureBox.Image = new Bitmap(Properties.Settings.Default.pathToImage);
            else
                LoadDefaultImage();
        }

        private void LoadDefaultImage()
        {
            if (PathToDefaultImage != null && File.Exists(PathToDefaultImage))
                titlePictureBox.Image = new Bitmap(PathToDefaultImage);
            else if (File.Exists(Directory.GetCurrentDirectory() + "\\defaultPicture.jpg"))
                titlePictureBox.Image = new Bitmap(Directory.GetCurrentDirectory() + "\\defaultPicture.jpg");
        }

        private void LoadPreviousSettings()
        {
            this.RepeatByCircle = Properties.Settings.Default.repeatByCircle;
            this.SavePathToFolder = Properties.Settings.Default.savePathToFolder;
            this.RollUp = Properties.Settings.Default.rollUpTray;

            this.SoundLevelTrackBar.Value = Properties.Settings.Default.currentVolume;
            this.PathToImage = Properties.Settings.Default.pathToImage;
            this.PathToFolder = Properties.Settings.Default.pathToFolder;
            this.PathToDefaultImage = Properties.Settings.Default.pathToDefaultImage;
        }

        private void LoadTitleImage()
        {
            if (!String.IsNullOrEmpty(PathToFolder))
            {
                var images = Directory.EnumerateFiles(PathToFolder, "*.*", SearchOption.TopDirectoryOnly)
                      .Where(s => s.EndsWith(".jpg") || s.EndsWith(".png") || s.EndsWith(".bmp")).ToArray();
                if (images.Length != 0)
                {
                    titlePictureBox.Image = new Bitmap(images[0]);
                    this.PathToImage = images[0];
                }
                else if (Directory.Exists(PathToFolder + "//Cover"))
                {
                    images = Directory.EnumerateFiles(PathToFolder + "//Cover", "*.*", SearchOption.TopDirectoryOnly)
                      .Where(s => s.EndsWith(".jpg") || s.EndsWith(".png") || s.EndsWith(".bmp")).ToArray();
                    if (images.Length != 0)
                    {

                        titlePictureBox.Image = new Bitmap(images[0]);
                        this.PathToImage = images[0];
                    }
                }
                else if (Directory.Exists(PathToFolder + "//Covers"))
                {
                    images = Directory.EnumerateFiles(PathToFolder + "//Covers", "*.*", SearchOption.TopDirectoryOnly)
                      .Where(s => s.EndsWith(".jpg") || s.EndsWith(".png") || s.EndsWith(".bmp")).ToArray();
                    if (images.Length != 0)
                    {
                        titlePictureBox.Image = new Bitmap(images[0]);
                        this.PathToImage = images[0];
                    }
                }
            }

            else
                LoadDefaultImage();
        }

        private void LoadPreviousAudioList()
        {
            if (SavePathToFolder)
            {
                bool pathToFolderNotEmpty = !String.IsNullOrEmpty(Properties.Settings.Default.pathToFolder);
                if (pathToFolderNotEmpty)
                {
                    PathToFolder = Properties.Settings.Default.pathToFolder;
                    if (Directory.Exists(PathToFolder))
                    {
                        pathToFolderNotEmpty = true;
                        var files = Directory.EnumerateFiles(PathToFolder, "*.*", SearchOption.TopDirectoryOnly)
                                 .Where(s => s.EndsWith(".mp3") || s.EndsWith(".wav") || s.EndsWith(".wma") || s.EndsWith(".flac") || s.EndsWith(".ogg") || s.EndsWith(".m4a"));
                        foreach (var str in files)
                        {
                            PathHolder item = new PathHolder(str);
                            listBoxMedia.Items.Add(item);
                        }
                    }
                    if (!pathToFolderNotEmpty)
                        PathToFolder = null;
                }
            }
        }

        private void LoadImages()
        {
            this.notifyIcon.Icon = Icon.FromHandle(Properties.Resources.music_player.GetHicon());

            this.Icon = Icon.FromHandle(Properties.Resources.music_player.GetHicon());

            this.BackColor = Color.GhostWhite;
            this.mainMenuStrip.BackColor = Color.GhostWhite;
            
        }
        private void clearCurrentListToolStripMenuItem_Click(object sender, EventArgs e) => ClearCurrentPlaylist();

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e) => OpenFolder();
        private void chooseColorToolStripMenuItem_Click(object sender, EventArgs e) => ShowColorDialog();
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) => OpenSettingsForm();
        private void openFilesToolStripMenuItem_Click(object sender, EventArgs e) => OpenFiles();
        private void ButtonPause_Click(object sender, EventArgs e) => PauseAudio();

        private void ShowColorDialog()
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {

                    this.BackColor = colorDialog.Color;
                    this.mainMenuStrip.BackColor = colorDialog.Color;

                    if (PlaylistForm != null)
                        PlaylistForm.BackColor = colorDialog.Color; ;
                }
            }
        }

        private void toolStripButtonPLay_Click(object sender, EventArgs e) => PlaySoundEvent();
        private void toolStripButtonPause_Click(object sender, EventArgs e) => PauseAudio();
        private void toolStripButtonStop_Click(object sender, EventArgs e) => StopSoundEvent();


        private void toolStripButtonNext_Click(object sender, EventArgs e) => NextAudio();
        private void toolStripButtonPrevious_Click(object sender, EventArgs e) => PreviousAudio();

        private void NextAudio()
        {
            if (listBoxMedia.Items.Count == 0)
                return;
            else
            {
                int currentPosition = this.listBoxMedia.FindString(currentAudio);
                int tmpPos = currentPosition;

                if (currentPosition == listBoxMedia.Items.Count - 1 || currentPosition == -1)
                    tmpPos = 0;
                else
                    tmpPos = ++currentPosition;

                this.listBoxMedia.ClearSelected();
                this.listBoxMedia.SetSelected(tmpPos, true);
                PlaySoundEvent();
            }
        }

        private void PreviousAudio()
        {
            if (listBoxMedia.Items.Count == 0)
                return;
            else
            {
                int currentPosition = this.listBoxMedia.FindString(currentAudio);
                int tmpPos = currentPosition;

                if (currentPosition == 0 || currentPosition == -1)
                    tmpPos = listBoxMedia.Items.Count - 1;
                else
                    tmpPos = --currentPosition;

                this.listBoxMedia.ClearSelected();
                this.listBoxMedia.SetSelected(tmpPos, true);
                PlaySoundEvent();
            }
        }

        private void toolStripButtonRepeat_Click(object sender, EventArgs e) => Replay();

        private void Replay()
        {
            if (waveOut != null)
                PlaySoundEvent();
        }

        private void ButtonClose_Click(object sender, EventArgs e) => this.Close();
        private void ButtonRollUp_Click(object sender, EventArgs e)
        {
                this.WindowState = FormWindowState.Minimized;
            //this.notifyIcon.ShowBalloonTip(5000);
        }

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();
        private void playToolStripMenuItem_Click(object sender, EventArgs e) => PlaySoundEvent();
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e) => PauseAudio();
        private void stopToolStripMenuItem_Click(object sender, EventArgs e) => StopSoundEvent();
        private void nextToolStripMenuItem_Click(object sender, EventArgs e) => NextAudio();
        private void previousToolStripMenuItem_Click(object sender, EventArgs e) => PreviousAudio();
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();
        private void OpenFileButton_Click(object sender, EventArgs e) => OpenFiles();
        private void ClearCurrentPlaylistButton_Click(object sender, EventArgs e) => ClearCurrentPlaylist();

        private void OpenFiles()
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Multiselect = true;
                fileDialog.Filter = FormatFilter;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (fileDialog.FileNames.Length != 0)
                    {
                        foreach (var str in fileDialog.FileNames)
                        {
                            PathHolder item = new PathHolder(str);
                            listBoxMedia.Items.Add(item);
                        }
                    }
                    if (fileDialog.FileNames.Length == 1)
                        PlaySoundEvent();
                }
            }
        }

        private void buttonAddFile_Click(object sender, EventArgs e) => OpenFiles();
        private void buttonRemoveFiles_Click(object sender, EventArgs e) => RemoveFiles();

        private void RemoveFiles()
        {
            if (listBoxMedia.SelectedItems != null)
            {
                var selectedItems = listBoxMedia.SelectedItems;
                for (int i = selectedItems.Count - 1; i >= 0; --i)
                    this.listBoxMedia.Items.Remove(selectedItems[i]);
            }
        }

        private void PlaylistFormButton_Click(object sender, EventArgs e) => CreatePlaylistForm();

        private void CreatePlaylistForm()
        {
            if (PlaylistForm == null)
            {
                PlaylistForm = new PlaylistForm(this);
                PlaylistForm.Show();
            }
            else 
            {
                PlaylistForm.Close();
                PlaylistForm.Dispose();
                PlaylistForm = null;
            }
        }
       
        private void ClearCurrentPlaylist()
        {
            StopSoundEvent();
            LoadDefaultImage();
            this.PathToFolder = null;
            this.PathToImage = null;

            this.CurrentAudioLabel.Text = null;

            this.listBoxMedia.Items.Clear();
        }

        private void titlePictureBox_Click(object sender, EventArgs e) => OpenImage();

        private void OpenImage()
        {
            if (File.Exists(PathToImage))
                Process.Start(PathToImage);
            else if (File.Exists(PathToDefaultImage))
                Process.Start(PathToImage);
            else if (File.Exists("defaultPicture.jpg"))
                Process.Start("defaultPicture.jpg");
        }

        private void openFileDestinationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var curAudio = (listBoxMedia.SelectedItem as PathHolder);
            if (File.Exists(curAudio.FullPath))
            {
                var splitedPath = curAudio.FullPath.Split('\\').ToList();
                splitedPath.RemoveAt(splitedPath.Count - 1);
                string path = string.Join("\\", splitedPath.ToArray());

                Process.Start(path);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e) => RemoveFiles();

        private void CredentialButton_Click(object sender, EventArgs e) 
        {

        }

        private void SettingsButton_Click(object sender, EventArgs e) => OpenSettingsForm();

        private void OpenSettingsForm()
        {
            if (SettingsForm == null)
            {
                this.SettingsForm = new SettingsForm(this);
                this.SettingsForm.Show();
            }
            else
            {
                this.SettingsForm.Close();
                this.SettingsForm.Dispose();
                this.SettingsForm = null;
            }
        }
    }
}
