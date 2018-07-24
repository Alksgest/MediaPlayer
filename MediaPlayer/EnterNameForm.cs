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
    public partial class EnterNameForm : Form
    {
        PlaylistForm playlistForm;
        public EnterNameForm(PlaylistForm form)
        {
            InitializeComponent();
            playlistForm = form;
            this.KeyDown += EnterNameForm_KeyDown;
            this.NameTextBox.KeyDown += NameTextBox_KeyDown;
            this.NameTextBox.Focus();
        }

        private void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AcceptName();
        }

        private void EnterNameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AcceptName();
        }

        private void OKButton_Click(object sender, EventArgs e) => AcceptName();

        private void AcceptName()
        {
            if (!String.IsNullOrEmpty(this.NameTextBox.Text))
                playlistForm.currentName = this.NameTextBox.Text;
            this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e) => this.Close();

    }
}
