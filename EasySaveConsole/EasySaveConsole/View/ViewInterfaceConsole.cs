using System;
using System.Collections.Generic;
using System.Text;
using EasySaveConsole.Model;

namespace EasySaveConsole.View
{
    class ViewInterfaceConsole
    {
        private HardDisk disks = new HardDisk();
        // If true : Fr, sinon En
        private bool language = true;
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
    }
}
