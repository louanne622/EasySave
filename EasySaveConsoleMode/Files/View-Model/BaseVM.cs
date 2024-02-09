using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using EasySaveConsole.Model;

namespace EasySaveConsole.ModelView
{
    class BaseVM
    {
        //Creation of all the attributes 
        public VMWorkspace objWorkshop;
        public TransferFile objTransfer;
        public Save[] objsSave;
        public DailyLog objDaily;
        public StateSave[] objsState;

        //initialisation of our methods enabling attributes to be used
        public BaseVM()
        {
            this.objWorkshop = new VMWorkspace();
            this.objTransfer = new TransferFile();
            this.objsSave = this.objWorkshop.getAllSaveFromJSON();
            this.objDaily = new DailyLog();
            this.objsState = this.objWorkshop.getAllStateSaveFromJSON();
        }
        public void setDailyLogAndWrite(Save _save, string _size, string FileTransferTim)
        {
            this.objDaily.size = _size;
            this.objDaily.time = FileTransferTim;
            this.objDaily.setSaveDailyLog(_save);
            this.objDaily.WriteLogFile();
        }
        public void Transfer(string originInput, string targetInput, string typeInput, int _id)
        {
            //Setting the data to our variables
            objTransfer.setAllData(originInput, targetInput, typeInput);
            if (!objTransfer.VerifConditionForTransfer()) return;

            //Setting the source path of the files
            this.objTransfer.setFilesOrigin(originInput);
            this.objTransfer._ID = _id;
            this.objTransfer._state = this.objsState;
            this.objTransfer._name = this.objsSave[_id].Name;

            string res = this.objWorkshop.getAllSizeFiles(this.objTransfer.filesOrigin);
            string[] parts = res.Split(',');
            string integerPart = parts[0];
            if (int.TryParse(integerPart, out int result)) this.objTransfer.TotalFilesSize = result;
            else this.objTransfer.TotalFilesSize = 0;
            if (typeInput == "C") this.objTransfer.TransferFilesComplet();
            else if (typeInput == "D")
            {
                objTransfer.setFilesTarget(targetInput); objTransfer.TransferFilesDiff();
            }
        }
        public void setLang(string input)
        {
            this.objWorkshop.setLang(input);
        }
        public string getLang()
        {
            return this.objWorkshop.getLang();
        }
        public void UpdateDataJson(int _id, string _name, string _fileSource, string _fileTarget, string _type)
        {
            this.objWorkshop.UpdateJsonData(this.objsSave[_id], _name, _fileSource, _fileTarget, _type);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\Saves.json", JsonSerializer.Serialize(this.objsSave, new JsonSerializerOptions { WriteIndented = true }));
        }
        public void DeleteDataJson(int _id)
        {
            this.objWorkshop.DeleteJsonData(this.objsSave[_id]);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\Saves.json", JsonSerializer.Serialize(this.objsSave));
        }
        public void ConsoleWriteDataString(string input)
        {
            this.objWorkshop.ConsoleWriteDataString(input);
        }
    }
}
