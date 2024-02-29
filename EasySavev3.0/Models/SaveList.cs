using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace EasySaveV3._0.Models
{
    class SaveList
    {
        private readonly ObservableCollection<Save> _saves;
        public SaveList()
        {
            _saves = new ObservableCollection<Save>();
        }

        public IEnumerable<Save> GetSave()
        {
            return _saves;
        }

        public void AddSave(Save save)
        {

            _saves.Add(save);
        }
    }
}
