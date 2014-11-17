using System;
using System.Collections.Generic;

namespace FileUseMonitor
{
    class UsedSourceCollectionIgnoringGitAndWithDirtyList : GitIgnroringUsedSourceCollection
    {
        private readonly HashSet<string> _dirtyList;

        public UsedSourceCollectionIgnoringGitAndWithDirtyList(HashSet<string> DirtyList)
        {
            _dirtyList = DirtyList;
        }

        public override void AddFiles(string[] paths)
        {
            foreach (var path in paths)
            {
                if (_dirtyList.Contains(path.ToLower()))
                {
                    _fileList.AddDirtyFileDetail(path);
                }
                else
                {
                    _fileList.AddFileDetail(path);
                }
            }
        }
    }
}