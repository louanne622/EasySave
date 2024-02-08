using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Files;

namespace Folder
{
    public  void Cpfolder(string src, string dest)
    {
        // Vérifier si le dossier source existe
        if (!Directory.Exists(src))
        {
            throw new DirectoryNotFoundException(
                "Le dossier source n'existe pas : " + src);
        }

        // Créer le dossier de destination s'il n'existe pas
        if (!Directory.Exists(dest))
        {
            Directory.CreateDirectory(dest);
        }

        // Obtenir la liste des fichiers dans le dossier source
        string[] fichiers = Directory.GetFiles(src);

        // Copier chaque fichier dans le dossier de destination
        foreach (string fichier in fichiers)
        {
            string nomFichier = Path.GetFileName(fichier);
            string cheminDestination = Path.Combine(dest, nomFichier);
            File.Copy(fichier, cheminDestination, true);
        }

        // Obtenir la liste des sous-dossiers dans le dossier source
        string[] sousDossiers = Directory.GetDirectories(src);

        // Récursivement copier chaque sous-dossier
        foreach (string sousDossier in sousDossiers)
        {
            string nomSousDossier = Path.GetFileName(sousDossier);
            string nouveauCheminDestination = Path.Combine(dest, nomSousDossier);
            Cpfolder(sousDossier, nouveauCheminDestination);
        }
    }
}