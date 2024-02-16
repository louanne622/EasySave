using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsol_2
{
    class ViewConsole
    {
        /*
         * Attribut that will be used for the language for the application
         */
        private string language;
        private string extension;
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
            "# (ex synthaxe: 1-3 ou 1 ;3) ---------------#",
            "# 6/ Modifier l'extension des logs ---------#",
            "#----------CHANGEMENT D EXTENSION-----------#",
            "#------------------- Extension modifiée: ok #",
            "#-Souhaitez-vous changer d'extension ?(Y/N)-#", // 35
            "# 1/ .JSON ---------------------------------#", 
            "# 2/ .XML ----------------------------------#"
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
            "# (syntax: 1-3 or 1;3) ---------------------#",
            "# 6/ Modify the log extension --------------#",
            "#------------CHANGE OF EXTENSION------------#",
            "#------------------- Modified extension: ok #",
            "#-Do you want to change the extension?(Y/N)-#", // 35
            "# 1/ .JSON ---------------------------------#",
            "# 2/ .XML ----------------------------------#"
        };
        public ViewConsole()
        {
            /*
             * This will get the information about the language in the
             * config file
             */
            this.language = ClassUtility.GetConfigData("language");
            this.extension = ClassUtility.GetConfigData("extension");
        }
        public void setLang(string input)
        {
            this.language = input;
            ClassUtility.SetConfigData("language", input);
        }
        public void setExtension(string input)
        {
            this.extension = input;
            ClassUtility.SetConfigData("extension", input);
        }
        public string getLang()
        {
            return this.language;
        }
        public string getExtension()
        {
            return this.extension;
        }
        private string[] getListLang(string lang)
        {
            switch (lang)
            {
                case "1":
                    return this.ListeFR;
                case "2":
                    return this.ListeEN;
                default:
                    return this.ListeEN;
            }
        }
        public void getDataString(string data)
        {
            int[] numList = ClassUtility.ParseBackupNumbers(data).ToArray();
            string[] dataLang = this.getListLang(getLang());
            for (int i = 0; i < numList.Length; i++) Console.WriteLine(dataLang[numList[i]]);
        }
        public void getSaveData(Save _save)
        {
            this.getDataString("0");
            Console.WriteLine("Id:         " + _save.Id);
            Console.WriteLine("Name:       " + _save.Name);
            Console.WriteLine("FileSource: " + _save.FilesSource);
            Console.WriteLine("FileTarget: " + _save.FilesTarget);
            Console.WriteLine("Type:       " + _save.Type);
        }
    }
}
