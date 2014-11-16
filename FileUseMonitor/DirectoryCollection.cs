using System.Collections.Generic;

namespace FileUseMonitor
{
    internal class DirectoryCollection : List<DirectoryDetail>
    {
        public void AddDirectory(string path)
        {
            var directoryItem = new DirectoryDetail(path);
            this.Add(directoryItem);
        }
    }
}