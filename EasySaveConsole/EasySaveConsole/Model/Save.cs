using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsole.Model
{
    class Save
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilesSource { get; set; }
        public string FilesTarget { get; set; }
        public string Type { get; set; }
    }
}
