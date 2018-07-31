using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace MediaPlayer
{
    public partial class AudioPlayer : Form
    {
        private const string FormatFilter = "Audio Files (*.mp3; *.wav; *.wma; *.flac; *.ogg; *.m4a) |*.mp3;*.wav;*.wma;*.flac;*.ogg;*.m4a";
        private PlaylistForm playlistForm;
        private SettingsForm settingsForm;

        private WaveOut waveOut;
        private AudioFileReader reader;

        private Point moveStart;
        private System.Windows.Forms.Timer timer;

        private int CurrentPositionInListMedia = -1;
        private bool isPaused = false;

        public string PathToFolder { get; set; }
        public string PathToImage { get; set; }
        private string currentAudio = null;

        public bool RollUp { get; set; }
        public bool SavePathToFolder { get; set; }
        public bool RepeatByCircle { get; set; }

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

        public AudioPlayer(string[] args)
        {
            InitializeComponent();

            this.CurrentAudioLabel.Text = "";

            this.timer = new System.Windows.Forms.Timer()
            {
                Enabled = true
            };

            this.timer.Interval = 1000;

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
            this.timer.Tick += Timer_Tick;

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
            if (playlistForm != null)
                this.playlistForm.Location = new Point(this.Location.X + 10 + this.Width, this.Location.Y);
            if (this.settingsForm != null)
                this.settingsForm.Location = new Point(this.Location.X - 10 - this.settingsForm.Width, this.Location.Y);
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

            if (this.playlistForm != null)
                this.playlistForm.Show();
            if (this.settingsForm != null)
                this.settingsForm.Show();
        }

        private void AudioPlayer_Resize(object sender, EventArgs e) => ResizeDown();

        private void ResizeDown()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (RollUp)
                    this.Hide();
                if (this.playlistForm != null)
                    this.playlistForm.Hide();
                if (this.settingsForm != null)
                    this.settingsForm.Hide();
            }
        }

        private void ListBoxMedia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                PlaySound();
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
                    new Regex(@"(\.wma)").IsMatch(str) || new Regex(@"(\.flac)").IsMatch(str) || new Regex(@"(\.ogg)").IsMatch(str) || new Regex(@"(\.m4a)").IsMatch(str);
        }

        private void ListBoxMedia_DoubleClick(object sender, EventArgs e)
        {
            int tmpPos = CurrentPositionInListMedia;
            listBoxMedia.ClearSelected();
            listBoxMedia.SetSelected(tmpPos, true);
            StopPlaying();
            PlaySound();
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
            if (this.waveOut != null && this.reader != null && !isPaused)
            {
                this.reader.CurrentTime = TimeSpan.FromSeconds(this.TrackBarAudio.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e) => PlaySound();

        private void PlaySound()
        {
            try
            {
                if (this.listBoxMedia.SelectedIndex == -1)
                    listBoxMedia.SelectedIndex = 0;
                if (!isPaused)
                {
                    TrackBarAudio.Value = 0;
                    if (waveOut != null)
                    {
                        waveOut.Stop();
                        waveOut.Dispose();
                        waveOut = null;
                    }
                    if (reader != null)
                    {
                        reader.Dispose();
                        reader = null;
                    }
                    string fullPath = (this.listBoxMedia.SelectedItem as PathHolder).FullPath;
                    this.waveOut = new WaveOut();
                    this.reader = new AudioFileReader(fullPath);
                    this.reader.Position = this.TrackBarAudio.Value * (int)Math.Round(reader.TotalTime.TotalSeconds);
                    this.waveOut.Init(reader);
                    this.waveOut.Play();
                    this.waveOut.PlaybackStopped += OnPlaybackStopped;
                    this.waveOut.Volume = (float)this.SoundLevelTrackBar.Value / 100;

                    this.TotalDurationLabel.Text = this.reader.TotalTime.ToString().Substring(0, 8);
                    this.TrackBarAudio.Maximum = (int)this.reader.TotalTime.TotalSeconds;

                    this.timer.Start();

                    this.CurrentAudioLabel.Text = (this.listBoxMedia.SelectedItem as PathHolder).Title;

                    this.currentAudio = (this.listBoxMedia.SelectedItem as PathHolder).Title;
                }
                else
                {
                    this.waveOut.Resume();
                    this.isPaused = false;
                    this.timer.Start();
                }
            }
            catch
            {
                NotifyIcon notifyIcon = new NotifyIcon
                {
                    BalloonTipText = "Directory was not choosed."
                };
                notifyIcon.ShowBalloonTip(2000);
                // MessageBox.Show("File is not choosed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (!isPaused)
                CloseWaveOut();
        }

        private void CloseWaveOut()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
            if (reader != null)
            {
                reader.Dispose();
                reader = null;
            }
            this.TrackBarAudio.Value = 0;
            if (listBoxMedia.SelectedIndex != listBoxMedia.Items.Count - 1)
                NextAudio();
            else if (this.RepeatByCircle)
            {
                listBoxMedia.ClearSelected();
                listBoxMedia.SelectedIndex = 0;
                PlaySound();
            }
        }

        private void StopButton_Click(object sender, EventArgs e) => StopPlaying();
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
                else
                {
                    NotifyIcon notifyIcon = new NotifyIcon
                    {
                        BalloonTipText = "Directory was not choosed.",
                    };
                    notifyIcon.ShowBalloonTip(2000);
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                waveOut.Volume = (float)this.SoundLevelTrackBar.Value / 100;
            }
            catch { }
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
            if (File.Exists(Directory.GetCurrentDirectory() + "\\defaultPicture.jpg"))
            {
                titlePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                titlePictureBox.Image = new Bitmap(Directory.GetCurrentDirectory() + "\\defaultPicture.jpg");
            }
        }

        private void LoadPreviousSettings()
        {

            this.RepeatByCircle = Properties.Settings.Default.repeatByCircle;
            this.SavePathToFolder = Properties.Settings.Default.savePathToFolder;
            this.RollUp = Properties.Settings.Default.rollUpTray;

            this.SoundLevelTrackBar.Value = Properties.Settings.Default.currentVolume;
            this.PathToImage = Properties.Settings.Default.pathToImage;
            this.PathToFolder = Properties.Settings.Default.pathToFolder;
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
                    try
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
                    catch { }
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
        private void chooseColorToolStripMenuItem_Click(object sender, EventArgs e) => ShowColoDialog();
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) => OpenSettingsForm();
        private void openFilesToolStripMenuItem_Click(object sender, EventArgs e) => OpenFiles();
        private void ButtonPause_Click(object sender, EventArgs e) => PauseAudio();

        private void ShowColoDialog()
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {

                    this.BackColor = colorDialog.Color;
                    this.mainMenuStrip.BackColor = colorDialog.Color;

                    //this.listBoxMedia.BackColor = colorDialog.Color;

                    if (playlistForm != null)
                        playlistForm.BackColor = colorDialog.Color; ;
                }
            }
        }

        private void PauseAudio()
        {
            if (waveOut != null)
            {
                waveOut.Pause();
                isPaused = true;
                timer.Stop();
            }
        }

        private void toolStripButtonPLay_Click(object sender, EventArgs e) => PlaySound();
        private void toolStripButtonPause_Click(object sender, EventArgs e) => PauseAudio();
        private void toolStripButtonStop_Click(object sender, EventArgs e) => StopPlaying();
        private void StopPlaying()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
            if (reader != null)
            {
                reader.Dispose();
                reader = null;
            }
            this.TrackBarAudio.Value = 0;
            isPaused = false;
            timer.Stop();
            this.CurrentTimeLabel.Text = "00.00.00";
        }

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
                PlaySound();
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
                PlaySound();
            }
        }

        private void toolStripButtonRepeat_Click(object sender, EventArgs e) => Replay();

        private void Replay()
        {
            if (waveOut != null)
                PlaySound();
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
        private void playToolStripMenuItem_Click(object sender, EventArgs e) => PlaySound();
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e) => PauseAudio();
        private void stopToolStripMenuItem_Click(object sender, EventArgs e) => StopPlaying();
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
                        //listBoxMedia.Items.Clear();
                        foreach (var str in fileDialog.FileNames)
                        {
                            PathHolder item = new PathHolder(str);
                            listBoxMedia.Items.Add(item);
                        }
                    }
                    if (fileDialog.FileNames.Length == 1)
                        PlaySound();
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
            if (playlistForm == null)
            {
                playlistForm = new PlaylistForm(this);
                playlistForm.Show();
            }
            else 
            {
                playlistForm.Close();
                playlistForm.Dispose();
                playlistForm = null;
            }
        }

       
        private void ClearCurrentPlaylist()
        {
            StopPlaying();
            LoadDefaultImage();
            this.PathToFolder = null;
            this.PathToImage = null;
            //SavePathToFolder = false;
            this.listBoxMedia.Items.Clear();
        }

        private void titlePictureBox_Click(object sender, EventArgs e) => OpenImage();

        private void OpenImage()
        {
            if (File.Exists(PathToImage))
            {
                Process.Start(PathToImage);
            }
            else if (File.Exists("defaultPicture.jpg"))
            {
                Process.Start("defaultPicture.jpg");
            }
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
            if (settingsForm == null)
            {
                this.settingsForm = new SettingsForm(this);
                this.settingsForm.Show();
            }
            else
            {
                this.settingsForm.Close();
                this.settingsForm.Dispose();
                this.settingsForm = null;
            }
        }

        
    }
}
