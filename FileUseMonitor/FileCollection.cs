using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileUseMonitor
{
    internal class FileCollection : List<FileDetail>
    {
        public void AddFileDetail(string path)
        {
            var fileItem = new FileDetail(path);
            this.Add(fileItem);
        }

        public void AddDirtyFileDetail(string path)
        {
            var fileItem = new FileDetail(path);
            fileItem.Dirty = true;
            this.Add(fileItem);
        }

        public FileDetail FindOrCreateFileDetail(string path)
        {
            var fileItem = this.SingleOrDefault(f => f.Path == path);
            if (fileItem == null)
            {
                fileItem = new FileDetail(path);
                this.Add(fileItem);
            }
            return fileItem;
        }

        public bool ContainsDirtyFile(string path)
        {
            return this.Any(f => f.Dirty && f.Path.Contains(path));
        }
    }
}