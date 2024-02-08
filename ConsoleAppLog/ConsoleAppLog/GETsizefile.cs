using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Files;



namespace GETsizefile
{
    public class Getsizefile
    {
        public double getsizefile(string src)
        {
            Console.WriteLine("Fichier:");
            var f = new FileInfo(src);
            try
            { 

                
                Console.WriteLine("The size of {0} is {1} ko.", f.Name, f.Length/1000);



            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
                string erreur = iox.Message;
            }
            return f.Length/1000;
            
        }
        
    }
}
