using System;
using System.Collections.Generic;

namespace MediaPlayer.Models;

[Serializable]
public class AudioFileInfo
{
    public string Title { get; }
    public string FullPath { get; }
        
    public AudioFileInfo(string fullPath)
    {
        var splitPath = fullPath.Split('\\');
        Title = splitPath[^1];
        FullPath = fullPath;
    }
}