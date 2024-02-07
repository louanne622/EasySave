using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsole.Model
{
    class TransferFile
    {
        private string TypeTransfer;
        private string OriginPath;
        private string TargetPath;
        private string[] filesOrigin;
        private string[] filesTarget;
        public void setOriginPath(string input)
        { this.OriginPath = input; }
        public void setTargetPath(string input)
        { this.TargetPath = input; }
        public void setTypeTransfer(string input)
        { this.TypeTransfer = input; }
        public string getOriginPath()
        { return this.OriginPath; }
        public string getTargetFile()
        { return this.TargetPath; }
        public string getTypeTransfer()
        { return this.TypeTransfer; }
        private bool VerifConditionForTransfer()
        {
            if (Directory.Exists(this.getOriginPath()) &&
               Directory.Exists(this.getOriginPath()) &&
               this.getOriginPath() != null &&
               this.getTargetFile() != null &&
               this.getTypeTransfer() != null)
                {
                return true;
            }
            return false;
        }
        public void Transfer()
        {
            if (!VerifConditionForTransfer()) { return; }
            this.filesOrigin = Directory.GetFiles(this.getOriginPath(), "*", SearchOption.AllDirectories);

            if (this.TypeTransfer == "C")
            {
                this.TransferFilesComplet();
            }
            else if (this.TypeTransfer == "D")
            {
                this.filesTarget = Directory.GetFiles(this.TargetPath, "*", SearchOption.AllDirectories);
                this.TransferFilesDiff();
            } 
        }
        private void TransferFilesComplet()
        {
            MoveFile();
        }
        private void TransferFilesDiff()
        {
            List<string> finalList = new List<string>();
            string[] filesOriginWithoutPath = (string[])this.filesOrigin.Clone();        //CLONE
            string[] filesTargetWithoutPath = (string[])this.filesTarget.Clone();        //CLONE
            DateTime[] filesOriginDateModif   = new DateTime[filesOriginWithoutPath.Length]; //DateOrigine
            DateTime[] filesTargetDateModif   = new DateTime[filesOriginWithoutPath.Length]; //DateTarget

            for (int i = 0; i < filesOriginDateModif.Length; i++) filesOriginDateModif[i] = File.GetLastWriteTime(filesOriginWithoutPath[i]);
            for (int i = 0; i < filesTargetDateModif.Length; i++) filesTargetDateModif[i] = File.GetLastWriteTime(filesTargetWithoutPath[i]);
            //for (int i = 0; i < filesOriginWithoutPath.Length; i++) Console.WriteLine(filesOriginWithoutPath[i].ToString());

            // Set up lists for having only the file and the extection (ex: filesTest.txt), without the path or Original and Target ones
            for (int i = 0; i < this.filesTarget.Length; i++) filesTargetWithoutPath[i] = filesTargetWithoutPath[i].Replace(this.TargetPath + "\\", "");
            for (int i = 0; i < this.filesOrigin.Length; i++) filesOriginWithoutPath[i] = filesOriginWithoutPath[i].Replace(this.OriginPath + "\\", "");

            for (int i = 0; i < filesTargetWithoutPath.Length; i++)
            {
                for (int j = 0; j < filesOriginWithoutPath.Length; j++) 
                    if ((filesTargetWithoutPath[i] == filesOriginWithoutPath[j])) 
                        finalList.Add(filesOrigin[j]);
            }



            /*
            // Creation of LIST to sort origin LIST for files to transfer
            List<string> finalList = new List<string>();
            string[] filesOriginWithoutPath = (string[])this.filesOrigin.Clone();  //CLONE
            string[] filesTargetWithoutPath = (string[])this.filesTarget.Clone();  //CLONE

            // Set up lists for having only the file and the extection (ex: filesTest.txt), without the path or Original and Target ones
            for (int i = 0; i < this.filesTarget.Length; i++) filesTargetWithoutPath[i] = filesTargetWithoutPath[i].Replace(this.TargetPath + "\\", "");
            for (int i = 0; i < this.filesOrigin.Length; i++) filesOriginWithoutPath[i] = filesOriginWithoutPath[i].Replace(this.OriginPath + "\\", ""); 
            for (int i = 0; i < filesTargetWithoutPath.Length; i++) {
                for (int j = 0; j < filesOriginWithoutPath.Length; j++) if ((filesTargetWithoutPath[i] == filesOriginWithoutPath[j])) finalList.Add(filesOrigin[j]);
            }
            string[] finalArray = finalList.ToArray();

            this.filesOrigin = this.filesOrigin.Except(finalArray).ToArray();
            //MoveFile();
            */
        }
        private void MoveFile()
        {
            foreach (string file in this.filesOrigin)
            {
                string relativePath = file.Substring(this.OriginPath.Length + 1);
                string destinationFilePath = Path.Combine(this.TargetPath, relativePath);
                Directory.CreateDirectory(Path.GetDirectoryName(destinationFilePath));
                File.Copy(file, destinationFilePath);
            }
        }
    }
}