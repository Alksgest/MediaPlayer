using System;
using System.Drawing;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class SettingsForm : Form
    {
        private const string FormatFilter = "Image Files (*.jpg; *.png; *.bmp) |*.jpg;*.png;*.bmp";
        private MainForm audioPlayer;
        public SettingsForm(MainForm audioPlayer)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.Manual;
            this.audioPlayer = audioPlayer;
            Location = new Point(audioPlayer.Location.X - 10 - Width, audioPlayer.Location.Y);
            BackColor = audioPlayer.BackColor;

            PathTextBox.Text = audioPlayer.PathToDefaultImage;
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
                PathTextBox.Text = openFileDialog.FileName;
                audioPlayer.PathToDefaultImage = openFileDialog.FileName;
            }
        }
    }
}
