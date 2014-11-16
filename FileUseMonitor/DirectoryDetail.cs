namespace FileUseMonitor
{
    internal class DirectoryDetail
    {
        public string Path { get; private set; }

        public DirectoryDetail(string path)
        {
            Path = path;
        }
    }
}