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
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.audioPlayer = audioPlayer;
            this.Location = new Point(audioPlayer.Location.X - 10 - this.Width, audioPlayer.Location.Y);
            this.BackColor = audioPlayer.BackColor;
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
            checkBoxSavePathToFolder.Checked = audioPlayer.SavePathToFolder;
            checkBoxRepeatCircle.Checked = audioPlayer.RepeatByCircle;
            checkBoxRollUpTray.Checked = audioPlayer.RollUp;
        }
    }
}
