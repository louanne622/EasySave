using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
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


            Saves.Add(new Save("test", "test", "tfsdfezft", FileType.Complet));
            Saves.Add(new Save("test", "salut", "test", FileType.Sequential));
        }

        private bool CanShowEditsave(object obj)
        {
            return true;
        }

        private void ShowEditsave(object obj)
        {
            EditSaveView editSaveWin = new EditSaveView();
            editSaveWin.Show();
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
            SelectedItem.FileType = NewTypeFile;

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
            if (string.IsNullOrEmpty(NewNameSave) || string.IsNullOrEmpty(NewSourcePath) || string.IsNullOrEmpty(NewTargetPath) || NewTypeFile == FileType.None)
            {
                MessageBox.Show("Veuillez remplir tous les champs pour ajouter une sauvegarde.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Saves.Add(new Save(NewNameSave, NewSourcePath, NewTargetPath, NewTypeFile));

                NewNameSave = string.Empty;
                NewSourcePath = string.Empty;
                NewTargetPath = string.Empty;
                NewTypeFile = FileType.None;
            }


        }

        private bool CanAddSave(object obj)
        {
            return true;
        }



        public void OnBrowseButtonClick(object sender, RoutedEventArgs e)
        {
            // Utilisation d'OpenFileDialog à la place de FolderBrowserDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ValidateNames = false;
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;
            // Permettre à l'utilisateur de sélectionner un dossier en définissant le nom de fichier sur un libellé spécifique
            openFileDialog.FileName = "Sélectionner ce dossier";
            if (openFileDialog.ShowDialog() == true)
            {
                // Extraire le chemin du dossier à partir du chemin du fichier sélectionné
                string folderPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);

                // Vérifie si le sender est le bouton de sélection du chemin source ou du chemin cible
                if (sender == browseButtonSource)
                {
                    NewSourcePath = folderPath;
                    selectedPathSource.Content = $"Chemin sélectionné : {folderPath}";
                }
                else if (sender == browseButtonTarget)
                {
                    NewTargetPath = folderPath;
                    selectedPathTarget.Content = $"Chemin sélectionné : {folderPath}";
                }
            }
        }




    }
}
