using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class MainForm : Form
    {
        private WaveOut waveOut;
        private AudioFileReader reader;


        private void InitializeAudio()
        {
            string fullPath = (this.listBoxMedia.SelectedItem as PathHolder).FullPath;
            this.waveOut = new WaveOut();
            this.reader = new AudioFileReader(fullPath);
            this.reader.Position = this.TrackBarAudio.Value * (int)Math.Round(reader.TotalTime.TotalSeconds);
            this.waveOut.Init(reader);
            this.waveOut.PlaybackStopped += OnPlaybackStopped;
            this.waveOut.Volume = (float)this.SoundLevelTrackBar.Value / 100;
            this.waveOut.Play();
        }

        private void PlaySound()
        {
            if (listBoxMedia.Items.Count == 0)
                return;
            if (this.listBoxMedia.SelectedIndex == -1)
                listBoxMedia.SelectedIndex = 0;
            if (!isPaused)
            {
                UninitializeAudio();
                InitializeAudio();

                SetupTrackBarAudio();

                this.Timer.Start();

                this.CurrentAudioLabel.Text = (this.listBoxMedia.SelectedItem as PathHolder).Title;

                this.currentAudio = (this.listBoxMedia.SelectedItem as PathHolder).Title;
            }
            else
            {
                this.waveOut.Play();
                this.isPaused = false;
                this.Timer.Start();
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
            this.TrackBarAudio.Value = 0;
            isPaused = false;
            Timer.Stop();
            this.CurrentTimeLabel.Text = "00.00.00";
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
    }
}