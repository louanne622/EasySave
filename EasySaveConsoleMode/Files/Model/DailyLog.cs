using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace EasySaveConsole.Model
{
    class DailyLog
    {
        private Save _save;
        public string size { get; set; }
        public string time { get; set; }
        private string PathLogLocation;
        public DailyLog()
        {
            this.PathLogLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Log\\DailyLog";
        }
        public void setSaveDailyLog(Save _save)
        {
            this._save = _save;
        }
        private void createFile(string _pathLogFile)
        {
            if (File.Exists(_pathLogFile)) return;
            File.WriteAllText(_pathLogFile, "[]");
        }
        public void WriteLogFile()
        {
            string _today = DateTime.Now.ToString("dd_MM_yyyy") + ".json";
            this.createFile(this.PathLogLocation + "\\" + _today);
            string jsonContent = File.ReadAllText(this.PathLogLocation + "\\" + _today);
            List<dynamic> jsonArray = JsonSerializer.Deserialize<List<dynamic>>(jsonContent);
            dynamic NewObj = new
            {
                Name = this._save.Name,
                FileSource = this._save.FilesSource,
                FileTarget = this._save.FilesTarget,
                FileSize = this.size,
                FileTransferTim = this.time,
                Time = DateTime.Now.ToString("dd/MM/yyyy H:m:ss")
            };
            jsonArray.Add(NewObj);
            string updatedJson = JsonSerializer.Serialize(jsonArray, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(this.PathLogLocation + "\\" + _today, updatedJson);
        }
    }
}
