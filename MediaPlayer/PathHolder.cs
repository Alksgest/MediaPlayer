namespace MediaPlayer
{
    public class PathHolder
    {
        public string Title;
        public string FullPath;

        public PathHolder(string fullPath)
        {
            var splitedPath = fullPath.Split('\\');
            this.Title = splitedPath[splitedPath.Length - 1];
            this.FullPath = fullPath;
        }
        public override string ToString() => Title;
    }
}
