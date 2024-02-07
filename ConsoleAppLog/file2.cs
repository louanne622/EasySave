using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Files;
namespace CPfile
{
    public class Cpfile
    {
        public static void cpfile()
        {
            Console.WriteLine("Fichier a coller:");
            string src = @"C:\Temp\file1.txt";
            src = Console.ReadLine();
            Console.WriteLine("où voulez vous le coller?");
            string dest = @"C:\Temp\file2.txt";
            dest = Console.ReadLine();
            try
            {
                File.Copy(src, dest, true);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
                string erreur = iox.Message;
            }
        }
    }
}
