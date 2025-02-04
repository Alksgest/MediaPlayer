using System;
using System.Collections.Generic;

namespace MediaPlayer.Models;

[Serializable]
internal class PlaylistData
{
    public string Title { get; set; }
    public List<AudioFileInfo> AudioFiles { get; init; }
    public override string ToString() => Title;
}