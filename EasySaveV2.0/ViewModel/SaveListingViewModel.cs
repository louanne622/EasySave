using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace EasySaveV2._0
{
    public class SaveListingViewModel : VMWorkspace, INotifyPropertyChanged
    {
        public ObservableCollection<Save> Saves { get; set; }

        public ICommand ShowSaveCommand { get; set; }
        public ICommand DeleteSaveCommand { get; }

        public SaveListingViewModel()
        {
            DeleteSaveCommand = new RelayCommand(DeleteSave, CanDeleteSave);
            ShowSaveCommand = new RelayCommand(ShowWindow, CanShowWindow);
            Saves = SaveList.GetSave();

            Saves.Add(new Save("test", "test", "test", "test"));
            Saves.Add(new Save("test", "test", "test", "test"));

        }

        private Save _selectedItem;
        public Save SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
            }
        }

        private bool CanDeleteSave(object parameter)
        {
            return SelectedItem != null;
        }
        private void DeleteSave(object parameter)
        {
            Saves.Remove(SelectedItem);
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
