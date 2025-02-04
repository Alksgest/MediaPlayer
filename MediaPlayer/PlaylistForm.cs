using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.ComponentModel;

namespace MediaPlayer
{
    [Serializable]
    public partial class PlaylistForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrentName { get; set; }
        
        private MainForm _audioPlayer;
        private List<PlaylistData> _playlistData = new List<PlaylistData>();

        public PlaylistForm(MainForm audioPlayer)
        {
            InitializeComponent();

            _audioPlayer = audioPlayer;
            Location = new Point(_audioPlayer.Location.X + 10 + _audioPlayer.Width, _audioPlayer.Location.Y);
            BackColor = audioPlayer.BackColor;

            RegisterOnEvents();
        }

        private void RegisterOnEvents()
        {
            MainListBox.DoubleClick += MainListBox_DoubleClick;
            FormClosing += PlaylistForm_FormClosing;
            Load += PlaylistForm_Load;
            MainListBox.KeyDown += MainListBox_KeyDown;
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
                using (var fileStream = new FileStream("Playlists.dat", FileMode.Open, FileAccess.Read))
                {
#pragma warning disable SYSLIB0011
                    var binaryFormatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                    _playlistData = (List<PlaylistData>)binaryFormatter.Deserialize(fileStream);
                    fileStream.Close();
                }
            }
            foreach (var item in _playlistData)
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
                using (var fileStream = new FileStream("Playlists.dat", FileMode.Create, FileAccess.Write))
                {
#pragma warning disable SYSLIB0011
                    var binaryFormatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                    binaryFormatter.Serialize(fileStream, _playlistData);
                    fileStream.Close();
                }
            }
        }

        private void MainListBox_DoubleClick(object sender, EventArgs e)
        {
            if (MainListBox.SelectedIndex != -1)
            {
                _audioPlayer.listBoxMedia.Items.Clear();
                foreach (var item in (MainListBox.SelectedItem as PlaylistData).AudioFiles)
                {
                    _audioPlayer.listBoxMedia.Items.Add(item);
                }
            }
        }

        private void AddFilesButton_Click(object sender, EventArgs e) => AddPlayList();

        private void AddPlayList()
        {
            SetNameDialog();
            if (String.IsNullOrEmpty(CurrentName))
                CurrentName = "Unnamed playlist";
            var playList = _audioPlayer.listBoxMedia.Items.Cast<PathHolder>();
            var data = new PlaylistData(CurrentName, playList.ToList<PathHolder>());

            if (data.AudioFiles.Count != 0)
            {
                MainListBox.Items.Add(data);
                _playlistData.Add(data);
            }
        }

        private void RemoveFilesButton_Click(object sender, EventArgs e) => DeletePlaylist();

        private void DeletePlaylist()
        {
            if (MainListBox.SelectedIndex != -1)
            {
                if (MessageBox.Show("Delete this playlist?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var tmpIndex = MainListBox.SelectedIndex;
                    MainListBox.Items.RemoveAt(MainListBox.SelectedIndex);
                    _playlistData.RemoveAt(tmpIndex);
                }
            }
        }


        private void RenamePlaylistButton_Click(object sender, EventArgs e) => ShowRenameDialog();

        private void SetNameDialog()
        {
            var enterNameForm = new EnterNameForm(this);
            enterNameForm.ShowDialog();
        }
        private void ShowRenameDialog()
        {
            if (MainListBox.SelectedIndex != -1)
            {
                var enterNameForm = new EnterNameForm(this);
                enterNameForm.ShowDialog();
                if (!String.IsNullOrEmpty(CurrentName))
                    (MainListBox.SelectedItem as PlaylistData).Title = CurrentName;
                var items = MainListBox.Items.Cast<PlaylistData>().ToList();
                MainListBox.Items.Clear();
                foreach (var item in items)
                    MainListBox.Items.Add(item);
            }
        }
    }
}
