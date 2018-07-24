using System;

namespace MediaPlayer
{
    [Serializable]
    public class PathHolder
    {
        public string Title { get; }
        public string FullPath { get; }

        public PathHolder(string fullPath)
        {
            var splitedPath = fullPath.Split('\\');
            this.Title = splitedPath[splitedPath.Length - 1];
            this.FullPath = fullPath;
        }
        public override string ToString() => Title;
    }
}
