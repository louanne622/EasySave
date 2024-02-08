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
            string SourceFilePath = "FilePath1";
            string DestinationFilePath = "FilePath2";
            string SourceFileName = " ";
            string DestinationFileName = "FileName2";
            double Time = 12.3 ; //ms 
            int taille = 949;
            string NewFilePath = "";
            Console.WriteLine("Spécifiez le chemin du fichier svp.");
            NewFilePath = Console.ReadLine();
            SearchFilePath s = new SearchFilePath();
            s.searchFiler(NewFilePath);
            if (x == true)
            {
                Writelog("Fichier " + NewFilePath  + " dispo sur " + SourceFilePath + " enrisgistré avec succée sous le nom " + DestinationFileName + "sur"+DestinationFilePath+ ",  il fait " + taille + " Ko, le transfert a mis " +Time+"ms");
                Console.WriteLine("Commande réalisé");
            }
            else
            {
                Writelog("Erreur, fichier"+ SourceFileName +" non trouvé ");
                Console.WriteLine("Commande avorté");
            }

            static void Writelog(string message)
            {
                string logpath = ConfigurationManager.AppSettings["logPath"];
                using (StreamWriter writer = new StreamWriter(logpath, true))
                {
                    writer.WriteLine($"{DateTime.Now} : {message} ");
                }
            }
        }
    }
    
    
        
    
}
