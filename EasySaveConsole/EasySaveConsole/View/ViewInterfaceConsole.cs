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
        private bool language = true;
        public void setLang(bool input)
        {
            this.language = input;
        }
        public bool getLang()
        {
            return this.language;
        }
        public void getIntro()
        {
            Console.WriteLine("#============================================#");
            Console.WriteLine("#                                            #");
            Console.WriteLine("#                  EASY SAVE                 #");
            Console.WriteLine("#                                            #");
            Console.WriteLine("#============================================#");
            Console.WriteLine(this.language ? "Bienvenue sur notre application console." : "Welcome to our console application.");
            Console.WriteLine(this.language ? "Voici les disque(s) disponible(s) :" : "Here are the available disks:");
            for (int i = 0; i < this.disks.getListHardDisk().Length; i++)
            { Console.WriteLine(this.disks.getListHardDisk()[i]); Console.WriteLine(); }
        }
        public void interface_HomeMenu()
        {
            Console.WriteLine("Que souhaitez-vous faire ? (entrez un nomrbe entre 1 et 5)");
            Console.WriteLine(" 1. Modifer la langue");
            Console.WriteLine(" 2. Voir les travaux enregistrer");
            Console.WriteLine(" 3. Exécuter des travaux");
            Console.WriteLine(" 4. Modifer des travaux");
            Console.WriteLine(" 5. Supprimer des travaux");
            Console.WriteLine("");
        }
        public void getInfoLang()
        {
            Console.WriteLine();
            Console.WriteLine("La langue actuelle est le " + (this.language ? "Français" : "Anglais") + ".");
            Console.WriteLine("Souhaitez-vous la changer en " + (!this.language ? "Français" : "Anglais") + " ? (Y/N)");
        }
    }
}
