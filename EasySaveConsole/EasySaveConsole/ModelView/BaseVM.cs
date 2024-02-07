using System;
using System.Collections.Generic;
using EasySaveConsole.Model;

namespace EasySaveConsole.ModelView
{
    class BaseVM
    {
        public VMWorkshop objWorkshop;
        private TransferFile objTransfer;
        public Save[] objsSave;
        public BaseVM()
        {
            this.objWorkshop = new VMWorkshop();
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
        public void getIntro()
        {
            this.objWorkshop.getInto();
        }
        public void getInterface_HomeMenu()
        {
            this.objWorkshop.getInterface_HomeMenu();
        }
        public void setLang(bool input)
        {
            this.objWorkshop.setLang(input);
        }
        public bool getLang()
        {
            return this.objWorkshop.getLang();
        }
        public void getInfoLang()
        {
            this.objWorkshop.getInfoLang();
        }
    }
}
