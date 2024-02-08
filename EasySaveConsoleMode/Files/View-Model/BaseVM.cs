using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using EasySaveConsole.Model;

namespace EasySaveConsole.ModelView
{
    class BaseVM
    {
        public VMWorkspace objWorkshop;
        private TransferFile objTransfer;
        public Save[] objsSave;
        public BaseVM()
        {
            this.objWorkshop = new VMWorkspace();
            this.objTransfer = new TransferFile();
            this.objsSave = objWorkshop.getAllSaveFromJSON();
        }
        public void Transfer(string originInput, string targetInput, string typeInput)
        {
            // On set les data avec nos apramètres
            objTransfer.setAllData(originInput, targetInput, typeInput);
            if (!objTransfer.VerifConditionForTransfer()) return;

            // On va chercher les fichiers d'origines
            objTransfer.setFilesOrigin(originInput);

            if (typeInput == "C") objTransfer.TransferFilesComplet();
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
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\Saves.json", JsonSerializer.Serialize(this.objsSave));
        }
        public void DeleteDataJson(int _id)
        {
            this.objWorkshop.DeleteJsonData(this.objsSave[_id]);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\Saves.json", JsonSerializer.Serialize(this.objsSave));
        }
    }
}
