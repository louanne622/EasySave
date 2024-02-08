using System;
using System.Collections.Generic;
using System.Text;
using EasySaveConsole.Model;

namespace EasySaveConsole.View
{
    class ViewInterfaceConsole
    {
        //Creation of all the attributes
        private string[] ListeEN =
        {

        };
        private string[] ListeFR =
        {

        };
        private HardDisk disks = new HardDisk();
        //Using of a number to distinhuish between the different languages of the application
        // French & English for the first version
        private string language = "1";

        //initialisation of our methods enabling attributes to be used

        ////////////////////////AJOUTER LE CONSTRUCTEUR PAR DEFAUT///////////////////////////////////
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
