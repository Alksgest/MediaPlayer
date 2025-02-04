using System;
using MediaPlayer.Models;
using NAudio.Wave;

namespace MediaPlayer.Presenters;

public class AudioPresenter
{
    private WaveOut _waveOut;
    private AudioFileReader _reader;
    private PathHolder _currentFile;

    public const string FormatFilter = "Audio Files (*.mp3; *.wav; *.wma; *.flac; *.ogg; *.m4a) " +
                                       "|*.mp3;*.wav;*.wma;*.flac;*.ogg;*.m4a";

    public bool IsPaused { get; private set; }
    public float SoundLevel { get; set; }
    public string CurrentAudioFileName => _currentFile.Title;

    public double? TotalSeconds => _reader?.TotalTime.TotalSeconds;
    public TimeSpan? TotalTime => _reader?.TotalTime;
    public string CurrentTime => _reader?.CurrentTime.ToString()[..8] ?? "00.00.00";

    public event Action<string> AudioStarted;
    public event Action AudioStopped;
    public event Action AudioPaused;
    public event Action AudioUnPaused;
    public event Action WaveOutClosed;

    public void Replay()
    {
        if (_waveOut != null)
        {
            StartAudio(_currentFile, SoundLevel);
        }
    }

    public void StartAudio(PathHolder pathHolder, float soundLevel, long trackBarAudioValue = 0)
    {
        if (IsPaused)
        {
            UnPauseAudio();
            return;
        }

        UninitializeAudio();
        InitializeAudio(pathHolder.FullPath, soundLevel, trackBarAudioValue);

        SoundLevel = soundLevel;
        _currentFile = pathHolder;

        AudioStarted?.Invoke(pathHolder.Title);
    }

    public void UnPauseAudio()
    {
        _waveOut.Play();
        IsPaused = false;

        AudioUnPaused?.Invoke();
    }

    public void PauseAudio()
    {
        if (_waveOut == null)
        {
            return;
        }

        _waveOut.Pause();
        IsPaused = true;

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

        IsPaused = false;

        AudioStopped?.Invoke();
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

    public void ChangeVolume(float value)
    {
        if (_waveOut != null)
        {
            _waveOut.Volume = value;
            SoundLevel = value;
        }
    }

    public void ChangeCurrentTime(int value)
    {
        if (_reader != null)
        {
            _reader.CurrentTime = TimeSpan.FromSeconds(value);
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
        if (!IsPaused)
        {
            return;
        }

        UninitializeAudio();
        
        WaveOutClosed?.Invoke();
    }
}