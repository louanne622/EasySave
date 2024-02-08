using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasySaveConsole.Model;

namespace EasySaveConsole.View
{
    class ViewInterfaceConsole
    {
        //Creation of all the attributes
        private string[] ListeEN =
        {

        };
        private string[] ListeFR =
        {

        };
        private HardDisk disks = new HardDisk();
        //Using of a number to distinhuish between the different languages of the application
        // French & English for the first version
        private string language = "1";

        //initialisation of our methods enabling attributes to be used

        ////////////////////////AJOUTER LE CONSTRUCTEUR PAR DEFAUT///////////////////////////////////
        public void setLang(string input)
        {
            this.language = input;
        }
        public string getLang()
        {
            return this.language;
        }
        private string[] getListLang(string lang)
        {
            string[] _return;
            switch (lang)
            {
                case "1":
                    _return = this.ListeFR;
                    break;
                case "2":
                    _return = this.ListeEN;
                    break;
                default:
                    _return = null;
                    break;
            }

            return _return;
        }
        public void getDataString(string data) 
        {
            int[] numList = ParseBackupNumbers(data).ToArray();
            string[] dataLang = this.getListLang(getLang());
            for (int i = 0; i < numList.Length; i++) Console.WriteLine(dataLang[numList[i]]);
        }

        private List<int> ParseBackupNumbers(string input)
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
    }
}
