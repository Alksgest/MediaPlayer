using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MediaPlayer
{
    [Serializable]
    public partial class PlaylistForm : Form
    {
        public string CurrentName { get; set; }
        MainForm AudioPlayer;
        List<PlaylistData> PlaylistData = new List<PlaylistData>();

        public PlaylistForm(MainForm audioPlayer)
        {
            InitializeComponent();

            this.AudioPlayer = audioPlayer;
            this.Location = new Point(AudioPlayer.Location.X + 10 + AudioPlayer.Width, AudioPlayer.Location.Y);
            this.BackColor = audioPlayer.BackColor;

            RegisterOnEvents();
        }

        private void RegisterOnEvents()
        {
            this.MainListBox.DoubleClick += MainListBox_DoubleClick;
            this.FormClosing += PlaylistForm_FormClosing;
            this.Load += PlaylistForm_Load;
            this.MainListBox.KeyDown += MainListBox_KeyDown;
        }

        private void MainListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeletePlaylist();
        }

        private void PlaylistForm_Load(object sender, EventArgs e)
        {
            LoadPlaylists();
        }

        private void LoadPlaylists()
        {
            if (File.Exists("Playlists.dat"))
            {
                using (FileStream fileStream = new FileStream("Playlists.dat", FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    PlaylistData = (List<PlaylistData>)binaryFormatter.Deserialize(fileStream);
                    fileStream.Close();
                }
            }
            foreach (var item in PlaylistData)
            {
                MainListBox.Items.Add(item);
            }
        }

        private void PlaylistForm_FormClosing(object sender, FormClosingEventArgs e) => SerializeData();

        private void SerializeData()
        {
            if (MainListBox.Items.Count == 0)
            {
                if (File.Exists("Playlists.dat"))
                    File.Delete("Playlists.dat");
            }
            else
            {
                using (FileStream fileStream = new FileStream("Playlists.dat", FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, PlaylistData);
                    fileStream.Close();
                }
            }
        }

        private void MainListBox_DoubleClick(object sender, EventArgs e)
        {
            if (this.MainListBox.SelectedIndex != -1)
            {
                AudioPlayer.listBoxMedia.Items.Clear();
                foreach (var item in (this.MainListBox.SelectedItem as PlaylistData).AudioFiles)
                {
                    AudioPlayer.listBoxMedia.Items.Add(item);
                }
            }
        }

        private void AddFilesButton_Click(object sender, EventArgs e) => AddPlayList();

        private void AddPlayList()
        {
            SetNameDialog();
            if (String.IsNullOrEmpty(CurrentName))
                CurrentName = "Unnamed playlist";
            var playList = AudioPlayer.listBoxMedia.Items.Cast<PathHolder>();
            PlaylistData data = new PlaylistData(CurrentName, playList.ToList<PathHolder>());

            if (data.AudioFiles.Count != 0)
            {
                MainListBox.Items.Add(data);
                PlaylistData.Add(data);
            }
        }

        private void RemoveFilesButton_Click(object sender, EventArgs e) => DeletePlaylist();

        private void DeletePlaylist()
        {
            if (this.MainListBox.SelectedIndex != -1)
            {
                if (MessageBox.Show("Delete this playlist?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int tmpIndex = this.MainListBox.SelectedIndex;
                    this.MainListBox.Items.RemoveAt(this.MainListBox.SelectedIndex);
                    PlaylistData.RemoveAt(tmpIndex);
                }
            }
        }


        private void RenamePlaylistButton_Click(object sender, EventArgs e) => ShowRenameDialog();

        private void SetNameDialog()
        {
            EnterNameForm enterNameForm = new EnterNameForm(this);
            enterNameForm.ShowDialog();
        }
        private void ShowRenameDialog()
        {
            if (this.MainListBox.SelectedIndex != -1)
            {
                EnterNameForm enterNameForm = new EnterNameForm(this);
                enterNameForm.ShowDialog();
                if (!String.IsNullOrEmpty(CurrentName))
                    (this.MainListBox.SelectedItem as PlaylistData).Title = CurrentName;
                var items = this.MainListBox.Items.Cast<PlaylistData>().ToList();
                this.MainListBox.Items.Clear();
                foreach (var item in items)
                    this.MainListBox.Items.Add(item);
            }
        }
    }
}
