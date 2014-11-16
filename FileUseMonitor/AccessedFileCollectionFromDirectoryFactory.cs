using System;
using System.Collections.Generic;
using System.IO;

namespace FileUseMonitor
{
    class UsedSourceCollectionFromDirectoryFactory
    {
        public static UsedSourceCollection CreateFileCollectionFromPath(string path)
        {
            var fileCollection = new GitIgnroringUsedSourceCollection();
            var directoryQueue = new Queue<string>();
            directoryQueue.Enqueue(path);
            while (directoryQueue.Count > 0)
            {
                path = directoryQueue.Dequeue();
                fileCollection.AddDirectory(path);
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        directoryQueue.Enqueue(subDir);
                    }
                }
                catch (System.IO.PathTooLongException pathTooLongException)
                {
                    Console.Error.WriteLine("Path {0} was too long", path);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path);
                    fileCollection.AddFiles(files);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            }
            return fileCollection;
        }
    }
}