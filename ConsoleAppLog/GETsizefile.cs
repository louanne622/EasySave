using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Files;



namespace GETsizefile
{
    class Getsizefile
    {
        public static void getsizefile()
        {
            Console.WriteLine("Fichier:");
            string src = @"C:\Temp\file1.txt";
            src = Console.ReadLine();
            try
            { 

                var f = new FileInfo(src);
                Console.WriteLine("The size of {0} is {1} ko.", f.Name, f.Length/1000);



            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
                string erreur = iox.Message;
            }
        }
    }
}
