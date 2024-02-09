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
        private string[] ListeFR =
        {
            "#===========================================#", // 0
            "#                                           #",
            "#           APPLICATION EASY SAVE           #",
            "#-------------------------------------------#",
            "#--------------MENU PRINCIPAL---------------#",
            "# 1/ Voir les sauvegardes ------------------#", // 5
            "# 2/ Modifier une sauvegarde ---------------#",
            "# 3/ Exécuter une/plusieurs sauvegardes ----#",
            "# 4/ Supprimer une sauvegarde --------------#",
            "# 5/ Changer de langue ---------------------#",
            "#---------VISUALISATION SAUVEGARDE----------#", // 10
            "#----------MODIFICATION SAUVEGARDE----------#",
            "#-----------EXECUTION SAUVEGARDE------------#",
            "#----------SUPPRESSION SAUVEGARDE-----------#",
            "#-----------CHANGEMENT DE LANGUE------------#",
            "#------------------ Sauvegarde modifiée: ok #", // 15
            "#----------------- Sauvegarde supprimée: ok #",
            "#------------------ Sauvegarde éxécutée: ok #",
            "#---------------------- Langue modifiée: ok #",
            "#- Souhaitez-vous changer de langue ?(Y/N) -#",
            "# 1/ Français ------------------------------#", // 20
            "# 2/ Anglais -------------------------------#",
            "#----------------------- Mauvaise entrée... #",
            "# Quelle sauvegarde est à modifier ? -------#",
            "# Le nom ? -------------------------------- #",
            "# Le fichier source ? --------------------- #", // 25
            "# Le fichier de destination ? ------------- #",
            "# Le type de sauvegarde ? ----------------- #",
            "# Quelle est la sauvegarde à supprimer ? -- #",
            "# (1 à 5) ----------------------------------#",
            "# Quelle sauvegarde sont à effectuer ? -----#", // 30
            "# (ex synthaxe: 1-3 ou 1 ;3) ---------------#"

        };
        private string[] ListeEN =
        {
            "#===========================================#",
            "#                                           #",
            "#           APPLICATION EASY SAVE           #",
            "#-------------------------------------------#",
            "#----------------MAIN MENU------------------#",
            "# 1/ Show saves ----------------------------#",
            "# 2/ Edit saves ----------------------------#",
            "# 3/ Execute one/many saves ----------------#",
            "# 4/ Delete save ---------------------------#",
            "# 5/ Change language -----------------------#",
            "#------------SAVE VISUALIZATION-------------#",
            "#----------------EDIT SAVE------------------#",
            "#---------------EXECUTE SAVE----------------#",
            "#---------------DELETE SAVE-----------------#",
            "#--------------CHANGE LANGUAGE--------------#",
            "#---------------------- Modified backup: ok #",
            "#------------------------- Removal save: ok #",
            "#------------------------ Save executed: ok #",
            "#--------------------- Language changed: ok #",
            "#Would you like to change the language?(Y/N)#",
            "# 1/ French --------------------------------#", // 20
            "# 2/ English -------------------------------#",
            "#------------------------- Invalid input... #",
            "# Which backup needs to be modified? -------#",
            "# Name? ----------------------------------- #",
            "# Source file? ---------------------------- #", // 25
            "# Destination file? ----------------------- #",
            "# Backup type? ---------------------------- #",
            "# Which backup to delete? ----------------- #",
            "# (1 to 5) ---------------------------------#",
            "# Which backups are to be executed? --------#", // 30
            "# (syntax: 1-3 or 1;3) ---------------------#"

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
