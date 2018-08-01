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
        private const string FormatFilter = "Image Files (*.jpg; *.png; *.bmp) |*.jpg;*.png;*.bmp";
        private AudioPlayer audioPlayer;
        public SettingsForm(AudioPlayer audioPlayer)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.audioPlayer = audioPlayer;
            this.Location = new Point(audioPlayer.Location.X - 10 - this.Width, audioPlayer.Location.Y);
            this.BackColor = audioPlayer.BackColor;

            this.PathTextBox.Text = audioPlayer.pathToDefaultImage;
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

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = FormatFilter;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.PathTextBox.Text = openFileDialog.FileName;
                audioPlayer.pathToDefaultImage = openFileDialog.FileName;
            }
        }
    }
}
