using System;
using System.Collections.Generic;
using System.Text;
using EasySaveConsole.Model;

namespace EasySaveConsole.ModelView
{
    class BaseVM
    {
        private VMWorkshop objWorkshop;
        private TransferFile objTransfer;
        public BaseVM()
        {
            this.objWorkshop = new VMWorkshop();
            this.objTransfer = new TransferFile();
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
