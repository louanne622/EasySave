﻿using System;
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
                    break;
                case "3": // Exec SaveTransfer
                    break;
                case "4": // Update SaveTRansfer
                    break;
                case "5": // Delete SaveTransfer
                    break;
                default:
                    Console.WriteLine("Chiffre invalide...");
                    break;
            }














            //ViewInterfaceConsole b = new ViewInterfaceConsole();
            //b.getIntro();
            //TransferFile a = new TransferFile();
            //a.setOriginPath("C:\\Users\\valen\\OneDrive\\Bureau\\testMove\\Or");
            //a.setTargetPath("C:\\Users\\valen\\OneDrive\\Bureau\\testMove\\Target");
            //a.setTypeTransfer("D");
            //a.Transfer();


            //string PathOr, PathTarg, TypeTr;
            ////Console.WriteLine("Quel est le fichier/document d'origin ?"); 
            //PathOr = "C:\\Users\\valen\\OneDrive\\Bureau\\testMove\\Or";//Console.ReadLine();
            ////Console.WriteLine("Quel est le fichier/document cible ?"); 
            //PathTarg = "C:\\Users\\valen\\OneDrive\\Bureau\\testMove\\Target";//Console.ReadLine();
            //Console.WriteLine("Quel type de transfert ? C/D");
            //TypeTr = Console.ReadLine();

        }
    }
}
