using System;
using System.IO;

namespace FileUseMonitor
{
    class UsedSourceFileSystemWatcher : FileSystemWatcher
    {
        public UsedSourceFileSystemWatcher(string pathToObserve,
            UsedSourceCollection accessedFileCollection) : base(pathToObserve)
        {
            NotifyFilter =  NotifyFilters.LastAccess;
            IncludeSubdirectories = true;
            Changed += (s, e) =>
            {
                accessedFileCollection.MarkFileAsAccessed(e.FullPath);
                Console.WriteLine(e.FullPath);
            };
            Created += (s, e) => accessedFileCollection.MarkFileAsAccessed(e.FullPath);
            Deleted += (s, e) => accessedFileCollection.MarkFileAsAccessed(e.FullPath);
            Renamed += (s, e) =>
            {
                accessedFileCollection.MarkFileAsAccessed(e.FullPath);
                accessedFileCollection.MarkFileAsAccessed(e.OldFullPath);
            };
            Console.WriteLine(this.NotifyFilter);
        }

        public void StartWatching()
        {
            EnableRaisingEvents = true;
        }

        public void StopWatching()
        {
            EnableRaisingEvents = false;
        }
    }
}