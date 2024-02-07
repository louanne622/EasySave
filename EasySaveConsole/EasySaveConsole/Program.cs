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
            BaseVM a = new BaseVM();
            a.getIntro(); a.getInterface_HomeMenu();
            string choiceInterface_HomePage = Console.ReadLine();
            string dataUI;
            switch (choiceInterface_HomePage)
            {
                case "1": // Switch Language
                    a.getInfoLang();
                    dataUI = Console.ReadLine(); Console.WriteLine();
                    if (dataUI == "Y") a.setLang(!a.getLang());
                    break;
                case "2": // Show SaveTransfer
                    foreach (var save in a.objsSave)
                    {
                        Console.WriteLine("Id: " + save.Id);
                        Console.WriteLine("Name: " + save.Name);
                        Console.WriteLine("FileSource: " + save.FilesSource);
                        Console.WriteLine("FileTarget: " + save.FilesTarget);
                        Console.WriteLine("Type: " + save.Type);
                        Console.WriteLine();
                    }
                    break;
                case "3": // Exec SaveTransfer
                    break;
                case "4": // Update SaveTRansfer
                    Console.WriteLine("Quelle sauvegarde est à modifier ? (1 à 5)");
                    string Rep1 = Console.ReadLine();
                    while (int.Parse(Rep1) > 5 || int.Parse(Rep1) < 1)
                    {
                        Console.WriteLine("Quelle sauvegarde est à modifier ? (1 à 5)"); Rep1 = Console.ReadLine();
                    }
                    Console.WriteLine("Le nom ?"); string Rep2 = Console.ReadLine();
                    Console.WriteLine("Le fichier source ?"); string Rep3 = Console.ReadLine();
                    Console.WriteLine("Le fichier target ?"); string Rep4 = Console.ReadLine();
                    Console.WriteLine("Le type de sauvegarde ?"); string Rep5 = Console.ReadLine();
                    a.UpdateDataJson(int.Parse(Rep1) - 1, Rep2, Rep3, Rep4, Rep5);
                    break;
                case "5": // Delete SaveTransfer
                    Console.WriteLine("Quelle sauvegarde est à supprimer ? (1 à 5)");
                    string Rep6 = Console.ReadLine();
                    while (int.Parse(Rep6) > 5 || int.Parse(Rep6) < 1)
                    {
                        Console.WriteLine("Quelle sauvegarde est à modifier ? (1 à 5)"); Rep6 = Console.ReadLine();
                    }
                    a.DeleteDataJson(int.Parse(Rep6) - 1);
                    break;
                default:
                    Console.WriteLine("Chiffre invalide...");
                    break;
            }

            //BaseVM n = new BaseVM();





            //Console.WriteLine("Quelle sauvegarde est à modifier ? (1 à 5)");
            //string Rep1 = Console.ReadLine();
            //while (int.Parse(Rep1) > 5 || int.Parse(Rep1) < 1)
            //{
            //    Console.WriteLine("Quelle sauvegarde est à modifier ? (1 à 5)");
            //    Rep1 = Console.ReadLine();
            //}
            //Console.WriteLine("Le nom ?");
            //string Rep2 = Console.ReadLine();
            //Console.WriteLine("Le fichier source ?");
            //string Rep3 = Console.ReadLine();
            //Console.WriteLine("Le fichier target ?");
            //string Rep4 = Console.ReadLine();
            //Console.WriteLine("Le type de sauvegarde ?");
            //string Rep5 = Console.ReadLine();

            //n.UpdateDataJson(int.Parse(Rep1) - 1, Rep2, Rep3, Rep4, Rep5);





            //foreach (var save in b)
            //{
            //    Console.WriteLine("Id: " + save.Id);
            //    Console.WriteLine("Name: " + save.Name);
            //    Console.WriteLine("FileSource: " + save.FilesSource);
            //    Console.WriteLine("FileTarget: " + save.FilesTarget);
            //    Console.WriteLine("Type: " + save.Type);
            //    Console.WriteLine();
            //}





        }
    }
}
