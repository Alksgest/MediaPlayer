using System;
using System.Collections.Generic;

namespace MediaPlayer.Models;

[Serializable]
internal class PlaylistData
{
    public string Title { get; set; }
    public List<PathHolder> AudioFiles { get; }
    public override string ToString() => Title;


    public PlaylistData(string title, List<PathHolder> audioFiles)
    {
        Title = title;
        AudioFiles = audioFiles;
    }
}