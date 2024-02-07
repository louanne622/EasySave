using System;
using System.Collections.Generic;
using System.Text;
using EasySaveConsole.View;

namespace EasySaveConsole.ModelView
{
    class VMWorkshop
    {
        private ViewInterfaceConsole objUIConsole;
        public VMWorkshop()
        {
            this.objUIConsole = new ViewInterfaceConsole();
        }
        public void getInto()
        {
            this.objUIConsole.getIntro();
        }
        public void getInterface_HomeMenu()
        {
            this.objUIConsole.interface_HomeMenu();
        }
        public void setLang(bool input)
        {
            this.objUIConsole.setLang(input);
        }
        public bool getLang() 
        { 
            return this.objUIConsole.getLang(); 
        }
        public void getInfoLang()
        {
            this.objUIConsole.getInfoLang();
        }

    }
}
