using System;
using Files;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPfile;
using System.Configuration;
using System.IO;

namespace Logger
{
    public class logger
    {
       public  static void Log()
        {
            bool x = true;
            
            double Time = 12.3 ; //ms 
            int taille = 949;
            string NewFilePath = "";
            Console.WriteLine("Spécifiez le chemin du fichier svp.");
            NewFilePath = Console.ReadLine();
            SearchFilePath s = new SearchFilePath();
            s.searchFiler(NewFilePath);
            String SourceFilePath = "FilePath1";
            String DestinationFilePath = "FilePath2";
            String SourceFileName = " ";
            String DestinationFileName = "FileName2";



            if (x == true)
            {
                Logger2.Writelog("Fichier " + NewFilePath  + " dispo sur " + SourceFilePath + " enrisgistré avec succée sous le nom " + DestinationFileName + "sur"+DestinationFilePath+ ",  il fait " + taille + " Ko, le transfert a mis " +Time+"ms");
                Console.WriteLine("Commande réalisé");
            }
            else
            {
                Logger2.Writelog("Erreur, fichier"+ SourceFileName +" non trouvé ");
                Console.WriteLine("Commande avorté");
            }

        }
    }
    public static class Logger2
    {
        public static void Writelog(string message)
        {
            string logpath = ConfigurationManager.AppSettings["logPath"];
            using (StreamWriter writer = new StreamWriter(logpath, true))
            {
                writer.WriteLine($"{DateTime.Now} : {message} ");
            }
        }
    }
}
