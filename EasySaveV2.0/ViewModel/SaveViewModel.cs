using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace EasySaveV2._0
{
    class SaveViewModel : VMWorkspace
    {
        public string NewNameSave { get; set; }
        public string NewSourcePath { get; set; }
        public string NewTargetPath { get; set; }
        public string NewTypeFile { get; set; }

        public ObservableCollection<Save> Saves { get; set; }

        public ICommand ShowSaveCommand { get; set; }
        public ICommand DeleteSaveCommand { get; }
        public ICommand AddSaveCommand { get; }

        public SaveViewModel()
        {
            Saves = new ObservableCollection<Save>();

            DeleteSaveCommand = new RelayCommand(DeleteSave, CanDeleteSave);
            ShowSaveCommand = new RelayCommand(ShowWindow, CanShowWindow);
            AddSaveCommand = new RelayCommand(AddSave, CanAddSave);

            Saves.Add(new Save("test", "test", "tfsdfezft", "test"));
            Saves.Add(new Save("test", "salut", "test", "test"));
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


        private void AddSave(object obj)
        {
            if (!string.IsNullOrEmpty(NewNameSave) && !string.IsNullOrEmpty(NewSourcePath) && !string.IsNullOrEmpty(NewTargetPath) && !string.IsNullOrEmpty(NewTypeFile))
            {
                Saves.Add(new Save(NewNameSave, NewSourcePath, NewTargetPath, NewTypeFile));
                
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs pour ajouter une sauvegarde.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private bool CanAddSave(object obj)
        {
            return true;
        }
    }
}
