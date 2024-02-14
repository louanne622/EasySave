using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace EasySaveConsol_2
{
    class Transfer
    {
        public string[] filesOrigin;
        public string[] filesTarget;

        public void setFilesFilesList(Save _save)
        {
            this.filesOrigin = Directory.GetFiles(_save.FilesSource, "*", SearchOption.AllDirectories);
            this.filesTarget = Directory.GetFiles(_save.FilesTarget, "*", SearchOption.AllDirectories);
        }
        private void MoveFile(Save _save)
        {
            // Transfer the file from a folder to an other one
            foreach (string file in this.filesOrigin)
            {
                string relativePath = file.Substring(_save.FilesSource.Length + 1);
                string destinationFilePath = Path.Combine(_save.FilesTarget, relativePath);
                Directory.CreateDirectory(Path.GetDirectoryName(destinationFilePath));
                File.Copy(file, destinationFilePath, true); // Overwrite true (forcing to replace files)
            }
        }
        public void TransferCom(Save _save)
        {
            this.MoveFile(_save);
        }
        public void TransferSeq(Save _save)
        {
            List<string> finalList = new List<string>();
            List<string> dateList = new List<string>();
            List<string> deleteList = new List<string>();
            string[] filesOriginWithoutPath = (string[])this.filesOrigin.Clone();        //CLONE
            string[] filesTargetWithoutPath = (string[])this.filesTarget.Clone();        //CLONE
            DateTime[] filesOriginDateModif = new DateTime[filesOriginWithoutPath.Length]; //DateOrigine
            DateTime[] filesTargetDateModif = new DateTime[filesTargetWithoutPath.Length]; //DateTarget

            for (int i = 0; i < filesOriginDateModif.Length; i++) filesOriginDateModif[i] = File.GetLastWriteTime(filesOriginWithoutPath[i]);
            for (int i = 0; i < filesTargetDateModif.Length; i++) filesTargetDateModif[i] = File.GetLastWriteTime(filesTargetWithoutPath[i]);

            // Set up lists for having only the file and the extection (ex: filesTest.txt), without the path or Original and Target ones
            for (int i = 0; i < this.filesTarget.Length; i++) filesTargetWithoutPath[i] = filesTargetWithoutPath[i].Replace(_save.FilesTarget + "\\", "");
            for (int i = 0; i < this.filesOrigin.Length; i++) filesOriginWithoutPath[i] = filesOriginWithoutPath[i].Replace(_save.FilesSource + "\\", "");

            for (int i = 0; i < filesTargetWithoutPath.Length; i++)
                for (int j = 0; j < filesOriginWithoutPath.Length; j++)
                    if ((filesTargetWithoutPath[i] == filesOriginWithoutPath[j]))
                        if (filesTargetDateModif[i] < filesOriginDateModif[j]) deleteList.Add(filesTarget[i]);
                        else finalList.Add(filesOrigin[j]);

            string[] finalArray = finalList.ToArray();
            string[] deleteArray = deleteList.ToArray();

            this.filesOrigin = this.filesOrigin.Except(finalArray).ToArray();

            // Delete files that are already in the final folder with a different ModifDate
            // and transfer the files that are not in the final folder
            this.deleteFiles(deleteArray);
            this.MoveFile(_save);
        }
        private void deleteFiles(string[] input)
        {
            // Delete the files in the input list (with Path)
            foreach (string filePath in input)
                if (File.Exists(filePath)) File.Delete(filePath);
        }
        
    }
}
