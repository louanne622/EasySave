using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using EasySaveV3._0.Models;
using EasySaveV3._0.Commands;
using EasySaveV3._0.Views;

namespace EasySaveV3._0.ViewModels
{
    class SaveViewModel : VMWorkspace
    {
        private string _newNameSave;
        public string NewNameSave
        {
            get => _newNameSave;
            set
            {
                if (_newNameSave != value)
                {
                    _newNameSave = value;
                    OnPropertyChanged(nameof(NewNameSave));
                }
            }
        }
        private string _newSourcePath;
        public string NewSourcePath
        {
            get => _newSourcePath;
            set
            {
                if (_newSourcePath != value)
                {
                    _newSourcePath = value;
                    OnPropertyChanged(nameof(NewSourcePath));
                }
            }
        }
        private string _newTargetPath;
        public string NewTargetPath
        {
            get => _newTargetPath;
            set
            {
                if (_newTargetPath != value)
                {
                    _newTargetPath = value;
                    OnPropertyChanged(nameof(NewTargetPath));
                }
            }
        }

        private FileType _newTypeFile;
        public FileType NewTypeFile
        {
            get => _newTypeFile;
            set
            {
                if (_newTypeFile != value)
                {
                    _newTypeFile = value;
                    OnPropertyChanged(nameof(NewTypeFile));
                }
            }
        }

        public ObservableCollection<Save> Saves { get; set; }

        public ICommand ShowAddSaveCommand { get; set; }

        public ICommand DeleteSaveCommand { get; }
        public ICommand AddSaveCommand { get; }

        public ICommand UpdateSaveCommand { get; }
        public ICommand ShowEditSaveCommand { get; }

        public SaveViewModel()
        {
            Saves = new ObservableCollection<Save>();
            DeleteSaveCommand = new RelayCommand(DeleteSave, CanDeleteSave);
            ShowAddSaveCommand = new RelayCommand(ShowWindow, CanShowWindow);
            AddSaveCommand = new RelayCommand(AddSave, CanAddSave);
            ShowEditSaveCommand = new RelayCommand(ShowEditsave, CanShowEditsave);
            UpdateSaveCommand = new RelayCommand(UpdateSave, CanUpdateSave);

            /*
             * Ici on vient mettre nos saves dans le GRID
             */
            Saves.Clear();
            Save[] listSaves = Json.getSavesFromJson();
            for(int i = 0; i < listSaves.Length; i++)
                Saves.Add(listSaves[i]);
        }

        private bool CanShowEditsave(object obj)
        {
            return SelectedItem != null;
        }
        private void ShowEditsave(object obj)
        {
            Save saveToUpdate = SelectedItem;
            MessageBox.Show(saveToUpdate.Name);
            EditSaveView editSaveWin = new EditSaveView(saveToUpdate);
            editSaveWin.Show();
        }

        private bool CanUpdateSave(object parameter)
        {
            // Mettez ici la logique pour vérifier si la mise à jour est possible
            return SelectedItem != null;
        }
        private void UpdateSave(object parameter)
        {
            /*
             * 
             */

            MessageBox.Show("test");

            // Par exemple :
            SelectedItem.Name = NewNameSave;
            SelectedItem.FilesSource = NewSourcePath;
            SelectedItem.FilesTarget = NewTargetPath;

            // Assurez-vous que votre ObservableCollection se met à jour automatiquement dans l'interface utilisateur
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
            Save[] listSave = Json.getSavesFromJson();
            Save saveToDelete = SelectedItem;
            
            listSave = Json.DeleteSavesInList(listSave, saveToDelete);
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
            if (string.IsNullOrEmpty(NewNameSave) || string.IsNullOrEmpty(NewSourcePath) || string.IsNullOrEmpty(NewTargetPath))
            {
                MessageBox.Show("Veuillez remplir tous les champs pour ajouter une sauvegarde.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Save[] savesList = Json.getSavesFromJson();
            Save newSave = new Save(NewNameSave, NewSourcePath, NewTargetPath);

            savesList = Json.getNewSaveList(savesList, newSave);

            Saves.Add(newSave);

            NewNameSave = string.Empty;
            NewSourcePath = string.Empty;
            NewTargetPath = string.Empty;
        }
        private bool CanAddSave(object obj)
        {
            return true;
        }
    }
}
