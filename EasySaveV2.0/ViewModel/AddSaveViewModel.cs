using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace EasySaveV2._0
{
    public class AddSaveViewModel : VMWorkspace
    {
        // Commande pour ajouter la sauvegarde
        public ICommand AddSaveCommand { get; }

        // Propriétés pour les données de la nouvelle sauvegarde
        private string _saveName;
        public string SaveName
        {
            get { return _saveName; }
            set
            {
                _saveName = value;
                OnPropertyChanged(nameof(SaveName));
            }
        }

        private string _sourcePath;
        public string SourcePath
        {
            get { return _sourcePath; }
            set
            {
                _sourcePath = value;
                OnPropertyChanged(nameof(SourcePath));
            }
        }

        private string _targetPath;
        public string TargetPath
        {
            get { return _targetPath; }
            set
            {
                _targetPath = value;
                OnPropertyChanged(nameof(TargetPath));
            }
        }

        private string _fileType;
        public string FileType
        {
            get { return _fileType; }
            set
            {
                _fileType = value;
                OnPropertyChanged(nameof(FileType));
            }
        }

        // Injectez le view model qui contient la liste de sauvegardes
        private readonly SaveListingViewModel _saveListingViewModel;

        public AddSaveViewModel(SaveListingViewModel saveListingViewModel)
        {
            _saveListingViewModel = saveListingViewModel;

            // Initialisez la commande
            AddSaveCommand = new RelayCommand(AddSave);
        }

        // Méthode exécutée lorsque la commande pour ajouter la sauvegarde est déclenchée
        private void AddSave(object parameter)
        {
            // Créer une nouvelle sauvegarde avec les données récupérées
            Save newSave = new Save(SaveName, SourcePath, TargetPath, FileType);

            // Ajoutez la nouvelle sauvegarde à la liste dans SaveListingViewModel
            _saveListingViewModel.Saves.Add(newSave);
        }
    }
}
