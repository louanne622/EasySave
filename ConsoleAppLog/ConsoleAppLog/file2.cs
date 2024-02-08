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
            if (Directory.Exists(dest))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

class Foldersize
    {
        static void foldersize(string src)
        {
            // Chemin du dossier à vérifier
            ;

            // Vérifier si le dossier existe
            if (Directory.Exists(src))
            {
                // Calculer la taille du dossier en kilooctets
                long taille = TailleDossier(src) / 1024;

                Console.WriteLine($"La taille du dossier est de {taille} Ko.");
            }
            else
            {
                Console.WriteLine("Le dossier spécifié n'existe pas.");
            }
        }

        static long TailleDossier(string src)
        {
            // Initialiser la taille du dossier
            long taille = 0;

            // Obtenir la liste des fichiers dans le dossier
            string[] fichiers = Directory.GetFiles(src);

            // Ajouter la taille de chaque fichier au total
            foreach (string fichier in fichiers)
            {
                FileInfo infoFichier = new FileInfo(fichier);
                taille += infoFichier.Length;
            }

            // Obtenir la liste des sous-dossiers
            string[] sousDossiers = Directory.GetDirectories(src);

            // Récursivement calculer la taille de chaque sous-dossier
            foreach (string sousDossier in sousDossiers)
            {
                taille += TailleDossier(sousDossier);
            }

            return taille;
        }
    }
}

