using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace EasySaveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string PathOr, PathTarg, TypeTr;
            //Console.WriteLine("Quel est le fichier/document d'origin ?"); 
            PathOr = "C:\\Users\\valen\\OneDrive\\Bureau\\testMove\\Or";//Console.ReadLine();
            //Console.WriteLine("Quel est le fichier/document cible ?"); 
            PathTarg = "C:\\Users\\valen\\OneDrive\\Bureau\\testMove\\Target";//Console.ReadLine();
            Console.WriteLine("Quel type de transfert ? C/D");
            TypeTr = Console.ReadLine();

            // On vérifie si le fichier source existe
            // On va ensuite transférer chaque fichier 1 à 1
            if (Directory.Exists(PathOr) && Directory.Exists(PathTarg)) 
            {
                // Liste de string avec tous les noms de fichiers du dossier d'origine
                string[] filesOrigin = Directory.GetFiles(PathOr, "*", SearchOption.AllDirectories);

                // On va venir copier coller les fichiers
                if (TypeTr == "D")
                {
                    // Listes de string avec tous les noms de fichiers du dossier ciblé
                    string[] filesTarget = Directory.GetFiles(PathTarg, "*", SearchOption.AllDirectories);
                    string[] filesTargetWithoutPath = (string[])filesTarget.Clone();
                    for (int i = 0; i < filesTarget.Length; i++)
                    {
                        filesTargetWithoutPath[i] = filesTargetWithoutPath[i].Replace(PathTarg + "\\", "");
                    }
                    string[] filesOriginWithoutPath = (string[])filesOrigin.Clone();
                    for (int i = 0; i < filesOrigin.Length; i++)
                    {
                        filesOriginWithoutPath[i] = filesOriginWithoutPath[i].Replace(PathOr + "\\", "");
                    }
                    List<string> finalList = new List<string>();
                    for (int i = 0; i < filesTargetWithoutPath.Length; i++)
                    {
                        for (int j = 0; j < filesOriginWithoutPath.Length; j++)
                        {
                            if((filesTargetWithoutPath[i] == filesOriginWithoutPath[j]))
                            {
                                finalList.Add(filesOrigin[j]);
                            }
                        }
                    }
                    string[] finalArray = finalList.ToArray();
                    filesOrigin = filesOrigin.Except(finalArray).ToArray();
                    foreach (string file in filesOrigin)
                    {
                        string relativePath = file.Substring(PathOr.Length + 1);
                        string destinationFilePath = Path.Combine(PathTarg, relativePath);
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationFilePath));
                        File.Copy(file, destinationFilePath);
                    }


                }
                else if (TypeTr == "C")
                {
                    foreach (string file in filesOrigin)
                    {
                        string relativePath = file.Substring(PathOr.Length + 1);
                        string destinationFilePath = Path.Combine(PathTarg, relativePath);
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationFilePath));
                        File.Copy(file, destinationFilePath);
                    }
                }  
            } 
            else 
            { 
                Console.WriteLine("Attention, le fichier d'origine et/ou cible sont introuvable."); 
            }
        }
    }
}
