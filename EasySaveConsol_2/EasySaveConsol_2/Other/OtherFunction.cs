/*
 * 
 * This CLASS is a utility class, that means every method here can be called
 * everywhere in this project application
 * 
 */

using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EasySaveConsol_2
{
    public static class ClassUtility
    {
        /*
         * 
         * This method return a list of <int> that will be in the input method 
         * with this syntax: "3; 5; 3; 9; 3" will return [3, 5, 3, 9, 3]
         * or =>             "1-5"                       [1, 2, 3, 4, 5]
         * 
         */
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
    
        /*
         * Methods to get and set the value of a data in the config file
         */
        public static string GetConfigData(string configVariable)
        {
            string pathFileConfig = AppDomain.CurrentDomain.BaseDirectory + @"\Config\config.txt";
            if (!File.Exists(pathFileConfig)) return "1";

            string[] lines = File.ReadAllLines(pathFileConfig);
            Regex regex = new Regex(@$"{configVariable}\s*=\s*(\d+);");
            foreach (string line in lines)
            {
                Match match = regex.Match(line);
                if (match.Success) return match.Groups[1].Value;
            }
            return "1";
        }
        public static void SetConfigData(string configVariable, string newData)
        {
            string pathFileConfig = AppDomain.CurrentDomain.BaseDirectory + @"\Config\config.txt";
            if (!File.Exists(pathFileConfig)) return;

            string[] lines = File.ReadAllLines(pathFileConfig);
            Regex regex = new Regex(@$"{configVariable}\s*=\s*\d+;$");
            for (int i = 0; i < lines.Length; i++)
                if (regex.IsMatch(lines[i]))lines[i] = "language = " + newData + ";";
            File.WriteAllLines(pathFileConfig, lines);
        }
    }
}