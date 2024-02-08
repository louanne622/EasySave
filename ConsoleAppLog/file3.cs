using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Files;

namespace RFile
{
    public class Rfile
    {
        public static void rffile()
        {
            Console.WriteLine("Fichier a lire");
            string src = @"C:\Temp\file1.txt";
            src = Console.ReadLine();
            
            try
            {
               string K= File.ReadAllText(src);
                Console.WriteLine(K);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
                string erreur = iox.Message;
            }
        }
    }
}
    