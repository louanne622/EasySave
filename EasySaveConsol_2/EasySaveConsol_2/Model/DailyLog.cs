using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace EasySaveConsol_2
{
    class DailyLog
    {
        public string name { get; set; }
        public string fileSource { get; set; }
        public string fileTarget { get; set; }
        public string size { get; set; }
        public string fileTransferTime { get; set; }
        public string time { get; set; }
        private void setDayliLogData(Save _save, string _fileTransferTime)
        {
            this.name = _save.Name;
            this.fileSource = _save.FilesSource;
            this.fileTarget = _save.FilesTarget;
            this.size = ClassUtility.GetSizeFiles(this.GetFilesToCopy(_save));
            this.fileTransferTime = _fileTransferTime;
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
        private void createFile(string _pathLogFile)
        {
            if (File.Exists(_pathLogFile)) return;
            File.WriteAllText(_pathLogFile, "[]");
        }
        public void SetDailyLogDataInJson(Save _save, string _fileTransferTime, string _extension)
        {
            setDayliLogData(_save, _fileTransferTime);
            if (_extension == "1")
            {
                string _today = DateTime.Now.ToString("dd_MM_yyyy") + ".json";
                string _pathJson = AppDomain.CurrentDomain.BaseDirectory + @"\Log\DailyLog\" + _today;
                this.createFile(_pathJson);
                string jsonContent = File.ReadAllText(_pathJson);
                List<dynamic> jsonArray = JsonSerializer.Deserialize<List<dynamic>>(jsonContent);
                dynamic NewObj = new
                {
                    Name = this.name,
                    FileSource = this.fileSource,
                    FileTarget = this.fileTarget,
                    FileSize = this.size,
                    FileTransferTim = _fileTransferTime,
                    Time = DateTime.Now.ToString("dd/MM/yyyy H:m:ss")
                };
                jsonArray.Add(NewObj);
                string updatedJson = JsonSerializer.Serialize(jsonArray, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_pathJson, updatedJson);
            } 
            else if (_extension == "2")
            {
                string _today = DateTime.Now.ToString("dd_MM_yyyy") + ".xml";
                string _pathJson = AppDomain.CurrentDomain.BaseDirectory + @"\Log\DailyLog\" + _today;
                //this.createFile(_pathJson);
            }
        }
    }
}