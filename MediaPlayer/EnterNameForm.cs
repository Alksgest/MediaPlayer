using System;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class EnterNameForm : Form
    {
        private PlaylistForm _playlistForm;
        public EnterNameForm(PlaylistForm form)
        {
            InitializeComponent();
            _playlistForm = form;
            KeyDown += EnterNameForm_KeyDown;
            NameTextBox.KeyDown += NameTextBox_KeyDown;
            NameTextBox.Focus();
        }

        private void NameTextBox_KeyDown(object sender, KeyEventArgs e) => EnterPressedOnForm(e);
        private void EnterNameForm_KeyDown(object sender, KeyEventArgs e) => EnterPressedOnForm(e);

        private void EnterPressedOnForm(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AcceptName();
        }



        private void OKButton_Click(object sender, EventArgs e) => AcceptName();

        private void AcceptName()
        {
            if (!String.IsNullOrEmpty(NameTextBox.Text))
                _playlistForm.CurrentName = NameTextBox.Text;
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e) => Close();

    }
}
