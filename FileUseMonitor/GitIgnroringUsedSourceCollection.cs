using System.Linq;

namespace FileUseMonitor
{
    class GitIgnroringUsedSourceCollection : UsedSourceCollection
    {
        public virtual void AddDirectory(string path)
        {
            if (path.Contains("\\.git\\"))
            {
                return;
            }
            base.AddDirectory(path);
        }

        public virtual void AddFiles(string[] paths)
        {
            var filteredPaths = paths.Where(p => !p.Contains(@"\.git\"));
            base.AddFiles(filteredPaths.ToArray());
        }
    }
}