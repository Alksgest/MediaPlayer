using System;
using System.Windows.Forms;
using MediaPlayer.Models;
using NAudio.Wave;

namespace MediaPlayer.Forms;

public partial class MainForm : Form
{
    private WaveOut _waveOut;
    private AudioFileReader _reader;


    private void InitializeAudio()
    {
        var fullPath = (listBoxMedia.SelectedItem as PathHolder)?.FullPath;
            
        _reader = new AudioFileReader(fullPath);
        _reader.Position = TrackBarAudio.Value * (long)Math.Round(_reader.TotalTime.TotalSeconds);
            
        _waveOut = new WaveOut();
        _waveOut.Init(_reader);
        _waveOut.PlaybackStopped += OnPlaybackStopped;
        _waveOut.Volume = (float)SoundLevelTrackBar.Value / 100;
        _waveOut.Play();
    }

    private void PlaySound()
    {
        if (listBoxMedia.Items.Count == 0)
            return;
        if (listBoxMedia.SelectedIndex == -1)
            listBoxMedia.SelectedIndex = 0;
        if (!_isPaused)
        {
            UninitializeAudio();
            InitializeAudio();

            SetupTrackBarAudio();

            _timer.Start();

            CurrentAudioLabel.Text = (listBoxMedia.SelectedItem as PathHolder)?.Title ?? "default_title"; 

            _currentAudio = (listBoxMedia.SelectedItem as PathHolder)?.Title ?? "default_title";
        }
        else
        {
            _waveOut.Play();
            _isPaused = false;
            _timer.Start();
        }
    }

    private void PauseAudio()
    {
        if (_waveOut != null)
        {
            _waveOut.Pause();
            _isPaused = true;
            _timer.Stop();
        }
    }
    private void StopAudio()
    {
        if (_waveOut != null)
        {
            _waveOut.Stop();
            _waveOut.Dispose();
            _waveOut = null;
        }
        if (_reader != null)
        {
            _reader.Dispose();
            _reader = null;
        }
        TrackBarAudio.Value = 0;
        _isPaused = false;
        _timer.Stop();
        CurrentTimeLabel.Text = "00.00.00";
    }

    private void UninitializeAudio()
    {
        if (_waveOut != null)
        {
            _waveOut.Stop();
            _waveOut.Dispose();
            _waveOut = null;
        }
        if (_reader != null)
        {
            _reader.Dispose();
            _reader = null;
        }
    }

    private void CloseWaveOut()
    {
        UninitializeAudio();

        TrackBarAudio.Value = 0;
        if (listBoxMedia.SelectedIndex != listBoxMedia.Items.Count - 1)
            NextAudio();
        else if (RepeatByCircle)
        {
            listBoxMedia.ClearSelected();
            listBoxMedia.SelectedIndex = 0;
            PlaySound();
        }
    }
}