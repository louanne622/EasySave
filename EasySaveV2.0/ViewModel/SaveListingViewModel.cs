using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace EasySaveV2._0
{
    public class SaveListingViewModel : VMWorkspace
    {
        public ObservableCollection<Save> Saves { get; set; }

        public ICommand ShowSaveCommand { get; set; }

        public SaveListingViewModel()
        {
            Saves = SaveList.GetSave();

            Saves.Add(new Save("test", "test", "test", "test"));

        }

        private void ShowWindow(object obj)
        {
            AddSaveView addSaveWin = new AddSaveView();
            addSaveWin.Show();
        }

        private bool CanShowWindow(object obj)
        {
            
            return true;
        }
    }
}
