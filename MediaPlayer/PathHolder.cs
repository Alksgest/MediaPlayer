﻿using System;
using System.Collections.Generic;

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

        public override bool Equals(object obj) => (obj as PathHolder).Title == this.Title && 
                                                   (obj as PathHolder).FullPath == this.FullPath;
        public static bool operator ==(PathHolder left, PathHolder right) => left.Equals(right);
        public static bool operator !=(PathHolder left, PathHolder right) => !left.Equals(right);

        public override int GetHashCode()
        {
            var hashCode = 463277484;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullPath);
            return hashCode;
        }
    }
}
