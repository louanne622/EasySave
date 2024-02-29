using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.Json;
using EasySaveV3._0.Resources;

namespace EasySaveV3._0.Models
{
    class DailyLog
    {
        /*
         * 0  : pas de chiffrement
         * >0 : temps de chiffrement (en ms)
         * <0 : code erreur
         */
        public string CryptoTime { get; set; }
        public string name { get; set; }
        public string fileSource { get; set; }
        public string fileTarget { get; set; }
        public string fileType { get; set; }
        public string size { get; set; }
        public string fileTransferTime { get; set; }
        private void setDayliLogData(Save[] _saves, string _fileTransferTime, string _CryptoTime)
        {
            long tot = 0;
            foreach (Save save in _saves)
            {
                this.name += save.Name;
                this.fileSource += save.FilesSource;
                this.fileTarget += save.FilesTarget;
                this.fileType += save.FilesType;
                tot += this.GetSizeFiles(this.GetFilesToCopy(save));
            }
            this.size = tot.ToString();
            this.fileTransferTime = _fileTransferTime;
            this.CryptoTime = _CryptoTime;
        }
        private string[] GetFilesToCopy(Save _save)
        {
            return Directory.GetFiles(_save.FilesSource);
        }
        public long GetSizeFiles(string[] paths)
        {
            int totBytes = 0;
            foreach (string _path in paths)
            {
                totBytes += File.ReadAllBytes(_path).Length;
            }
            return totBytes / 1024;
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
        }
        private void createFileJson(string _pathLogFile)
        {
            if (File.Exists(_pathLogFile)) return;
            File.WriteAllText(_pathLogFile, "[]");
        }
        public void SetDailyLogDataInJson(Save[] _saves, string _fileTransferTime, string _CryptoTime)
        {
            setDayliLogData(_saves, _fileTransferTime, _CryptoTime);
            string _extension = UserProperties.Default.LogExtension;
            if (_extension == ".Json")
            {
                string _pathJson;
                string _today = DateTime.Now.ToString("dd_MM_yyyy") + ".json";
                if (UserProperties.Default.LogFilePath != "" && Directory.Exists(UserProperties.Default.LogFilePath))
                {
                    _pathJson = UserProperties.Default.LogFilePath + _today;
                }
                else
                {
                    _pathJson = AppDomain.CurrentDomain.BaseDirectory + @"\Log\DailyLog\" + _today;
                }

                this.createFileJson(_pathJson);
                string jsonContent = File.ReadAllText(_pathJson);
                List<dynamic> jsonArray = JsonSerializer.Deserialize<List<dynamic>>(jsonContent);
                dynamic NewObj = new
                {
                    Name = this.name,
                    FileSource = this.fileSource,
                    FileTarget = this.fileTarget,
                    Filetype = this.fileType,
                    FileSize = this.size,
                    FileTransferTim = _fileTransferTime,
                    Time = DateTime.Now.ToString("dd/MM/yyyy H:m:ss"),
                    CryptoTime = _CryptoTime
                };
                jsonArray.Add(NewObj);
                string updatedJson = JsonSerializer.Serialize(jsonArray, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_pathJson, updatedJson);
            }
            else if (_extension == ".Xml")
            {
                string _today = DateTime.Now.ToString("dd_MM_yyyy") + ".xml";
                string _pathXml;
                if (UserProperties.Default.LogFilePath != "" && Directory.Exists(UserProperties.Default.LogFilePath))
                {
                    _pathXml = UserProperties.Default.LogFilePath + _today;
                }
                else
                {
                    _pathXml = AppDomain.CurrentDomain.BaseDirectory + @"\Log\DailyLog\" + _today;
                }
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

                XmlElement fileTypeElement = xmlDoc.CreateElement("FileType");
                fileTypeElement.InnerText = this.fileType;
                logElement.AppendChild(fileTypeElement);

                XmlElement fileSizeElement = xmlDoc.CreateElement("FileSize");
                fileSizeElement.InnerText = this.size;
                logElement.AppendChild(fileSizeElement);



                XmlElement fileTransferTimeElement = xmlDoc.CreateElement("FileTransferTime");
                fileTransferTimeElement.InnerText = _fileTransferTime;
                logElement.AppendChild(fileTransferTimeElement);

                XmlElement timeElement = xmlDoc.CreateElement("Time");
                timeElement.InnerText = DateTime.Now.ToString("dd/MM/yyyy H:m:ss");
                logElement.AppendChild(timeElement);

                XmlElement cryptoElement = xmlDoc.CreateElement("CryptoTime");
                timeElement.InnerText = _CryptoTime;
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