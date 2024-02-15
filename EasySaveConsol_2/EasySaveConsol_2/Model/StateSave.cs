using System;
using System.IO;
using System.Linq;
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
        public void SetStateSave(Save _save)
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
                    this.TotalFilesToCopy = this.GetFilesToCopy(_save).Length.ToString();
                    break;
                default:
                    this.TotalFilesToCopy = "NA";
                    break;
            }
            this.TotalFilesSize = ClassUtility.GetSizeFiles(this.GetFilesToCopy(_save));
            this.NbFilesLeftToDo = this.TotalFilesToCopy;
            this.Progression = "0";
        }
        private string[] GetFilesToCopy(Save _save)
        {
            List<string> deleteList = new List<string>();
            List<string> finalList = new List<string>();

            string[] filesOrigin = Directory.GetFiles(_save.FilesSource, "*", SearchOption.AllDirectories);
            string[] filesTarget = Directory.GetFiles(_save.FilesTarget, "*", SearchOption.AllDirectories);
            string[] filesOriginWithoutPath = (string[])filesOrigin.Clone();        //CLONE
            string[] filesTargetWithoutPath = (string[])filesTarget.Clone();        //CLONE

            DateTime[] filesOriginDateModif = new DateTime[filesOriginWithoutPath.Length]; //DateOrigine
            DateTime[] filesTargetDateModif = new DateTime[filesTargetWithoutPath.Length]; //DateTarget

            for (int i = 0; i < filesOriginDateModif.Length; i++) filesOriginDateModif[i] = File.GetLastWriteTime(filesOriginWithoutPath[i]);
            for (int i = 0; i < filesTargetDateModif.Length; i++) filesTargetDateModif[i] = File.GetLastWriteTime(filesTargetWithoutPath[i]);

            // Set up lists for having only the file and the extection (ex: filesTest.txt), without the path or Original and Target ones
            for (int i = 0; i < filesOrigin.Length; i++) filesOriginWithoutPath[i] = filesOriginWithoutPath[i].Replace(_save.FilesSource + "\\", "");
            for (int i = 0; i < filesTarget.Length; i++) filesTargetWithoutPath[i] = filesTargetWithoutPath[i].Replace(_save.FilesTarget + "\\", "");

            for (int i = 0; i < filesTargetWithoutPath.Length; i++)
                for (int j = 0; j < filesOriginWithoutPath.Length; j++)
                    if ((filesTargetWithoutPath[i] == filesOriginWithoutPath[j]))
                        if (filesOriginDateModif[j] > filesTargetDateModif[i]) deleteList.Add(filesTarget[i]);
                        else finalList.Add(filesOrigin[j]);

            string[] finalArray = finalList.ToArray();
            return filesOrigin.Except(finalArray).ToArray();
        }
    }
}