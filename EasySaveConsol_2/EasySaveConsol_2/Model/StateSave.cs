using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsol_2
{
    class StateSave
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }
        public string State { get; set; }
        public string TotalFilesToCopy { get; set; }
        public string TotalFilesSize { get; set; }
        public string NbFilesLeftToDo { get; set; }
        public string Progression { get; set; }
        public StateSave(Save _save)
        {
            this.Id = _save.Id.ToString();
            this.Name = _save.Name;
            this.SourceFilePath = _save.FilesSource;
            this.TargetFilePath = _save.FilesTarget;
            this.State = "ACTIVE";
            switch (_save.Type)
            {
                case "C":
                    this.TotalFilesToCopy = Directory.GetFiles(_save.FilesSource, "*", SearchOption.AllDirectories).Length.ToString();
                    break;
                case "S":
                    break;
            }

            this.TotalFilesToCopy = "";

            // Directory.GetFiles(_save.FilesSource, "*", SearchOption.AllDirectories);

        }
        private int GetFilesToCopy(string _path)
        {

            return 1;
        }
    }
}
