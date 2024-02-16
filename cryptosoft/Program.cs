using System;
using System.IO;
using System.Diagnostics;
class Program
{
    static void Main(string inputFile, string outputFile)
    {
        string args = "255";
        byte key = Convert.ToByte(args); // La clé est un octet
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        try
        {
            // Lire le fichier d'entrée
            byte[] inputBytes = File.ReadAllBytes(inputFile);

            // Chiffrer les données avec XOR
            byte[] encryptedBytes = new byte[inputBytes.Length];
            for (int i = 0; i < inputBytes.Length; i++)
            {
                encryptedBytes[i] = (byte)(inputBytes[i] ^ key);
            }

            // Écrire les données chiffrées dans le fichier de sortie
            File.WriteAllBytes(outputFile, encryptedBytes);

            Console.WriteLine("Le fichier a été chiffré avec succès.");

            File.ReadLines(outputFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Une erreur s'est produite : " + ex.Message);
        }
        stopwatch.Stop(); 
        Console.Write(stopwatch); // affiche le temps mis pour effectuer l'action
    }
}
