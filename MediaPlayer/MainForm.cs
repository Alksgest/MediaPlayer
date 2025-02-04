using System;
using System.Collections.Generic;
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
        private Timer Timer;

        private int CurrentPositionInListMedia = -1;
        private bool isPaused = false;

        public string PathToFolder { get; set; }
        public string PathToImage { get; set; }
        public string PathToDefaultImage { get; set; }
        public bool RollUp { get; set; }
        public bool SavePathToFolder { get; set; }
        public bool RepeatByCircle { get; set; }
        private string currentAudio = null;

        private ToolTip openFilesToolTip;
        private ToolTip openFolderToolTip;
        private ToolTip removeFilesToolTip;
        private ToolTip playAudioToolTip;
        private ToolTip pauseAudioToolTip;
        private ToolTip stopAudioToolTip;
        private ToolTip nextAudioToolTip;
        private ToolTip previousAudioToolTip;
        private ToolTip replayAudioToolTip;
        private ToolTip playlistFormButtonToolTip;
        private ToolTip clearCurrentPlaylistToolTip;
        private ToolTip settingsToolTip;

        private List<string> CurrentPlaylist = new List<string>();

        public MainForm(string[] args)
        {
            InitializeComponent();

            CurrentAudioLabel.Text = "";

            Timer = new Timer()
            {
                Enabled = true
            };

            Timer.Interval = 1000;

            InitializeToolTips();
            InitializeCustomGraphic();
            RegisterOnEvents();

            OpenWithCommandLine(args);
        }

        private void OpenWithCommandLine(string[] args)
        {
            if (args != null)
            {
                listBoxMedia.Items.Clear();
                SavePathToFolder = false;

                PathToFolder = null;
                PathToImage = null;

                foreach (var str in args)
                {
                    if (AcceptedFormat(str))
                    {
                        PathHolder item = new PathHolder(str);
                        listBoxMedia.Items.Add(item);
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

            PlaySoundEvent += PlaySound;
            StopSoundEvent += StopAudio;
            Timer.Tick += Timer_Tick;


            TrackBarAudio.Scroll += TrackBarAudio_Scroll;

            listBoxMedia.DoubleClick += ListBoxMedia_DoubleClick;
            listBoxMedia.DragDrop += ListBoxMedia_DragDrop;
            listBoxMedia.DragEnter += ListBoxMedia_DragEnter;
            listBoxMedia.KeyDown += ListBoxMedia_KeyDown;

            Resize += AudioPlayer_Resize;
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

            MouseDown += AudioPlayer_MouseDown;
            MouseMove += AudioPlayer_MouseMove;

            mainMenuStrip.MouseDown += MainMenuStrip_MouseDown;
            mainMenuStrip.MouseMove += MainMenuStrip_MouseMove;

            FormClosing += AudioPlayer_FormClosing;
            LocationChanged += AudioPlayer_LocationChanged;

            CurrentAudioLabel.MouseDown += CurrentAudioLabel_MouseDown;
            CurrentAudioLabel.MouseMove += CurrentAudioLabel_MouseMove;

            Activated += AudioPlayer_Activated;
        }

        private void AudioPlayer_Activated(object sender, EventArgs e) => ResizeUp();

        private void AudioPlayer_LocationChanged(object sender, EventArgs e)
        {
            if (PlaylistForm != null)
                PlaylistForm.Location = new Point(Location.X + 10 + Width, Location.Y);
            if (SettingsForm != null)
                SettingsForm.Location = new Point(Location.X - 10 - SettingsForm.Width, Location.Y);
        }

        private void InitializeCustomGraphic()
        {
            contextMenuStripNI.Renderer = new ContextMenuStripExtraRenderer();
            contextMenuStripForListBoxItem.Renderer = new ContextMenuStripExtraRenderer();
        }

        private void AudioPlayer_FormClosing(object sender, FormClosingEventArgs e) => SaveSettings();

        private void SaveSettings()
        {
            Properties.Settings.Default.repeatByCircle = RepeatByCircle;
            Properties.Settings.Default.savePathToFolder = SavePathToFolder;
            Properties.Settings.Default.rollUpTray = RollUp;
            Properties.Settings.Default.currentVolume = SoundLevelTrackBar.Value;
            Properties.Settings.Default.pathToDefaultImage = PathToDefaultImage;

            if (Properties.Settings.Default.savePathToFolder)
            {
                Properties.Settings.Default.pathToFolder = PathToFolder;
                Properties.Settings.Default.pathToImage = PathToImage;
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
                moveStart = new Point(e.X, e.Y);
        }
        private void MouseMoveHandler(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                Point deltaPos = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                Location = new Point(Location.X + deltaPos.X,
                  Location.Y + deltaPos.Y);
            }
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e) => ResizeUp();

        private void ResizeUp()
        {
            Show();
            WindowState = FormWindowState.Normal;

            if (PlaylistForm != null)
                PlaylistForm.Show();
            if (SettingsForm != null)
                SettingsForm.Show();
        }

        private void AudioPlayer_Resize(object sender, EventArgs e) => ResizeDown();

        private void ResizeDown()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (RollUp)
                    Hide();
                if (PlaylistForm != null)
                    PlaylistForm.Hide();
                if (SettingsForm != null)
                    SettingsForm.Hide();
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
            if (reader != null && !isPaused)
            {
                if (TrackBarAudio.Value < TrackBarAudio.Maximum)
                    ++TrackBarAudio.Value;
                CurrentTimeLabel.Text = reader.CurrentTime.ToString().Substring(0, 8);
            }
        }
    
        private void TrackBarAudio_Scroll(object sender, EventArgs e)
        {
            if (waveOut != null )
            {
                reader.CurrentTime = TimeSpan.FromSeconds(TrackBarAudio.Value);
            }
        }

        private void ButtonPlay_Click(object sender, EventArgs e) => PlaySoundEvent();


        private void SetupTrackBarAudio()
        {
            TrackBarAudio.Value = 0;
            TotalDurationLabel.Text = reader.TotalTime.ToString().Substring(0, 8);
            TrackBarAudio.Maximum = (int)reader.TotalTime.TotalSeconds;
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
                waveOut.Volume = (float)SoundLevelTrackBar.Value / 100;
        }

        private void listBoxMedia_SelectedIndexChanged(object sender, EventArgs e) => CurrentPositionInListMedia = listBoxMedia.SelectedIndex;

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
            RepeatByCircle = Properties.Settings.Default.repeatByCircle;
            SavePathToFolder = Properties.Settings.Default.savePathToFolder;
            RollUp = Properties.Settings.Default.rollUpTray;

            SoundLevelTrackBar.Value = Properties.Settings.Default.currentVolume;
            PathToImage = Properties.Settings.Default.pathToImage;
            PathToFolder = Properties.Settings.Default.pathToFolder;
            PathToDefaultImage = Properties.Settings.Default.pathToDefaultImage;
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
                    PathToImage = images[0];
                }
                else if (Directory.Exists(PathToFolder + "//Cover"))
                {
                    images = Directory.EnumerateFiles(PathToFolder + "//Cover", "*.*", SearchOption.TopDirectoryOnly)
                      .Where(s => s.EndsWith(".jpg") || s.EndsWith(".png") || s.EndsWith(".bmp")).ToArray();
                    if (images.Length != 0)
                    {

                        titlePictureBox.Image = new Bitmap(images[0]);
                        PathToImage = images[0];
                    }
                }
                else if (Directory.Exists(PathToFolder + "//Covers"))
                {
                    images = Directory.EnumerateFiles(PathToFolder + "//Covers", "*.*", SearchOption.TopDirectoryOnly)
                      .Where(s => s.EndsWith(".jpg") || s.EndsWith(".png") || s.EndsWith(".bmp")).ToArray();
                    if (images.Length != 0)
                    {
                        titlePictureBox.Image = new Bitmap(images[0]);
                        PathToImage = images[0];
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
            notifyIcon.Icon = Icon.FromHandle(Properties.Resources.music_player.GetHicon());

            Icon = Icon.FromHandle(Properties.Resources.music_player.GetHicon());

            BackColor = Color.GhostWhite;
            mainMenuStrip.BackColor = Color.GhostWhite;
            
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

                    BackColor = colorDialog.Color;
                    mainMenuStrip.BackColor = colorDialog.Color;

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
                int currentPosition = listBoxMedia.FindString(currentAudio);
                int tmpPos = currentPosition;

                if (currentPosition == listBoxMedia.Items.Count - 1 || currentPosition == -1)
                    tmpPos = 0;
                else
                    tmpPos = ++currentPosition;

                listBoxMedia.ClearSelected();
                listBoxMedia.SetSelected(tmpPos, true);
                PlaySoundEvent();
            }
        }

        private void PreviousAudio()
        {
            if (listBoxMedia.Items.Count == 0)
                return;
            else
            {
                int currentPosition = listBoxMedia.FindString(currentAudio);
                int tmpPos = currentPosition;

                if (currentPosition == 0 || currentPosition == -1)
                    tmpPos = listBoxMedia.Items.Count - 1;
                else
                    tmpPos = --currentPosition;

                listBoxMedia.ClearSelected();
                listBoxMedia.SetSelected(tmpPos, true);
                PlaySoundEvent();
            }
        }

        private void toolStripButtonRepeat_Click(object sender, EventArgs e) => Replay();

        private void Replay()
        {
            if (waveOut != null)
                PlaySoundEvent();
        }

        private void ButtonClose_Click(object sender, EventArgs e) => Close();
        private void ButtonRollUp_Click(object sender, EventArgs e)
        {
                WindowState = FormWindowState.Minimized;
            //this.notifyIcon.ShowBalloonTip(5000);
        }

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => Close();
        private void playToolStripMenuItem_Click(object sender, EventArgs e) => PlaySoundEvent();
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e) => PauseAudio();
        private void stopToolStripMenuItem_Click(object sender, EventArgs e) => StopSoundEvent();
        private void nextToolStripMenuItem_Click(object sender, EventArgs e) => NextAudio();
        private void previousToolStripMenuItem_Click(object sender, EventArgs e) => PreviousAudio();
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();
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
                    listBoxMedia.Items.Remove(selectedItems[i]);
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
            PathToFolder = null;
            PathToImage = null;

            CurrentAudioLabel.Text = null;

            listBoxMedia.Items.Clear();
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
                SettingsForm = new SettingsForm(this);
                SettingsForm.Show();
            }
            else
            {
                SettingsForm.Close();
                SettingsForm.Dispose();
                SettingsForm = null;
            }
        }
    }
}
