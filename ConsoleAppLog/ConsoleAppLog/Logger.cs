using System;
using Files;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPfile;
using System.Configuration;
using System.IO;
using GETsizefile;
using System.Diagnostics;
using RFile;


namespace Logger
{
    public class logger
    {

        public static void Log()
        {
            Console.WriteLine("Indiquer le chemin complet du Fichier à sauvegarder svp: ");
            string SourceFilePath = Console.ReadLine();
            Console.WriteLine("Où voulez vous le sauvegarder?");
            string DestinationFilePath = Console.ReadLine();
            Getsizefile taille = new Getsizefile();
            double size = taille.getsizefile(SourceFilePath);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Cpfile filecp = new Cpfile();
            stopwatch.Stop();

            bool x = filecp.cpfile(SourceFilePath, DestinationFilePath);

            //string NewFilePath = "";
            //Console.WriteLine("Spécifiez le chemin du fichier svp.");
            //NewFilePath = Console.ReadLine();
            //SearchFilePath s = new SearchFilePath();
            //s.searchFiler(NewFilePath);
            if (x == true)
            {
                double Time = stopwatch.Elapsed.TotalSeconds*1000;
                Writelog("Fichier " + SourceFilePath + " a été enrisgistré avec succée sur" + DestinationFilePath + ",  il fait " + size + " Ko, le transfert a mis " + Time + " ms");
                Console.WriteLine("Commande réalisé");
            }
            else
            {
                double Time = -1;
                Writelog("Erreur, lors du transfert du Fichier " + SourceFilePath + " a été enrisgistré avec succée sur" + DestinationFilePath + ", il fait " + size + " Ko, le transfert a mis " + Time + " ms");
                Console.WriteLine("Commande avorté");

            }
            Console.WriteLine("Souhaité accéder au log? Oui= 1 Non = 2");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    string date = $"{DateTime.Now.ToString("MM_dd_yyyy")}";
                    string dstlog = @"C:\Log\log_" + date + ".txt";
                    Rfile.rffile(dstlog);
                    break;
                case "2":
                    Console.WriteLine("Fin du programe");
                    break;


            }
        }

        static void Writelog(string message)
        {

            string date = $"{DateTime.Now.ToString("MM_dd_yyyy")}";
            string dstlog = @"C:\Log\log_" + date + ".txt";
            if (File.Exists(dstlog) == false)
            {
                using (StreamWriter sw = File.CreateText(dstlog))
                {
                    sw.WriteLine($"{DateTime.Now} : {message} ");
                }

            }
            else
            {
                using (StreamWriter writer = new StreamWriter(dstlog, true))
                {
                    writer.WriteLine($"{DateTime.Now} : {message} ");
                }
            }
        }
     }        
 }

