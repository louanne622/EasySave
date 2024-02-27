using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace EasySaveV2._0
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

        private string _newFileType;
        public string NewTypeFile
        {
            get => _newFileType;
            set
            {
                if (_newFileType != value)
                {
                    _newFileType = value;
                    OnPropertyChanged(nameof(NewTypeFile));
                }
            }
        }

        public ObservableCollection<Save> Saves { get; set; }

        public ICommand ShowAddSaveCommand { get; set; }
        public ICommand DeleteSaveCommand { get; set; }
        public ICommand AddSaveCommand { get; set; }
        public ICommand UpdateSaveCommand { get; set; }
        public ICommand ShowEditSaveCommand { get; set; }

        public SaveViewModel()
        {
            Saves = new ObservableCollection<Save>();
            ShowAddSaveCommand = new RelayCommand(ShowWindow, CanShowWindow);
            DeleteSaveCommand = new RelayCommand(DeleteSave, CanDeleteSave);
            AddSaveCommand = new RelayCommand(AddSave, CanAddSave);
            ShowEditSaveCommand = new RelayCommand(ShowEditsave, CanShowEditsave);
            UpdateSaveCommand = new RelayCommand(UpdateSave, CanUpdateSave);

            Saves.Add(new Save("test", "test", "tfsdfezft", "complet"));
            Saves.Add(new Save("test", "salut", "test", "sequential"));
        }


        private bool CanAddSave(object obj)
        {
            return true;
        }

        private void ShowEditsave(object obj)
        {
            EditSaveView editSaveWin = new EditSaveView();
            editSaveWin.Show();
        }
        private bool CanShowEditsave(object obj)
        {
            return true;
        }


        private bool CanUpdateSave(object parameter)
        {
            return SelectedItem != null;
        }

        private void UpdateSave(object parameter)
        {
            SelectedItem.saveName = NewNameSave;
            SelectedItem.sourcePath = NewSourcePath;
            SelectedItem.targetPath = NewTargetPath;
            SelectedItem.fileType = NewTypeFile;

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
            if (string.IsNullOrEmpty(NewNameSave) || string.IsNullOrEmpty(NewSourcePath) || string.IsNullOrEmpty(NewTargetPath) || string.IsNullOrEmpty(NewTypeFile))
            {
                MessageBox.Show("Veuillez remplir tous les champs pour ajouter une sauvegarde.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Saves.Add(new Save(NewNameSave, NewSourcePath, NewTargetPath, NewTypeFile));

                NewNameSave = string.Empty;
                NewSourcePath = string.Empty;
                NewTargetPath = string.Empty;
                NewTypeFile = string.Empty;
            }


        }

        
    }
}
