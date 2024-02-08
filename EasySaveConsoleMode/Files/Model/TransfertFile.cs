using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsole.Model
{
    class TransferFile
    {
        //Creation of all the attributes
        private string TypeTransfer;
        public string OriginPath;
        private string TargetPath;
        public string[] filesOrigin;
        public string[] filesTarget;

        //initialisation of our methods enabling attributes to be used
        public void setAllData(string originInput, string targetInput, string typeInput)
        {
            this.OriginPath = originInput;
            this.TargetPath = targetInput;
            this.TypeTransfer = typeInput;
        }
        public bool VerifConditionForTransfer()
        {
            return Directory.Exists(this.OriginPath) &&
               Directory.Exists(this.TargetPath) &&
               this.OriginPath != null &&
               this.TargetPath != null &&
               this.TypeTransfer != null &&
               this.OriginPath != this.TargetPath;
        }
        public void TransferFilesComplet()
        {
            MoveFile();
        }
        public void TransferFilesDiff()
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
            //for (int i = 0; i < filesOriginWithoutPath.Length; i++) Console.WriteLine(filesOriginWithoutPath[i].ToString());

            // Set up lists for having only the file and the extection (ex: filesTest.txt), without the path or Original and Target ones
            for (int i = 0; i < this.filesTarget.Length; i++) filesTargetWithoutPath[i] = filesTargetWithoutPath[i].Replace(this.TargetPath + "\\", "");
            for (int i = 0; i < this.filesOrigin.Length; i++) filesOriginWithoutPath[i] = filesOriginWithoutPath[i].Replace(this.OriginPath + "\\", "");

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
            MoveFile();
        }
        private void deleteFiles(string[] input)
        {
            // Delete the files in the input list (with Path)
            foreach (string filePath in input)
                if (File.Exists(filePath)) File.Delete(filePath);
        }
        private void MoveFile()
        {
            // Transfer the file from a folder to an other one
            foreach (string file in this.filesOrigin)
            {
                string relativePath = file.Substring(this.OriginPath.Length + 1);
                string destinationFilePath = Path.Combine(this.TargetPath, relativePath);
                Directory.CreateDirectory(Path.GetDirectoryName(destinationFilePath));
                File.Copy(file, destinationFilePath, true); // Overwrite true (forcing to replace files)
            }
        }
        public void setFilesOrigin(string originInput)
        {
            this.filesOrigin = Directory.GetFiles(originInput, "*", SearchOption.AllDirectories);
        }
        public void setFilesTarget(string targetInput)
        {
            this.filesTarget = Directory.GetFiles(targetInput, "*", SearchOption.AllDirectories);
        }
    }
}