using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MediaPlayer
{
    [Serializable]
    public partial class PlaylistForm : Form
    {
        AudioPlayer AudioPlayer;
        List<PlaylistData> PlaylistData = new List<PlaylistData>();

        public PlaylistForm(AudioPlayer audioPlayer)
        {
            this.AudioPlayer = audioPlayer;
            InitializeComponent();
            this.Location = new Point(AudioPlayer.Location.X + 10 + AudioPlayer.Width, AudioPlayer.Location.Y);
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = audioPlayer.BackColor;
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
            if (File.Exists("Playlists.dat")) {
                using (FileStream fileStream = new FileStream("Playlists.dat", FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    PlaylistData = (List<PlaylistData>)binaryFormatter.Deserialize(fileStream); 
                    fileStream.Close();
                }
            }
            foreach(var item in PlaylistData)
            {
                MainListBox.Items.Add(item);
            }
        }

        private void PlaylistForm_FormClosing(object sender, FormClosingEventArgs e) => SerializeData();
        private void ButtonClose_Click(object sender, EventArgs e) => this.Close();
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
                    AudioPlayer.PathToImage = null; 
                }
            }
        }

        private void AddFilesButton_Click(object sender, EventArgs e) => AddPlayList();

        private void AddPlayList()
        {
            var playList = AudioPlayer.listBoxMedia.Items.Cast<PathHolder>();
            PlaylistData data = new PlaylistData("Playlist1", playList.ToList<PathHolder>());

            MainListBox.Items.Add(data);

            PlaylistData.Add(data);
        }

        private void RemoveFilesButton_Click(object sender, EventArgs e) => DeletePlaylist();

        private void DeletePlaylist()
        {
            if (MessageBox.Show("Delete this playlist?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (this.MainListBox.SelectedIndex != -1)
                {
                    int tmpIndex = this.MainListBox.SelectedIndex;
                    this.MainListBox.Items.RemoveAt(this.MainListBox.SelectedIndex);
                    PlaylistData.RemoveAt(tmpIndex);
                }
            }
        }

        private void RenaymPlaylistButton_Click(object sender, EventArgs e)
        {
            if (this.MainListBox.SelectedIndex != -1)
            {
                (this.MainListBox.SelectedItem as PlaylistData).Title = "New Title";
            }
        }
    }
}
