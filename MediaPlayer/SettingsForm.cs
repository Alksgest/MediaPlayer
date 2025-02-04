using System;
using System.Drawing;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class SettingsForm : Form
    {
        private MainForm _audioPlayer;
        private const string FormatFilter = "Image Files (*.jpg; *.png; *.bmp) |*.jpg;*.png;*.bmp";
        
        public SettingsForm(MainForm audioPlayer)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.Manual;
            this._audioPlayer = audioPlayer;
            Location = new Point(audioPlayer.Location.X - 10 - Width, audioPlayer.Location.Y);
            BackColor = audioPlayer.BackColor;

            PathTextBox.Text = audioPlayer.PathToDefaultImage;
        }

        private void checkBoxSavePathToFolder_CheckedChanged(object sender, EventArgs e)
        {
            _audioPlayer.SavePathToFolder = checkBoxSavePathToFolder.Checked;
        }

        private void checkBoxRepeatCircle_CheckedChanged(object sender, EventArgs e)
        {
            _audioPlayer.RepeatByCircle = checkBoxRepeatCircle.Checked;
        }

        private void checkBoxRollUpTray_CheckedChanged(object sender, EventArgs e)
        {
            _audioPlayer.RollUp = checkBoxRollUpTray.Checked;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {          
            checkBoxSavePathToFolder.Checked = _audioPlayer.SavePathToFolder;
            checkBoxRepeatCircle.Checked = _audioPlayer.RepeatByCircle;
            checkBoxRollUpTray.Checked = _audioPlayer.RollUp;
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = FormatFilter;
            
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PathTextBox.Text = openFileDialog.FileName;
                _audioPlayer.PathToDefaultImage = openFileDialog.FileName;
            }
        }
    }
}
