#nullable enable
using System;
using MediaPlayer.Models;
using NAudio.Wave;

namespace MediaPlayer.Presenters;

public class MainFormPresenter
{
    private WaveOut? _waveOut;
    private AudioFileReader? _reader;
    private AudioFileInfo? _currentFile;
    private float _soundLevel;

    public const string FormatFilter = "Audio Files (*.mp3; *.wav; *.wma; *.flac; *.ogg; *.m4a) " +
                                       "|*.mp3;*.wav;*.wma;*.flac;*.ogg;*.m4a";

    public PlaybackState? PlaybackState => _waveOut?.PlaybackState;
    
    public string? CurrentAudioFileName => _currentFile?.Title;

    public double? TotalSeconds => _reader?.TotalTime.TotalSeconds;
    public TimeSpan? TotalTime => _reader?.TotalTime;
    public string CurrentTime => _reader?.CurrentTime.ToString()[..8] ?? "00.00.00";

    public event Action<string>? AudioStarted;
    public event Action? AudioStopped;
    public event Action? AudioPaused;
    public event Action? AudioUnPaused;
    public event Action? WaveOutClosed;

    public void Replay()
    {
        if (_waveOut != null && _currentFile != null)
        {
            StartAudio(_currentFile, _soundLevel);
        }
    }

    public void StartAudio(AudioFileInfo audioFileInfo, float soundLevel, long trackBarAudioValue = 0)
    {
        if (PlaybackState == NAudio.Wave.PlaybackState.Paused)
        {
            UnPauseAudio();
            return;
        }

        UninitializeAudio();
        InitializeAudio(audioFileInfo.FullPath, soundLevel, trackBarAudioValue);

        _soundLevel = soundLevel;
        _currentFile = audioFileInfo;

        AudioStarted?.Invoke(audioFileInfo.Title);
    }

    public void PauseAudio()
    {
        if (_waveOut == null)
        {
            return;
        }

        _waveOut.Pause();

        AudioPaused?.Invoke();
    }

    public void StopAudio()
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

        AudioStopped?.Invoke();
    }

    public void ChangeVolume(float value)
    {
        if (_waveOut != null)
        {
            _waveOut.Volume = value;
            _soundLevel = value;
        }
    }

    public void ChangeCurrentTime(int value)
    {
        if (_reader != null)
        {
            _reader.CurrentTime = TimeSpan.FromSeconds(value);
        }
    }

    private void UnPauseAudio()
    {
        _waveOut.Play();

        AudioUnPaused?.Invoke();
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

    private void InitializeAudio(string fullPath, float soundValue, long trackBarAudioValue)
    {
        _reader = new AudioFileReader(fullPath);
        _reader.Position = trackBarAudioValue * (long)Math.Round(_reader.TotalTime.TotalSeconds);

        _waveOut = new WaveOut();
        _waveOut.Init(_reader);
        _waveOut.PlaybackStopped += CloseWaveOut;
        _waveOut.Volume = soundValue;
        _waveOut.Play();
    }

    private void CloseWaveOut(object _, StoppedEventArgs __)
    {
        if (PlaybackState != NAudio.Wave.PlaybackState.Stopped)
        {
            return;
        }

        UninitializeAudio();

        WaveOutClosed?.Invoke();
    }
}