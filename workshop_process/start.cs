using System;
using System.Diagnostics;
using System.IO;

namespace process
{
    class Startq1
    {
        public static void start()
        {
            try
            {
                // Création d'un nouveau processus
                Process process = new Process();

                // Spécification du nom du fichier exécutable (dans ce cas, explorer.exe)
                process.StartInfo.FileName = "explorer.exe";

                // Démarrage du processus
                process.Start();
                Console.WriteLine($"Processus {process.StartInfo.FileName} : {process.Id} lancé ");

                // Attente que le processus se termine
                process.WaitForExit();
                Console.WriteLine($"Processus {process.StartInfo.FileName} : {process.Id} terminé ");
                // Fermeture du processus
                process.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }
            try
            {
                // Création d'un nouveau processus
                Process process = new Process();
                // Spécification du nom du fichier exécutable (dans ce cas, explorer.exe)
                process.StartInfo.FileName = "notepad.exe";
                // Démarrage du processus
                process.Start();
                Console.WriteLine($"Processus {process.StartInfo.FileName} : {process.Id} lancé ");
                // Attente que le processus se termine
                process.WaitForExit();
                Console.WriteLine($"Processus {process.StartInfo.FileName} : {process.Id} terminé ");
                // Fermeture du processus
                process.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }

        }
    }
    class startq4
    {
           public static void start()
            {
                try
                {
                    // Création d'un nouveau processus pour explorer.exe
                    Process process = new Process();

                    // Configuration des paramètres pour explorer.exe
                    process.StartInfo.FileName = "explorer.exe";

                    // Spécification de l'argument pour ouvrir le répertoire C:\
                    process.StartInfo.Arguments = "/select, C:\\Log";

                    // Démarrage du processus
                    process.Start();

                    // Attente que le processus se termine
                    process.WaitForExit();

                    // Fermeture du processus
                    process.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Une erreur s'est produite : " + ex.Message);
                }
            }
  
    }
  class Start41
{
    public static void StartNotepad(string filePath)
    {
        try
        {
            // Création d'un nouveau processus pour notepad.exe
            Process process = new Process();

            // Configuration des paramètres pour notepad.exe
            process.StartInfo.FileName = "explorer.exe";

            // Spécification de l'argument pour ouvrir le fichier texte spécifié
            process.StartInfo.Arguments = filePath;

            // Démarrage du processus
            process.Start();

            // Attente que le processus se termine
            process.WaitForExit();

            // Fermeture du processus
            process.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Une erreur s'est produite : " + ex.Message);
        }
    }
       
    }
    public class Q5
    {
        public static void startq5()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "C://windows";
            info.Verb = "explore";
            info.UseShellExecute = true;
            Process.Start(info);

            info = new ProcessStartInfo();
            info.FileName = "win.ini";
            info.WorkingDirectory = "C:\\windows";
            info.Verb = "edit"; // print /open
            info.UseShellExecute = true;
            Process.Start(info);
        }
    }
    public class Qx
    {
        public static void testchiffrementin()
        {
            //File.Copy(filepath, @"C:\Log\FIchier_chiffré.txt");
            
            try
            {
                File.Encrypt(@"C:\Log\log.txt");
                // Création d'un nouveau processus pour notepad.exe
                Process process = new Process();

                // Configuration des paramètres pour notepad.exe
                process.StartInfo.FileName = "notepad.exe";

                // Spécification de l'argument pour ouvrir le fichier texte spécifié
                process.StartInfo.Arguments = @"C:\Log\log.txt";

                // Démarrage du processus
                process.Start();

                // Attente que le processus se termine
                process.WaitForExit();

                // Fermeture du processus
                process.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }


        }
        public static void testchiffrementout(string filepathout)
        {
            File.Decrypt(@"C:\Log\FIchier_chiffré.txt");
            try
            {
                // Création d'un nouveau processus pour notepad.exe
                Process process = new Process();

                // Configuration des paramètres pour notepad.exe
                process.StartInfo.FileName = "notepad.exe";

                // Spécification de l'argument pour ouvrir le fichier texte spécifié
                process.StartInfo.Arguments = @"C:\Log\log.txt";

                // Démarrage du processus
                process.Start();

                // Attente que le processus se termine
                process.WaitForExit();

                // Fermeture du processus
                process.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }

        }
    }

}

