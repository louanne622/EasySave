using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace EasySaveV2._0
{
    class SaveList
    {
        private readonly string _filePath;
        public static ObservableCollection<Save> _savesList;

        public SaveList(string filePath)
        {
            _filePath = filePath;
            _savesList = new ObservableCollection<Save>();
            LoadSaves();
        }

        public static ObservableCollection<Save> GetSave()
        {
            return _savesList;
        }

        public static void AddSave(Save save)
        {
            _savesList.Add(save);
            SaveSaves(_filePath);
        }

        private void LoadSaves()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _savesList = JsonSerializer.Deserialize<ObservableCollection<Save>>(json);
            }
        }

        private static void SaveSaves()
        {
            string json = JsonSerializer.Serialize(_savesList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
