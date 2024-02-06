using System;
using System.IO;

namespace EasySaveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string PathOr, PathTarg;
            Console.WriteLine("Quel est le fichier/document d'origin ?"); 
            PathOr = Console.ReadLine();
            Console.WriteLine("Quel est le fichier/document cible ?"); 
            PathTarg = Console.ReadLine();

            // On vérifie si le fichier source existe
           
            if (Directory.Exists(PathOr)) 
            {
                int i = 1;
                while (Directory.Exists(PathTarg+"\\Save"+i))
                {
                    i++;
                }
                PathTarg += "\\Save" + i;
                Directory.CreateDirectory(PathTarg);
                string[] files = Directory.GetFiles(PathOr, "*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    string relativePath = file.Substring(PathOr.Length + 1);
                    string destinationFilePath = Path.Combine(PathTarg, relativePath);
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationFilePath));
                    File.Copy(file, destinationFilePath);
                }

                //Directory.Move(PathOr, PathTarg + "\\Save" + i);
            } 
            else 
            { 
                Console.WriteLine("Attention, le fichier d'origine est introuvable."); 
            }
        }
    }
}
