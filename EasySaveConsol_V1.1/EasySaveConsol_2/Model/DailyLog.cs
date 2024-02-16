using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.Xml;

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
        private void createFileXml(string _pathLogFile)
        {
            if (File.Exists(_pathLogFile)) return;
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement rootElement = xmlDoc.DocumentElement;
            xmlDoc.InsertBefore(xmlDeclaration, rootElement);
            XmlElement logsElement = xmlDoc.CreateElement("logs");
            xmlDoc.AppendChild(logsElement);
            xmlDoc.Save(_pathLogFile);
            //File.WriteAllText(_pathLogFile, "");
        }
        private void createFileJson(string _pathLogFile)
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
                this.createFileJson(_pathJson);
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
                string _pathXml = AppDomain.CurrentDomain.BaseDirectory + @"\Log\DailyLog\" + _today;
                this.createFileXml(_pathXml);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_pathXml);

                // Créer un nouvel élément log
                XmlElement logElement = xmlDoc.CreateElement("log");

                // Ajouter les éléments pour les nouvelles données
                XmlElement nameElement = xmlDoc.CreateElement("Name");
                nameElement.InnerText = this.name;
                logElement.AppendChild(nameElement);

                XmlElement fileSourceElement = xmlDoc.CreateElement("FileSource");
                fileSourceElement.InnerText = this.fileSource;
                logElement.AppendChild(fileSourceElement);

                XmlElement fileTargetElement = xmlDoc.CreateElement("FileTarget");
                fileTargetElement.InnerText = this.fileTarget;
                logElement.AppendChild(fileTargetElement);

                XmlElement fileSizeElement = xmlDoc.CreateElement("FileSize");
                fileSizeElement.InnerText = this.size;
                logElement.AppendChild(fileSizeElement);

                XmlElement fileTransferTimeElement = xmlDoc.CreateElement("FileTransferTime");
                fileTransferTimeElement.InnerText = _fileTransferTime;
                logElement.AppendChild(fileTransferTimeElement);

                XmlElement timeElement = xmlDoc.CreateElement("Time");
                timeElement.InnerText = DateTime.Now.ToString("dd/MM/yyyy H:m:ss");
                logElement.AppendChild(timeElement);

                // Ajouter le nouvel élément log au document XML
                XmlNode logsNode = xmlDoc.SelectSingleNode("/logs");
                logsNode.AppendChild(logElement);

                // Enregistrer le document XML mis à jour
                xmlDoc.Save(_pathXml);

            }
        }
    }
}