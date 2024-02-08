using System;
using System.Collections.Generic;
using System.Text;
using EasySaveConsole.Model;

namespace EasySaveConsole.View
{
    class ViewInterfaceConsole
    {
        private string[] ListeEN =
        {

        };
        private string[] ListeFR =
        {

        };
        private HardDisk disks = new HardDisk();
        // If true : Fr, else En
        private string language = "1";

        public void setLang(string input)
        {
            this.language = input;
        }
        public string getLang()
        {
            return this.language;
        }
        public void getDataString(string data) 
        {
            
        }
    }
}
