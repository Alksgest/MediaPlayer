using NAudio.Wave;
using System;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class MainForm : Form
    {
        private WaveOut waveOut;
        private AudioFileReader reader;


        private void InitializeAudio()
        {
            string fullPath = (listBoxMedia.SelectedItem as PathHolder).FullPath;
            waveOut = new WaveOut();
            reader = new AudioFileReader(fullPath);
            reader.Position = TrackBarAudio.Value * (int)Math.Round(reader.TotalTime.TotalSeconds);
            waveOut.Init(reader);
            waveOut.PlaybackStopped += OnPlaybackStopped;
            waveOut.Volume = (float)SoundLevelTrackBar.Value / 100;
            waveOut.Play();
        }

        private void PlaySound()
        {
            if (listBoxMedia.Items.Count == 0)
                return;
            if (listBoxMedia.SelectedIndex == -1)
                listBoxMedia.SelectedIndex = 0;
            if (!isPaused)
            {
                UninitializeAudio();
                InitializeAudio();

                SetupTrackBarAudio();

                Timer.Start();

                CurrentAudioLabel.Text = (listBoxMedia.SelectedItem as PathHolder).Title;

                currentAudio = (listBoxMedia.SelectedItem as PathHolder).Title;
            }
            else
            {
                waveOut.Play();
                isPaused = false;
                Timer.Start();
            }
        }

        private void PauseAudio()
        {
            if (waveOut != null)
            {
                waveOut.Pause();
                isPaused = true;
                Timer.Stop();
            }
        }
        private void StopAudio()
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
            TrackBarAudio.Value = 0;
            isPaused = false;
            Timer.Stop();
            CurrentTimeLabel.Text = "00.00.00";
        }

        private void UninitializeAudio()
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
}