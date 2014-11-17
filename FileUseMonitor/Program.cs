using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUseMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToCompare = "c:\\d\\trunk\\";
            var procMonListing = new HashSet<string>(File.ReadLines(@"c:\temp\filelisting.txt").Select(l=>l.ToLower()));
            var usedSourceCollection = UsedSourceCollectionFromDirectoryFactory.CreateFileCollectionFromPath(pathToCompare, procMonListing);
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
