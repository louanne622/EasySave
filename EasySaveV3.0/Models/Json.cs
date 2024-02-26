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
            Save[] newListSaves = new Save[originalSaves.Length];
            for (int i = 0; i < originalSaves.Length; i++)
                newListSaves[i] = originalSaves[i];
            newListSaves[newListSaves.Length - 1] = newSave;
            Json.EditSavesInJson(newListSaves);
            return newListSaves;
        }
        static public void EditSavesInJson(Save[] _saves)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Saves.json",
                JsonSerializer.Serialize(_saves, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
