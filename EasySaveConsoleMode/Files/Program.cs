using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using EasySaveConsole.Model;
using EasySaveConsole.View;
using EasySaveConsole.ModelView;

namespace EasySaveConsole
{
    class Program
    {
        public static List<int> ParseBackupNumbers(string input)
        {
            var backupNumbers = new List<int>();
            string[] parts = input.Split(';');
            foreach (string part in parts)
            {
                // Si la sous-chaîne contient un '-', cela signifie que c'est une plage de numéros
                if (part.Contains("-"))
                {
                    // Séparation de la sous-chaîne en début et fin de plage
                    string[] rangeParts = part.Split('-');

                    if (rangeParts.Length == 2 && int.TryParse(rangeParts[0], out int start) && int.TryParse(rangeParts[1], out int end))
                    {
                        // Ajout de tous les numéros dans la plage à la liste
                        backupNumbers.AddRange(Enumerable.Range(start, end - start + 1));
                    }
                    else
                    {
                        throw new ArgumentException("Syntaxe invalide pour la plage de sauvegardes.");
                    }
                }
                else
                {
                    // Si la sous-chaîne ne contient pas de '-', cela signifie qu'il s'agit d'un numéro unique
                    if (int.TryParse(part, out int number))
                    {
                        // Ajout du numéro unique à la liste
                        backupNumbers.Add(number);
                    }
                    else
                    {
                        throw new ArgumentException("Syntaxe invalide pour le numéro de sauvegarde.");
                    }
                }
            }
            return backupNumbers;
        }
        static void Main(string[] args)
        {
            BaseVM a = new BaseVM();
            a.getIntro(); a.getInterface_HomeMenu();
            string choiceInterface_HomePage = Console.ReadLine();
            string dataUI;
            switch (choiceInterface_HomePage)
            {
                case "1": // Switch Language
                    a.getInfoLang();
                    dataUI = Console.ReadLine(); Console.WriteLine();
                    if (dataUI == "Y") a.setLang(!a.getLang());
                    break;
                case "2": // Show SaveTransfer
                    foreach (var save in a.objsSave)
                    {
                        Console.WriteLine("Id: " + save.Id);
                        Console.WriteLine("Name: " + save.Name);
                        Console.WriteLine("FileSource: " + save.FilesSource);
                        Console.WriteLine("FileTarget: " + save.FilesTarget);
                        Console.WriteLine("Type: " + save.Type);
                        Console.WriteLine();
                    }
                    break;
                case "3": // Exec SaveTransfer
                    Console.WriteLine("Quelle sauvegarde sont à effectuer ? (ex synthaxe: 1-3 ou 1 ;3)");
                    string Rep7 = Console.ReadLine();
                    int[] numList = ParseBackupNumbers(Rep7).ToArray();
                    for (int i = 0; i < numList.Length; i++) a.Transfer(a.objsSave[numList[i] - 1].FilesSource,
                                                                        a.objsSave[numList[i] - 1].FilesTarget,
                                                                        a.objsSave[numList[i] - 1].Type);
                    break;
                case "4": // Update SaveTRansfer
                    Console.WriteLine("Quelle sauvegarde est à modifier ? (1 à 5)");
                    string Rep1 = Console.ReadLine();
                    while (int.Parse(Rep1) > 5 || int.Parse(Rep1) < 1)
                    {
                        Console.WriteLine("Quelle sauvegarde est à modifier ? (1 à 5)"); Rep1 = Console.ReadLine();
                    }
                    Console.WriteLine("Le nom ?"); string Rep2 = Console.ReadLine();
                    Console.WriteLine("Le fichier source ?"); string Rep3 = Console.ReadLine();
                    Console.WriteLine("Le fichier target ?"); string Rep4 = Console.ReadLine();
                    Console.WriteLine("Le type de sauvegarde ?"); string Rep5 = Console.ReadLine();
                    a.UpdateDataJson(int.Parse(Rep1) - 1, Rep2, Rep3, Rep4, Rep5);
                    break;
                case "5": // Delete SaveTransfer
                    Console.WriteLine("Quelle sauvegarde est à supprimer ? (1 à 5)");
                    string Rep6 = Console.ReadLine();
                    while (int.Parse(Rep6) > 5 || int.Parse(Rep6) < 1)
                    {
                        Console.WriteLine("Quelle sauvegarde est à modifier ? (1 à 5)"); Rep6 = Console.ReadLine();
                    }
                    a.DeleteDataJson(int.Parse(Rep6) - 1);
                    break;
                default:
                    Console.WriteLine("Chiffre invalide...");
                    break;
            }
        }
    }
}
