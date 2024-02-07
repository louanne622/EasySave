using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using EasySaveConsole.Model;
using EasySaveConsole.View;

namespace EasySaveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewInterfaceConsole b = new ViewInterfaceConsole();
            b.getIntro();
            TransferFile a = new TransferFile();
            a.setOriginPath("C:\\Users\\valen\\OneDrive\\Bureau\\testMove\\Or");
            a.setTargetPath("C:\\Users\\valen\\OneDrive\\Bureau\\testMove\\Target");
            a.setTypeTransfer("D");
            a.Transfer();


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
