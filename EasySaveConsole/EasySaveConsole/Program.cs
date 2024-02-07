using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using EasySaveConsole.Model;
using EasySaveConsole.View;
using EasySaveConsole.ModelView;

namespace EasySaveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //BaseVM a = new BaseVM();
            //a.getIntro(); a.getInterface_HomeMenu();
            //string choiceInterface_HomePage = Console.ReadLine();
            //string dataUI;
            //switch (choiceInterface_HomePage)
            //{
            //    case "1": // Switch Language
            //        a.getInfoLang();
            //        dataUI = Console.ReadLine(); Console.WriteLine();
            //        if (dataUI == "Y") a.setLang(!a.getLang());
            //        break;
            //    case "2": // Show SaveTransfer
            //        break;
            //    case "3": // Exec SaveTransfer
            //        break;
            //    case "4": // Update SaveTRansfer
            //        break;
            //    case "5": // Delete SaveTransfer
            //        break;
            //    default:
            //        Console.WriteLine("Chiffre invalide...");
            //        break;
            //}

            BaseVM n = new BaseVM();
            Save[] b = n.objsSave;
            foreach (var save in b)
            {
                Console.WriteLine("Id: " + save.Id);
                Console.WriteLine("Name: " + save.Name);
                Console.WriteLine("FileSource: " + save.FilesSource);
                Console.WriteLine("FileTarget: " + save.FilesTarget);
                Console.WriteLine("Type: " + save.Type);
                Console.WriteLine();
            }





        }
    }
}
