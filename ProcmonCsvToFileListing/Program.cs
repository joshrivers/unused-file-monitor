using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcmonCsvToFileListing
{
    class Program
    {
        private static int _progress;

        static void Main(string[] args)
        {
            var filesAndDirectories = new SortedSet<string>();
            foreach (var line in File.ReadLines(@"c:\temp\logfile.csv"))
            {
                var fields = line.Split(',');
                if (fields[4] == "\"Path\"") continue;
                var pathField = fields[4].Replace("\"","");
                filesAndDirectories.Add(pathField);
                DisplayProgress();
            }
            File.WriteAllLines(@"c:\temp\filelisting.txt", filesAndDirectories);
            PauseAndPrompt(string.Format("Wrote {0} files.", filesAndDirectories.Count()));
        }

        private static void DisplayProgress()
        {
            _progress++;
            if (_progress % 10000 == 0) Console.Write('.');
        }


        private static void PauseAndPrompt(string promptText)
        {
            Console.Write(promptText);
            Console.ReadLine();
        }
    }
}
