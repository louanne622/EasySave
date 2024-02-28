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
        /*
         * ADD SAVES
         */
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
        private string _newTypeSave;
        public string NewTypeSave
        {
            get => _newTypeSave;
            set
            {
                if (_newTypeSave != value)
                {
                    _newTypeSave = value;
                    OnPropertyChanged(nameof(NewTypeSave));
                }
            }
        }

        /*
         * UPDATE SAVES
         */
        private string _updateNameSave;
        public string updateNameSave
        {
            get => _updateNameSave;
            set
            {
                if (_updateNameSave != value)
                {
                    _updateNameSave = value;
                    OnPropertyChanged(nameof(updateNameSave));
                }
            }
        }
        private string _updateSourcePath;
        public string updateSourcePath
        {
            get => _updateSourcePath;
            set
            {
                if (_updateSourcePath != value)
                {
                    _updateSourcePath = value;
                    OnPropertyChanged(nameof(updateSourcePath));
                }
            }
        }
        private string _updateTargetPath;
        public string updateTargetPath
        {
            get => _updateTargetPath;
            set
            {
                if (_updateTargetPath != value)
                {
                    _updateTargetPath = value;
                    OnPropertyChanged(nameof(updateTargetPath));
                }
            }
        }

        private string _updateTypeSave;
        public string updateTypeSave
        {
            get => _updateTypeSave;
            set
            {
                if (_updateTypeSave != value)
                {
                    _updateTypeSave = value;
                    OnPropertyChanged(nameof(updateTypeSave));
                }
            }
        }


        public ObservableCollection<Save> Saves { get; set; }
        private void UpdateObservableCollection(ObservableCollection<Save> saves)
        {
            saves.Clear();
            Save[] listSaves = Json.getSavesFromJson();
            for (int i = 0; i < listSaves.Length; i++)
                saves.Add(listSaves[i]);
        }

        public ICommand ShowAddSaveCommand { get; set; }
        public ICommand DeleteSaveCommand { get; }
        public ICommand AddSaveCommand { get; }
        public ICommand UpdateSaveCommand { get; }
        public ICommand ShowEditSaveCommand { get; }
        public ICommand ExecSaveCommand { get; }

        public SaveViewModel()
        {
            Saves = new ObservableCollection<Save>();
            DeleteSaveCommand = new RelayCommand(DeleteSave, CanDeleteSave);
            ShowAddSaveCommand = new RelayCommand(ShowWindow, CanShowWindow);
            AddSaveCommand = new RelayCommand(AddSave, CanAddSave);
            ShowEditSaveCommand = new RelayCommand(ShowEditsave, CanShowEditsave);
            UpdateSaveCommand = new RelayCommand(UpdateSave, CanUpdateSave);
            //ExecSaveCommand = new RelayCommand(ExecSave, CanExecSave);

            /*
             * Ici on vient mettre nos saves dans le GRID
             */
            Saves.Clear();
            Save[] listSaves = Json.getSavesFromJson();
            for (int i = 0; i < listSaves.Length; i++)
                Saves.Add(listSaves[i]);
        }

        private bool CanShowEditsave(object obj)
        {
            return SelectedItem != null;
        }

        private void ShowEditsave(object obj)
        {
            EditSaveView editSaveWin;
            if (SelectedItem == null)
                editSaveWin = new EditSaveView();
            else
                editSaveWin = new EditSaveView(SelectedItem);
            editSaveWin.Show();
        }

        private bool CanUpdateSave(object parameter)
        {
            // Mettez ici la logique pour vérifier si la mise à jour est possible
            return SelectedItem != null;
        }

        private void UpdateSave(object parameter)
        {
            if (string.IsNullOrEmpty(updateNameSave) && string.IsNullOrEmpty(updateSourcePath) && string.IsNullOrEmpty(updateTargetPath))
            {
                MessageBox.Show("Veuillez remplir les champs pour modifier une sauvegarde.", "Erreur", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Save newSave = new Save(updateNameSave, updateSourcePath, updateTargetPath, updateTypeSave);
                Save[] listSave = Json.UpdateSaveList(newSave);

                Json.EditSavesInJson(listSave);

                NewNameSave = string.Empty;
                NewSourcePath = string.Empty;
                NewTargetPath = string.Empty;
                NewTypeSave = string.Empty;

                this.UpdateObservableCollection(Saves);
            }
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
            this.UpdateObservableCollection(this.Saves);
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
            }
            else
            {
                Save newSave = new Save(NewNameSave, NewSourcePath, NewTargetPath, NewTypeSave);
                Save[] listSaves = Json.getSavesFromJson();
                listSaves = Json.getNewSaveList(listSaves, newSave);
                Json.EditSavesInJson(listSaves);

                NewNameSave = string.Empty;
                NewSourcePath = string.Empty;
                NewTargetPath = string.Empty;
                NewTypeSave = string.Empty;

                this.UpdateObservableCollection(Saves);
            }
        }

        private bool CanAddSave(object obj)
        {
            return true;
        }
        private bool CanExecSave(object obj)
        {
            return SelectedItem != null;
        }
        private void ExecSave(MainWindow main)
        {
            
            return;
        }
    }
}
