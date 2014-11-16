using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileUseMonitor
{
    internal class UsedSourceCollection
    {
        private readonly DirectoryCollection _directoryList = new DirectoryCollection();
        private readonly FileCollection _fileList = new FileCollection();

        public virtual void AddDirectory(string path)
        {
            _directoryList.AddDirectory(path);
        }

        public virtual void AddFiles(string[] paths)
        {
            foreach (var path in paths)
            {
                _fileList.AddFileDetail(path);
            }
        }

        public override string ToString()
        {
            return string.Format("Found {0} directories, containing {1} files {2} of which are dirty.", _directoryList.Count(),
                _fileList.Count(), _fileList.Count(f => f.Dirty));
        }

        public void MarkFileAsAccessed(string path)
        {
            var fileItem = _fileList.FindOrCreateFileDetail(path);
           fileItem.Dirty = true;
        }

        public IEnumerable<string> ListCleanDirectories()
        {
            return _directoryList.Where(item => !_fileList.ContainsDirtyFile(item.Path)).Select(item => item.Path);
        }
    }
}