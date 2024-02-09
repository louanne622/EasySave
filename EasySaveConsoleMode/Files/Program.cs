using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

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
            while (true)
            {
                Console.Clear();
                a.ConsoleWriteDataString("0; 1; 2; 1; 0; 3; 4; 5; 6; 7; 8; 9; 3");
                string choiceInterface_HomePage = Console.ReadLine();
                string dataUI;
                switch (choiceInterface_HomePage)
                {
                    case "5": // Switch Language
                        a.ConsoleWriteDataString("3; 14; 19; 3");
                        dataUI = Console.ReadLine();
                        if (dataUI == "Y")
                        {
                            a.ConsoleWriteDataString("3; 20; 21; 3");
                            dataUI = Console.ReadLine();
                            if (int.Parse(dataUI) < 1 || int.Parse(dataUI) > 2) a.ConsoleWriteDataString("22");
                            else
                            {
                                a.objWorkshop.setLang(dataUI);
                                a.ConsoleWriteDataString("1; 18; 3");
                            }
                        }
                        break;
                    case "1": // Show SaveTransfer
                        a.ConsoleWriteDataString("3; 10");
                        foreach (var save in a.objsSave)
                        {
                            a.ConsoleWriteDataString("3");
                            Console.WriteLine("Id: " + save.Id);
                            Console.WriteLine("Name: " + save.Name);
                            Console.WriteLine("FileSource: " + save.FilesSource);
                            Console.WriteLine("FileTarget: " + save.FilesTarget);
                            Console.WriteLine("Type: " + save.Type);
                            Console.ReadLine();
                        }
                        break;
                    case "3": // Exec SaveTransfer
                        a.ConsoleWriteDataString("3; 12; 30; 31; 3");
                        string Rep7 = Console.ReadLine();
                        int[] numList = ParseBackupNumbers(Rep7).ToArray();
                        for (int i = 0; i < numList.Length; i++)
                        {
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            a.Transfer(a.objsSave[numList[i] - 1].FilesSource,
                                                                            a.objsSave[numList[i] - 1].FilesTarget,
                                                                            a.objsSave[numList[i] - 1].Type);
                            stopwatch.Stop();
                            a.ConsoleWriteDataString("1; 17; 3");
                            TimeSpan elapsedTime = stopwatch.Elapsed;
                            string formattedTime = $"{(int)elapsedTime.TotalMinutes}min {elapsedTime.Seconds}sec";
                            if (a.objsSave[numList[i] - 1].Type == "C") a.setDailyLogAndWrite(a.objsSave[numList[i] - 1], a.objWorkshop.getSizeFile(a.objsSave[numList[i] - 1].FilesSource), formattedTime);
                            else if (a.objsSave[numList[i] - 1].Type == "D") a.setDailyLogAndWrite(a.objsSave[numList[i] - 1], a.objWorkshop.getAllSizeFiles(a.objTransfer.filesOrigin), formattedTime);
                        }
                        break;
                    case "2": // Update SaveTRansfer
                        a.ConsoleWriteDataString("3; 11; 23; 29; 3");
                        string Rep1 = Console.ReadLine();
                        if (int.Parse(Rep1) > 5 || int.Parse(Rep1) < 1)
                        {
                            a.ConsoleWriteDataString("22; 3"); Console.ReadLine();
                            break;
                        }
                        a.ConsoleWriteDataString("3; 24"); string Rep2 = Console.ReadLine();
                        a.ConsoleWriteDataString("3; 25"); string Rep3 = Console.ReadLine();
                        a.ConsoleWriteDataString("3; 26"); string Rep4 = Console.ReadLine();
                        a.ConsoleWriteDataString("3; 27"); ; string Rep5 = Console.ReadLine();
                        a.UpdateDataJson(int.Parse(Rep1) - 1, Rep2, Rep3, Rep4, Rep5);
                        a.ConsoleWriteDataString("1; 15; 3"); Console.ReadLine();
                        break;
                    case "4": // Delete SaveTransfer
                        a.ConsoleWriteDataString("3; 13; 28; 29; 3");
                        string Rep6 = Console.ReadLine();
                        if (int.Parse(Rep6) > 5 || int.Parse(Rep6) < 1)
                        {
                            a.ConsoleWriteDataString("22; 3"); Console.ReadLine();
                            break;
                        }
                        a.DeleteDataJson(int.Parse(Rep6) - 1);
                        a.ConsoleWriteDataString("1; 16; 3"); Console.ReadLine();
                        break;
                    default:
                        a.ConsoleWriteDataString("1; 22; 3"); Console.ReadLine();
                        break;
                }
            }
        }
    }
}
