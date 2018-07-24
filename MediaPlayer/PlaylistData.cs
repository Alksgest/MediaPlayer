using System;
using System.Collections.Generic;

namespace MediaPlayer
{
    [Serializable]
    class PlaylistData
    {
        public string Title { get; set; }
        public List<PathHolder> AudioFiles { get; }
        public PlaylistData(string title, List<PathHolder> audioFiles)
        {
            Title = title;
            AudioFiles = audioFiles;

        }
        public override string ToString() => Title;
    }
}
