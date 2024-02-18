using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EasySaveV2._0
{
    class SaveList
    {
        public static ObservableCollection<Save> _savesList;

        public SaveList()
        {
            _savesList = new ObservableCollection<Save>();
        }

        public static ObservableCollection<Save> GetSave()
        {
            return _savesList;
        }

        public static void AddSave(Save save)
        {
            _savesList.Add(save);
        }
    }
}
