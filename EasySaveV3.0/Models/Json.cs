using System;
using System.Windows;
using System.IO;
using System.Text.Json;

namespace EasySaveV3._0.Models
{
    class Json
    {
        private static string Name;
        private static string SourceFolder;
        private static string TargetFolder;
        private static string TypeFolder;
        public static void setDataSave(string _name, string _ori, string _targ, string _type)
        {
            Name = _name;
            SourceFolder = _ori;
            TargetFolder = _targ;
            TypeFolder = _type;
        }
        public static bool IsSameSave(Save _save)
        {
            return (Name == _save.Name && SourceFolder == _save.FilesSource && TargetFolder == _save.FilesTarget && TypeFolder == _save.FilesType);
        }
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
                    if (!string.IsNullOrEmpty(newSave.FilesType))
                    {
                        if (newSave.FilesType.Length > 0) _save.FilesType = newSave.FilesType;
                    }

                    EditSavesInJson(originalSaves);
                    return originalSaves;
                }
            }
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
