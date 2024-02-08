using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Files
{
    public class SearchFilePath
    {
        public void searchFiler(string NewFilePath)
        {
            DirectoryInfo monrepertoire = new DirectoryInfo(NewFilePath);
            FileInfo[] mesfichiers = monrepertoire.GetFiles("*.txt");


            foreach (FileInfo files in mesfichiers)

            {
                Console.WriteLine("Trouvé");


            }

            string[] file2 = Directory.GetFiles(NewFilePath);
            foreach (string file1 in file2)
                Console.WriteLine(file1);
        }
    } 
}



