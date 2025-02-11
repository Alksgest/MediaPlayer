#pragma warning disable CA1416

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MediaPlayer.Helpers;
using MediaPlayer.Models;
using MediaPlayer.Presenters;
using NAudio.Wave;

namespace MediaPlayer.Forms;

public partial class MainForm : Form
{
    private readonly MainFormPresenter _mainFormPresenter;

    private PlaylistForm _playlistForm;
    private SettingsForm _settingsForm;

    private Point _moveStart;
    private readonly Timer _timer;

    private int _currentPositionInListMedia = -1;

    private string PathToFolder { get; set; }
    private string PathToImage { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string PathToDefaultImage { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool RollUp { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool SavePathToFolder { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool RepeatByCircle { get; set; }

    private ToolTip _openFilesToolTip;
    private ToolTip _openFolderToolTip;
    private ToolTip _removeFilesToolTip;
    private ToolTip _playAudioToolTip;
    private ToolTip _pauseAudioToolTip;
    private ToolTip _stopAudioToolTip;
    private ToolTip _nextAudioToolTip;
    private ToolTip _previousAudioToolTip;
    private ToolTip _replayAudioToolTip;
    private ToolTip _playlistFormButtonToolTip;
    private ToolTip _clearCurrentPlaylistToolTip;
    private ToolTip _settingsToolTip;

    private readonly KeyboardListener _keyboardListener = new();

    public MainForm(string[] args, MainFormPresenter mainFormPresenter)
    {
        _mainFormPresenter = mainFormPresenter;

        InitializeComponent();

        CurrentAudioLabel.Text = "";

        _timer = new Timer
        {
            Enabled = true
        };

        _timer.Interval = 1000;

        InitializeToolTips();
        InitializeCustomGraphic();
        RegisterOnEvents();

        OpenWithCommandLine(args);

        notifyIcon.Visible = true;

        _keyboardListener.OnKeyDown += KeyboardListenerOnOnKeyDown;
    }

    private void KeyboardListenerOnOnKeyDown(Keys key)
    {
        switch (key)
        {
            case Keys.MediaPlayPause:
                ToggleAudio();
                break;
            case Keys.MediaNextTrack:
                NextAudio();
                break;
            case Keys.MediaPreviousTrack:
                PreviousAudio();
                break;
        }
    }

    private void OpenWithCommandLine(string[] args)
    {
        if (args.Length == 0)
        {
            return;
        }

        listBoxMedia.Items.Clear();
        SavePathToFolder = false;

        PathToFolder = null;
        PathToImage = null;

        foreach (var str in args)
        {
            if (!IsFormatAccepted(str))
            {
                continue;
            }

            var item = new AudioFileInfo(str);
            listBoxMedia.Items.Add(item);
        }

        StartAudio();
    }

    private void InitializeToolTips()
    {
        _openFilesToolTip = new ToolTip();
        _openFilesToolTip.SetToolTip(AddFilesButton, "Add audios");

        _openFolderToolTip = new ToolTip();
        _openFolderToolTip.SetToolTip(OpenFolderButton, "Open folder");

        _removeFilesToolTip = new ToolTip();
        _removeFilesToolTip.SetToolTip(RemoveFilesButton, "Remove audios");

        _playAudioToolTip = new ToolTip();
        _playAudioToolTip.SetToolTip(PlayButton, "Play");

        _pauseAudioToolTip = new ToolTip();
        _pauseAudioToolTip.SetToolTip(PauseButton, "Pause");

        _stopAudioToolTip = new ToolTip();
        _stopAudioToolTip.SetToolTip(StopButton, "Stop");

        _nextAudioToolTip = new ToolTip();
        _nextAudioToolTip.SetToolTip(NextButton, "Next");

        _previousAudioToolTip = new ToolTip();
        _previousAudioToolTip.SetToolTip(PreviousButton, "Previous");

        _replayAudioToolTip = new ToolTip();
        _replayAudioToolTip.SetToolTip(ReplayButton, "Replay");

        _playlistFormButtonToolTip = new ToolTip();
        _playlistFormButtonToolTip.SetToolTip(PlaylistFormButton, "Playlists");

        _clearCurrentPlaylistToolTip = new ToolTip();
        _clearCurrentPlaylistToolTip.SetToolTip(ClearCurrentPlaylistButton, "Clear current playlist");

        _settingsToolTip = new ToolTip();
        _settingsToolTip.SetToolTip(SettingsButton, "Settings");
    }

    private void RegisterOnEvents()
    {
        _timer.Tick += Timer_Tick;

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

        _mainFormPresenter.AudioStarted += MainFormPresenterOnMainFormStarted;
        _mainFormPresenter.AudioStopped += MainFormPresenterOnMainFormStopped;
        _mainFormPresenter.AudioPaused += MainFormPresenterOnMainFormPaused;
        _mainFormPresenter.AudioUnPaused += MainFormPresenterOnMainFormUnPaused;
        _mainFormPresenter.WaveOutClosed += MainFormPresenterOnWaveOutClosed;
    }

    private void MainFormPresenterOnWaveOutClosed()
    {
        TrackBarAudio.Value = 0;

        if (listBoxMedia.SelectedIndex != listBoxMedia.Items.Count - 1)
        {
            NextAudio();
        }
        else if (RepeatByCircle)
        {
            listBoxMedia.ClearSelected();
            listBoxMedia.SelectedIndex = 0;
            StartAudio();
        }
    }

    private void MainFormPresenterOnMainFormUnPaused()
    {
        _timer.Start();
    }

    private void MainFormPresenterOnMainFormPaused()
    {
        _timer.Stop();
    }

    private void MainFormPresenterOnMainFormStopped()
    {
        TrackBarAudio.Value = 0;
        _timer.Stop();
        CurrentTimeLabel.Text = "00.00.00";
    }

    private void MainFormPresenterOnMainFormStarted(string fileName)
    {
        SetupTrackBarAudio();
        _timer.Start();
        CurrentAudioLabel.Text = fileName;
    }

    private void ToggleAudio()
    {
        if (_mainFormPresenter.PlaybackState is PlaybackState.Paused or PlaybackState.Stopped)
        {
            StartAudio();
        }
        else
        {
            _mainFormPresenter.PauseAudio();
        }
    }

    private void StartAudio()
    {
        if (listBoxMedia.Items.Count == 0)
        {
            return;
        }

        if (listBoxMedia.SelectedIndex == -1)
        {
            listBoxMedia.SelectedIndex = 0;
        }

        var audioFileInfo = listBoxMedia.SelectedItem as AudioFileInfo;
        var soundLevel = (float)SoundLevelTrackBar.Value / 100;

        _mainFormPresenter.StartAudio(audioFileInfo!, soundLevel, TrackBarAudio.Value);
    }

    private void MainMenuStrip_MouseMove(object sender, MouseEventArgs e) => MouseMoveHandler(e);
    private void MainMenuStrip_MouseDown(object sender, MouseEventArgs e) => MouseDownHandler(e);
    private void AudioPlayer_MouseMove(object sender, MouseEventArgs e) => MouseMoveHandler(e);
    private void AudioPlayer_MouseDown(object sender, MouseEventArgs e) => MouseDownHandler(e);
    private void CurrentAudioLabel_MouseMove(object sender, MouseEventArgs e) => MouseMoveHandler(e);
    private void CurrentAudioLabel_MouseDown(object sender, MouseEventArgs e) => MouseDownHandler(e);


    private void AudioPlayer_Activated(object sender, EventArgs e) => ResizeUp();

    private void AudioPlayer_LocationChanged(object sender, EventArgs e)
    {
        if (_playlistForm != null)
            _playlistForm.Location = new Point(Location.X + 10 + Width, Location.Y);
        if (_settingsForm != null)
            _settingsForm.Location = new Point(Location.X - 10 - _settingsForm.Width, Location.Y);
    }

    private void InitializeCustomGraphic()
    {
        // contextMenuStripNI.Renderer = new ContextMenuStripExtraRenderer();
        // contextMenuStripForListBoxItem.Renderer = new ContextMenuStripExtraRenderer();
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

    private void MouseDownHandler(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _moveStart = new Point(e.X, e.Y);
        }
    }

    private void MouseMoveHandler(MouseEventArgs e)
    {
        if ((e.Button & MouseButtons.Left) == 0)
        {
            return;
        }

        var deltaPos = new Point(e.X - _moveStart.X, e.Y - _moveStart.Y);
        Location = new Point(Location.X + deltaPos.X,
            Location.Y + deltaPos.Y);
    }

    private void NotifyIcon_DoubleClick(object sender, EventArgs e) => ResizeUp();

    private void ResizeUp()
    {
        Show();
        WindowState = FormWindowState.Normal;

        _playlistForm?.Show();
        _settingsForm?.Show();
    }

    private void AudioPlayer_Resize(object sender, EventArgs e) => ResizeDown();

    private void ResizeDown()
    {
        if (WindowState != FormWindowState.Minimized)
        {
            return;
        }

        if (RollUp)
        {
            Hide();
        }

        _playlistForm?.Hide();
        _settingsForm?.Hide();
    }

    private void ListBoxMedia_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyData)
        {
            case Keys.Enter:
                StartAudio();
                break;
            case Keys.Delete when listBoxMedia.SelectedIndex != -1:
                RemoveFiles();
                break;
        }
    }

    private void ListBoxMedia_DragEnter(object sender, DragEventArgs e)
    {
        var fileList = e.Data?.GetData(DataFormats.FileDrop, false) as string[];

        foreach (var str in fileList ?? [])
        {
            e.Effect = IsFormatAccepted(str) ? DragDropEffects.Copy : DragDropEffects.None;
        }
    }

    private void ListBoxMedia_DragDrop(object sender, DragEventArgs e)
    {
        var fileList = e.Data?.GetData(DataFormats.FileDrop, false) as string[];

        foreach (var path in fileList ?? [])
        {
            if (!IsFormatAccepted(path))
            {
                continue;
            }

            listBoxMedia.Items.Add(new AudioFileInfo(path));
        }
    }

    private static bool IsFormatAccepted(string str)
    {
        return new Regex(@"(\.mp3)").IsMatch(str) || new Regex(@"(\.wav)").IsMatch(str) ||
               new Regex(@"(\.wma)").IsMatch(str) || new Regex(@"(\.flac)").IsMatch(str) ||
               new Regex(@"(\.ogg)").IsMatch(str) || new Regex(@"(\.m4a)").IsMatch(str);
    }

    private void ListBoxMedia_DoubleClick(object sender, EventArgs e)
    {
        var tmpPos = _currentPositionInListMedia;
        listBoxMedia.ClearSelected();
        listBoxMedia.SetSelected(tmpPos, true);

        _mainFormPresenter.StopAudio();
        StartAudio();
    }

    private void SetupTrackBarAudio()
    {
        TrackBarAudio.Value = 0;
        TotalDurationLabel.Text = _mainFormPresenter.TotalTime.ToString()[..8];
        TrackBarAudio.Maximum =
            _mainFormPresenter.TotalSeconds.HasValue ? (int)_mainFormPresenter.TotalSeconds.Value : 0;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        if (_mainFormPresenter.PlaybackState == PlaybackState.Paused)
        {
            return;
        }

        if (TrackBarAudio.Value < TrackBarAudio.Maximum)
        {
            ++TrackBarAudio.Value;
        }

        CurrentTimeLabel.Text = _mainFormPresenter.CurrentTime;
    }

    private void TrackBarAudio_Scroll(object sender, EventArgs e)
    {
        _mainFormPresenter.ChangeCurrentTime(TrackBarAudio.Value);
    }

    private void ButtonPlay_Click(object sender, EventArgs e) => StartAudio();
    private void StopButton_Click(object sender, EventArgs e) => _mainFormPresenter.StopAudio();
    private void SelectFolder_Click(object sender, EventArgs e) => OpenFolder();
    private void buttonNext_Click(object sender, EventArgs e) => NextAudio();
    private void buttonPrevious_Click(object sender, EventArgs e) => PreviousAudio();
    private void buttonReplay_Click(object sender, EventArgs e) => _mainFormPresenter.Replay();

    private void OpenFolder()
    {
        using var dialog = new FolderBrowserDialog();

        if (dialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        var files = Directory.EnumerateFiles(dialog.SelectedPath, "*.*", SearchOption.TopDirectoryOnly)
            .Where(s => s.EndsWith(".mp3") || s.EndsWith(".wav") || s.EndsWith(".wma") || s.EndsWith(".flac") ||
                        s.EndsWith(".ogg") || s.EndsWith(".m4a"));

        PathToFolder = dialog.SelectedPath;
        listBoxMedia.Items.Clear();

        foreach (var str in files)
        {
            var item = new AudioFileInfo(str);
            listBoxMedia.Items.Add(item);
        }
    }

    private void SoundLevelTrackBar_Scroll(object sender, EventArgs e)
    {
        _mainFormPresenter.ChangeVolume((float)SoundLevelTrackBar.Value / 100);
    }

    private void listBoxMedia_SelectedIndexChanged(object sender, EventArgs e) =>
        _currentPositionInListMedia = listBoxMedia.SelectedIndex;

    private void MainForm_Load(object sender, EventArgs e)
    {
        LoadPreviousSettings();
        LoadPreviousAudioList();

        this.Region = new Region(GraphicsHelper.CreateRoundedBorders(Width, Height));
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

    private void LoadPreviousAudioList()
    {
        if (!SavePathToFolder)
        {
            return;
        }

        var pathToFolderNotEmpty = !string.IsNullOrEmpty(Properties.Settings.Default.pathToFolder);

        if (pathToFolderNotEmpty)
        {
            PathToFolder = Properties.Settings.Default.pathToFolder;
            if (Directory.Exists(PathToFolder))
            {
                var files = Directory.EnumerateFiles(PathToFolder, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(s => s.EndsWith(".mp3") || s.EndsWith(".wav") || s.EndsWith(".wma") || s.EndsWith(".flac") ||
                                s.EndsWith(".ogg") || s.EndsWith(".m4a"));

                foreach (var path in files)
                {
                    listBoxMedia.Items.Add(new AudioFileInfo(path));
                }
            }
        }

        if (!pathToFolderNotEmpty)
        {
            PathToFolder = null;
        }
    }

    private void clearCurrentListToolStripMenuItem_Click(object sender, EventArgs e) => ClearCurrentPlaylist();

    private void openFolderToolStripMenuItem_Click(object sender, EventArgs e) => OpenFolder();
    private void chooseColorToolStripMenuItem_Click(object sender, EventArgs e) => ShowColorDialog();
    private void settingsToolStripMenuItem_Click(object sender, EventArgs e) => OpenSettingsForm();
    private void openFilesToolStripMenuItem_Click(object sender, EventArgs e) => OpenFiles();
    private void ButtonPause_Click(object sender, EventArgs e) => _mainFormPresenter.PauseAudio();

    private void ShowColorDialog()
    {
        using var colorDialog = new ColorDialog();
        if (colorDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        
        BackColor = colorDialog.Color;
        mainMenuStrip.BackColor = colorDialog.Color;

        if (_playlistForm != null)
        {
            _playlistForm.BackColor = colorDialog.Color;
        }
    }

    private void NextAudio()
    {
        if (listBoxMedia.Items.Count == 0)
        {
            return;
        }

        var currentPosition = _mainFormPresenter.CurrentAudioFileName == null
            ? -1
            : listBoxMedia.FindString(_mainFormPresenter.CurrentAudioFileName);

        int nextPosition;

        if (currentPosition == -1 || currentPosition == listBoxMedia.Items.Count - 1)
        {
            nextPosition = 0;
        }
        else
        {
            nextPosition = ++currentPosition;
        }

        listBoxMedia.ClearSelected();
        listBoxMedia.SetSelected(nextPosition, true);

        StartAudio();
    }

    private void PreviousAudio()
    {
        if (listBoxMedia.Items.Count == 0)
        {
            return;
        }

        var currentPosition = _mainFormPresenter.CurrentAudioFileName == null
            ? 0
            : listBoxMedia.FindString(_mainFormPresenter.CurrentAudioFileName);

        int nextPosition;

        if (currentPosition is 0 or -1)
        {
            nextPosition = listBoxMedia.Items.Count - 1;
        }
        else
        {
            nextPosition = --currentPosition;
        }

        listBoxMedia.ClearSelected();
        listBoxMedia.SetSelected(nextPosition, true);

        StartAudio();
    }

    private void ButtonClose_Click(object sender, EventArgs e) => Close();

    private void ButtonRollUp_Click(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Minimized;
    }

    private void expandToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Show();
        WindowState = FormWindowState.Normal;
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e) => Close();
    private void playToolStripMenuItem_Click(object sender, EventArgs e) => StartAudio();
    private void pauseToolStripMenuItem_Click(object sender, EventArgs e) => _mainFormPresenter.PauseAudio();
    private void stopToolStripMenuItem_Click(object sender, EventArgs e) => _mainFormPresenter.StopAudio();
    private void nextToolStripMenuItem_Click(object sender, EventArgs e) => NextAudio();
    private void previousToolStripMenuItem_Click(object sender, EventArgs e) => PreviousAudio();
    private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();
    private void ClearCurrentPlaylistButton_Click(object sender, EventArgs e) => ClearCurrentPlaylist();

    private void OpenFiles()
    {
        using var fileDialog = new OpenFileDialog();
        fileDialog.Multiselect = true;
        fileDialog.Filter = MainFormPresenter.FormatFilter;

        if (fileDialog.ShowDialog() == DialogResult.OK)
        {
            if (fileDialog.FileNames.Length != 0)
            {
                foreach (var path in fileDialog.FileNames)
                {
                    listBoxMedia.Items.Add(new AudioFileInfo(path));
                }
            }

            if (fileDialog.FileNames.Length == 1)
            {
                StartAudio();
            }
        }
    }

    private void buttonAddFile_Click(object sender, EventArgs e) => OpenFiles();
    private void buttonRemoveFiles_Click(object sender, EventArgs e) => RemoveFiles();

    private void RemoveFiles()
    {
        if (listBoxMedia.SelectedItems.Count <= 0)
        {
            return;
        }

        var selectedItems = listBoxMedia.SelectedItems;

        for (var i = selectedItems.Count - 1; i >= 0; --i)
        {
            listBoxMedia.Items.Remove(selectedItems[i]!);
        }
    }

    private void PlaylistFormButton_Click(object sender, EventArgs e) => CreatePlaylistForm();

    private void CreatePlaylistForm()
    {
        if (_playlistForm == null)
        {
            _playlistForm = new PlaylistForm(this);
            _playlistForm.Show();
        }
        else
        {
            _playlistForm.Close();
            _playlistForm.Dispose();
            _playlistForm = null;
        }
    }

    private void ClearCurrentPlaylist()
    {
        _mainFormPresenter.StopAudio();
        PathToFolder = null;
        PathToImage = null;

        CurrentAudioLabel.Text = "";

        listBoxMedia.Items.Clear();
    }

    private void openFileDestinationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var currentAudio = (listBoxMedia.SelectedItem as AudioFileInfo);

        if (File.Exists(currentAudio?.FullPath))
        {
            var splitPath = currentAudio.FullPath.Split('\\').ToList();
            splitPath.RemoveAt(splitPath.Count - 1);
            var path = string.Join("\\", splitPath.ToArray());

            Process.Start(path);
        }
    }

    private void removeToolStripMenuItem_Click(object sender, EventArgs e) => RemoveFiles();

    private void SettingsButton_Click(object sender, EventArgs e) => OpenSettingsForm();

    private void OpenSettingsForm()
    {
        if (_settingsForm == null)
        {
            _settingsForm = new SettingsForm(this);
            _settingsForm.Show();
        }
        else
        {
            _settingsForm.Close();
            _settingsForm.Dispose();
            _settingsForm = null;
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _keyboardListener.Dispose();
        base.OnFormClosing(e);
    }
}