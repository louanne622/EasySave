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
        public bool cpfile(string src, string dest)
        {
           
            
            try
            {   
                File.Copy(src, dest, true);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
                string erreur = iox.Message;
            }
            if (File.Exists(dest))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
