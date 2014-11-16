namespace FileUseMonitor
{
    internal class FileDetail
    {
        public string Path { get; private set; }
        public bool Dirty { get; set; }

        public FileDetail(string path)
        {
            Path = path;
            Dirty = false;
        }
    }
}