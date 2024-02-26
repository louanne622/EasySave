using System;
using System.Windows;
using System.IO;
using System.Text.Json;

namespace EasySaveV3._0.Models
{
    class Json
    {
        static public Save[] getSavesFromJson()
        {
            return JsonSerializer.Deserialize<Save[]>
                (File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Saves.json"));
        }
        static public Save[] getNewSaveList(Save[] originalSaves, Save newSave)
        {
            /*
             * Verification of the name of the new save, if it's already used ...
             */
            foreach (Save _save in originalSaves)
            {
                if(_save.Name == newSave.Name)
                {
                    MessageBox.Show("Attention, le nom de la sauvegarde est déjà utilisé.");
                    return originalSaves; // The list won't change in the program
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
        static public Save[] UpdateSaveList(Save[] originalSaves, Save saveToUpdate, string newName, string newPathOr, string newPathTar)
        {
            /*
            * Verification of the update name of the save
            */
            foreach (Save _save in originalSaves)
            {
                if(_save != saveToUpdate && _save.Name == newName)
                {
                    MessageBox.Show("Attention, le nom est déjà utilisé ...");
                    return originalSaves;
                }
            }
            /*
            * Change the attributs of the Save and Update the JSON
            */
            if (newName.Length > 0) saveToUpdate.Name = newName;
            if (newPathOr.Length > 0) saveToUpdate.FilesSource = newPathOr;
            if (newPathTar.Length > 0) saveToUpdate.FilesTarget = newPathTar;

            EditSavesInJson(originalSaves);
            return originalSaves;
        }
        static public Save[] DeleteSavesInList(Save[] originalSaves, Save deleteSave)
        {
            /*
            * Verification of the name of the save exist
            */
            foreach (Save _save in originalSaves)
            {
                if (_save.Name == deleteSave.Name)
                {
                    Save[] newListSaves = new Save[originalSaves.Length - 1];
                    int j = 0;
                    for (int i = 0; i < newListSaves.Length; i++)
                    {
                        if(originalSaves[i].Name != deleteSave.Name)
                        {
                            newListSaves[i - j] = originalSaves[i];
                        } else 
                        { 
                            j++; 
                        }
                    }
                    Json.EditSavesInJson(newListSaves);
                    return newListSaves;
                }
            }
            return originalSaves;
        }
        static public void EditSavesInJson(Save[] _saves)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Saves.json",
                JsonSerializer.Serialize(_saves, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
