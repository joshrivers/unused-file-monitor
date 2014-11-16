using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileUseMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToObserve = "c:\\d\\trunk\\";

            var usedSourceCollection = UsedSourceCollectionFromDirectoryFactory.CreateFileCollectionFromPath(pathToObserve);
            DescribeCollection(usedSourceCollection);
            PauseAndPrompt("Press <enter> to start the sample.");

            Console.WriteLine("\r\nWatching directory.");
            var watcher = new UsedSourceFileSystemWatcher(pathToObserve, usedSourceCollection);
            watcher.StartWatching();

            PauseAndPrompt("Press <enter> to stop.");
            watcher.StopWatching();
            DescribeCollection(usedSourceCollection);
            File.WriteAllLines(@"C:\temp\CleanDirectories.log", usedSourceCollection.ListCleanDirectories());

            PauseAndPrompt("Press <enter> to dismiss.");
        }

        private static void DescribeCollection(UsedSourceCollection accessedFileCollection)
        {
            Console.WriteLine(accessedFileCollection);
        }

        private static void PauseAndPrompt(string promptText)
        {
            Console.Write(promptText);
            Console.ReadLine();
        }
    }
}
