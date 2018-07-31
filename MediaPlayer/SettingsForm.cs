using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class SettingsForm : Form
    {
        private AudioPlayer audioPlayer;
        public SettingsForm(AudioPlayer audioPlayer)
        {
            this.audioPlayer = audioPlayer;
            this.BackColor = audioPlayer.BackColor;
            InitializeComponent();
        }

        private void checkBoxSavePathToFolder_CheckedChanged(object sender, EventArgs e)
        {
            audioPlayer.SavePathToFolder = checkBoxSavePathToFolder.Checked;
        }

        private void checkBoxRepeatCircle_CheckedChanged(object sender, EventArgs e)
        {
            audioPlayer.RepeatByCircle = checkBoxRepeatCircle.Checked;
        }

        private void checkBoxRollUpTray_CheckedChanged(object sender, EventArgs e)
        {
            audioPlayer.RollUp = checkBoxRollUpTray.Checked;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(audioPlayer.Location.X -10 - this.Width, audioPlayer.Location.Y);

            checkBoxSavePathToFolder.Checked = audioPlayer.SavePathToFolder;
            checkBoxRepeatCircle.Checked = audioPlayer.RepeatByCircle;
            checkBoxRollUpTray.Checked = audioPlayer.RollUp;
        }
    }
}
