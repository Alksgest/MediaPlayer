using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NAudio;
using NAudio.Wave;
using System.Text.RegularExpressions;

namespace MediaPlayer
{
    public partial class AudioPlayer : Form
    {
        private WaveOut waveOut;
        private AudioFileReader reader;

        private Point moveStart;
        private Timer timer;

        private int CurrentPositionInListMedia = -1;
        private bool RepeatByCircle = false;
        private string PathToFolder = null;
        private bool isPaused = false;

        private List<string> CurrentPlaylist = new List<string>();

        public AudioPlayer(string[] args)
        {
            InitializeComponent();

            this.timer = new Timer
            {
                Enabled = true
            };

            this.timer.Interval = 1000;

            InitializeCustomGraphic();
            RegisterOnEvents();

            if (args != null)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\" + "currentDir.dat"))
                    File.Delete(Directory.GetCurrentDirectory() + "\\" + "currentDir.dat");
                foreach (var str in args)
                    if (AcceptedFormat(str))
                        this.listBoxMedia.Items.Add(str);
                PlaySound();
            }
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

            this.menuStrip1.MouseDown += MenuStrip1_MouseDown;
            this.menuStrip1.MouseMove += MenuStrip1_MouseMove;

            this.toolStrip1.MouseDown += ToolStrip1_MouseDown;
            this.toolStrip1.MouseMove += ToolStrip1_MouseMove;
        }

        private void InitializeCustomGraphic()
        {
            this.toolStrip1.Renderer = new ToolStripExtraRenderer();
            this.contextMenuStripNI.Renderer = new ContextMenuStripExtraRenderer();
        }

        private void ToolStrip1_MouseMove(object sender, MouseEventArgs e) => MouseMoveHandler(e);
        private void ToolStrip1_MouseDown(object sender, MouseEventArgs e) => MouseDownHandler(e);
        private void MenuStrip1_MouseMove(object sender, MouseEventArgs e) => MouseMoveHandler(e);
        private void MenuStrip1_MouseDown(object sender, MouseEventArgs e) => MouseDownHandler(e);
        private void AudioPlayer_MouseMove(object sender, MouseEventArgs e) => MouseMoveHandler(e);
        private void AudioPlayer_MouseDown(object sender, MouseEventArgs e) => MouseDownHandler(e);

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

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void AudioPlayer_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                Hide();

        }

        private void ListBoxMedia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                PlaySound();
            else if (e.KeyData == Keys.Delete && listBoxMedia.SelectedIndex != -1)
                listBoxMedia.Items.RemoveAt(listBoxMedia.SelectedIndex);
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
                    this.listBoxMedia.Items.Add(str);
            }
        }

        private bool AcceptedFormat(string str)
        {
            return new Regex(@"(\.mp3)").IsMatch(str) || new Regex(@"(\.wav)").IsMatch(str) ||
                    new Regex(@"(\.wma)").IsMatch(str) || new Regex(@"(\.flac)").IsMatch(str) || new Regex(@"(\.ogg)").IsMatch(str);
        }

        private void ListBoxMedia_DoubleClick(object sender, EventArgs e) => PlaySound();
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            //TrackBarAudio.Value += (int)reader.TotalTime.TotalSeconds;
            if (reader != null && !isPaused)
            {
                try { this.TrackBarAudio.Value += (int)Math.Round(1000 / (reader.TotalTime.TotalSeconds)); }
                catch { }

                this.TimeLabel.Text = this.reader.CurrentTime.ToString().Substring(0, 8);
            }
        }
        private void TrackBarAudio_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (waveOut != null && reader != null && !isPaused)
                {
                    this.waveOut.Stop();
                    this.reader.CurrentTime = TimeSpan.FromSeconds((double)this.TrackBarAudio.Value / 1000 * this.reader.TotalTime.TotalSeconds);
                    this.waveOut.Play();
                }
                else
                    reader.CurrentTime = TimeSpan.FromSeconds((double)this.TrackBarAudio.Value / 1000 * this.reader.TotalTime.TotalSeconds);
            }
            catch { }
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

                    this.waveOut = new WaveOut();
                    this.reader = new AudioFileReader(this.listBoxMedia.SelectedItem.ToString());
                    this.reader.Position = this.TrackBarAudio.Value * (int)Math.Round(reader.TotalTime.TotalSeconds);
                    this.waveOut.Init(reader);
                    this.waveOut.Play();
                    this.waveOut.PlaybackStopped += OnPlaybackStopped;
                    this.waveOut.Volume = (float)this.SoundLevelTrackBar.Value / 100;

                    this.TotalDurationLabel.Text = this.reader.TotalTime.ToString().Substring(0, 8);

                    this.timer.Start();
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
                NotifyIcon notifyIcon = new NotifyIcon();
                notifyIcon.BalloonTipText = "Directory was not choosed.";
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
            StartButton.Enabled = true;
            this.TrackBarAudio.Value = 0;
            if (listBoxMedia.SelectedIndex != listBoxMedia.Items.Count - 1)
            {
                listBoxMedia.SelectedIndex++;
                PlaySound();
            }
            else if (RepeatByCircle)
            {
                listBoxMedia.SelectedIndex = 0;
                PlaySound();
            }
        }

        private void StopButton_Click(object sender, EventArgs e) => StopPlaying();
        private void SelectFolder_Click(object sender, EventArgs e) => SelectFolder();

        private void SelectFolder()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog();

                try
                {
                    var files = Directory.EnumerateFiles(dialog.SelectedPath, "*.*", SearchOption.TopDirectoryOnly)
                               .Where(s => s.EndsWith(".mp3") || s.EndsWith(".wav") || s.EndsWith(".wma") || s.EndsWith(".flac"));
                    PathToFolder = dialog.SelectedPath;
                    listBoxMedia.Items.Clear();

                    foreach (var c in files)
                        listBoxMedia.Items.Add(c);

                    var filesX = Directory.EnumerateFiles(PathToFolder, "*.*", SearchOption.TopDirectoryOnly)
                               .Where(s => s.EndsWith(".jpg") || s.EndsWith(".png") || s.EndsWith(".bmp"));
                    var filesImage = filesX.ToArray();
                    if (filesImage.Length != 0)
                    {
                        titlePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        titlePictureBox.Image = new Bitmap(filesImage[0]);
                    }
                }
                catch
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



        private void listBoxMedia_SelectedIndexChanged(object sender, EventArgs e) => CurrentPositionInListMedia = this.listBoxMedia.SelectedIndex;

        private void AudioPlayer_Load(object sender, EventArgs e)
        {
            LoadImages();

            LoadPreviousAudioList();
            LoadTitlePicture();
        }

        private void LoadTitlePicture()
        {
            if (!String.IsNullOrEmpty(PathToFolder))
            {
                var filesX = Directory.EnumerateFiles(PathToFolder, "*.*", SearchOption.TopDirectoryOnly)
            .Where(s => s.EndsWith(".jpg") || s.EndsWith(".png") || s.EndsWith(".bmp"));
                var files = filesX.ToArray();
                if (files.Length != 0)
                {
                    titlePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    titlePictureBox.Image = new Bitmap(files[0]);
                }
                else if (File.Exists(Directory.GetCurrentDirectory() + "\\defaultPicture.jpg"))
                {
                    titlePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    titlePictureBox.Image = new Bitmap(Directory.GetCurrentDirectory() + "\\defaultPicture.jpg");
                }
            }
            else if (File.Exists(Directory.GetCurrentDirectory() + "\\defaultPicture.jpg"))
            {
                titlePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                titlePictureBox.Image = new Bitmap(Directory.GetCurrentDirectory() + "\\defaultPicture.jpg");
            }
        }

        private void LoadPreviousAudioList()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\currentDir.dat"))
            {
                try
                {
                    bool isExistPath = false;
                    using (BinaryReader reader = new BinaryReader(File.Open(Directory.GetCurrentDirectory() +
                        "\\currentDir.dat", FileMode.Open)))
                    {
                        PathToFolder = reader.ReadString();
                        if (Directory.Exists(PathToFolder))
                        {
                            isExistPath = true;
                            var files = Directory.EnumerateFiles(PathToFolder, "*.*", SearchOption.TopDirectoryOnly)
                                     .Where(s => s.EndsWith(".mp3") || s.EndsWith(".wav") || s.EndsWith(".wma") || s.EndsWith(".flac"));
                            foreach (var c in files)
                                listBoxMedia.Items.Add(c);
                        }
                    }
                    if (!isExistPath)
                    {
                        PathToFolder = null;
                        File.Delete(Directory.GetCurrentDirectory() + "\\currentDir.dat");
                    }
                }
                catch { }
            }
        }

        private void LoadImages()
        {
            this.notifyIcon.Icon = Icon.FromHandle(Properties.Resources.music_player.GetHicon());

            this.ButtonClose.BackgroundImage = Properties.Resources.cancel;
            this.ButtonClose.BackgroundImageLayout = ImageLayout.Stretch;

            this.ButtonRollUp.BackgroundImage = Properties.Resources.minus;
            this.ButtonRollUp.BackgroundImageLayout = ImageLayout.Stretch;

            this.toolStripButtonPLay.Image = new Bitmap(Properties.Resources.play_button);
            this.toolStripButtonPause.Image = new Bitmap(Properties.Resources.pause);
            this.toolStripButtonStop.Image = new Bitmap(Properties.Resources.stop);
            this.toolStripButtonNext.Image = new Bitmap(Properties.Resources.next_1);
            this.toolStripButtonPrevious.Image = new Bitmap(Properties.Resources.back_1);
            this.toolStripButtonRepeat.Image = new Bitmap(Properties.Resources.replay);
            this.Icon = Icon.FromHandle(Properties.Resources.music_player.GetHicon());

            this.PauseButton.Image = new Bitmap(Properties.Resources.stop);

            this.BackColor = Color.GhostWhite;
            this.menuStrip1.BackColor = Color.GhostWhite;
            this.toolStrip1.BackColor = Color.GhostWhite;
        }

        private void checkBoxRepeatCircle_CheckedChanged(object sender, EventArgs e) => RepeatByCircle = true;

        private void clearPathToFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("currentDir.dat"))
                File.Delete(("currentDir.dat"));
        }

        private void savePathToFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("currentDir.dat", FileMode.Create)))
            {
                if (!String.IsNullOrEmpty(PathToFolder))
                    writer.Write(PathToFolder);
            }
        }

        private void clearCurrentListToolStripMenuItem_Click(object sender, EventArgs e) => ClearCurrentList();

        private void ClearCurrentList()
        {
            TrackBarAudio.Value = 0;
            listBoxMedia.Items.Clear();
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
            this.titlePictureBox.Image = null;
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e) => SelectFolder();
        private void ButtonPause_Click(object sender, EventArgs e) => PauseAudio();

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
            StartButton.Enabled = true;
            this.TrackBarAudio.Value = 0;
            isPaused = false;
            timer.Stop();
            this.TimeLabel.Text = "0.0";
        }

        private void toolStripButtonNext_Click(object sender, EventArgs e) => NextAudio();

        private void NextAudio()
        {
            if (listBoxMedia.Items.Count == 0)
                return;
            else
            {
                if (this.listBoxMedia.SelectedIndex != listBoxMedia.Items.Count - 1)
                    this.listBoxMedia.SelectedIndex++;
                else
                    this.listBoxMedia.SelectedIndex = 0;
                PlaySound();
            }
        }

        private void toolStripButtonPrevious_Click(object sender, EventArgs e) => PreviousAudio();

        private void PreviousAudio()
        {
            if (listBoxMedia.Items.Count == 0)
                return;
            else
            {
                if (this.listBoxMedia.SelectedIndex == 0 || this.listBoxMedia.SelectedIndex == -1)
                    this.listBoxMedia.SelectedIndex = listBoxMedia.Items.Count - 1;
                else
                    this.listBoxMedia.SelectedIndex--;
                PlaySound();
            }
        }

        private void toolStripButtonRepeat_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
                PlaySound();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) =>
            this.Close();

        private void ButtonClose_Click(object sender, EventArgs e) => this.Close();

        private void ButtonRollUp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.notifyIcon.ShowBalloonTip(5000);
        }

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();
        private void playToolStripMenuItem_Click(object sender, EventArgs e) =>  PlaySound();
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e) => PauseAudio();
        private void stopToolStripMenuItem_Click(object sender, EventArgs e) => StopPlaying();
        private void nextToolStripMenuItem_Click(object sender, EventArgs e) => NextAudio();
        private void previousToolStripMenuItem_Click(object sender, EventArgs e) => PreviousAudio();
        private void OpenFileButton_Click(object sender, EventArgs e) => OpenFiles();

        private void OpenFiles()
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Multiselect = true;
                fileDialog.Filter = "Audio Files (*.mp3; *.wav; *.wma) |*.mp3;*.wav;*.wma";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (fileDialog.FileNames.Length != 0)
                        foreach (var c in fileDialog.FileNames)
                            listBoxMedia.Items.Add(c);
                    PlaySound();
                }
            }
        }
    }
}
