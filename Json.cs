using System;
using System.Windows;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;


namespace EasySaveV3._0.Models
{
    class Json
    {
        private static string Name;
        private static string SourceFolder;
        private static string TargetFolder;
        public static void setDataSave(string _name, string _ori, string _targ)
        {
            Name = _name;
            SourceFolder = _ori;
            TargetFolder = _targ;
        }
        public static bool IsSameSave(Save _save)
        {
            return (Name == _save.Name && SourceFolder == _save.FilesSource && TargetFolder == _save.FilesTarget);
        }
        static public Save[] getSavesFromJson()
        {
            return JsonSerializer.Deserialize<Save[]>
                (File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Saves.json"));
        }
        static public Save[] getNewSaveList(Save[] originalSaves, Save newSave)
        {
            if (originalSaves.Length != 0)
            {
                foreach (Save _save in originalSaves)
                {
                    if (_save.Name == newSave.Name)
                    {
                        MessageBox.Show("Attention, le nom de la sauvegarde est déjà utilisé.");
                        return originalSaves; // The list won't change in the program
                    }
                }
            }
            
            /*
             * If it's not already used ...
             */
            Save[] newListSaves = new Save[originalSaves.Length + 1];
            for (int i = 0; i < originalSaves.Length; i++)
                newListSaves[i] = originalSaves[i];
            newListSaves[newListSaves.Length - 1] = newSave;
            Json.EditSavesInJson(newListSaves);
            return newListSaves;
        }
        static public Save[] UpdateSaveList(Save newSave)
        {
            /*
            * Verification of the update name of the save
            */
            Save[] originalSaves = Json.getSavesFromJson();
            foreach (Save _save in originalSaves)
            {
                if(Json.IsSameSave(_save))
                {
                    if (!string.IsNullOrEmpty(newSave.Name))
                    {
                        if (newSave.Name.Length > 0) _save.Name = newSave.Name;
                    }
                    if (!string.IsNullOrEmpty(newSave.FilesSource))
                    {
                        if (newSave.FilesSource.Length > 0) _save.FilesSource = newSave.FilesSource;
                    }
                    if (!string.IsNullOrEmpty(newSave.FilesTarget))
                    {
                        if (newSave.FilesTarget.Length > 0) _save.FilesTarget = newSave.FilesTarget;
                    }

                    EditSavesInJson(originalSaves);
                    return originalSaves;
                }
            }
            return originalSaves;

        }
        static public Save[] DeleteSavesInList(Save[] originalSaves, Save deleteSave)
        {
            List<Save> newListSaves = new List<Save>();

            // Recherche de l'index de la sauvegarde à supprimer dans la liste originale
            int indexToDelete = -1;
            for (int i = 0; i < originalSaves.Length; i++)
            {
                if (originalSaves[i].Name == deleteSave.Name)
                {
                    indexToDelete = i;
                    break;
                }
            }

            // Si l'index à supprimer est trouvé, construisons la nouvelle liste sans cet index
            if (indexToDelete != -1)
            {
                for (int i = 0; i < originalSaves.Length; i++)
                {
                    if (i != indexToDelete)
                    {
                        newListSaves.Add(originalSaves[i]);
                    }
                }
            }
            else
            {
                // Si la sauvegarde à supprimer n'a pas été trouvée, retourner la liste originale
                return originalSaves;
            }

            // Mise à jour du fichier JSON avec la nouvelle liste de sauvegardes
            Json.EditSavesInJson(newListSaves.ToArray());

            return newListSaves.ToArray(); // Retourner la nouvelle liste de sauvegardes
        }


        static public void EditSavesInJson(Save[] _saves)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Saves.json",
                JsonSerializer.Serialize(_saves, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
