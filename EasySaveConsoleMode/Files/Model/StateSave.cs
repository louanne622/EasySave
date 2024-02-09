using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsole.Model
{
    class StateSave
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }
        public string State { get; set; }
        public long TotalFilesToCopy { get; set; }
        public long TotalFilesSize { get; set; }
        public long NbFilesLeftToDo { get; set; }
        public int Progression { get; set; }
    }
}
