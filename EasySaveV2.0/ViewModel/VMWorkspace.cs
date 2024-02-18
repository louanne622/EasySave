using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Input;

namespace EasySaveV2._0
{
    class VMWorkspace : INotifyPropertyChanged
    {
        private ObservableCollection<Save> _saves;
        public ICommand AddSave { get; private set; }

        public ObservableCollection<Save> Saves
        {
            get { return _saves; }
            set
            {
                _saves = value;
                OnPropertyChanged("Saves");
            }
        }

        public VMWorkspace()
        {
            Saves = new ObservableCollection<Save>();
            int Nombre_ActionSave = 5;
           
        

            for (int i = 1; i <= Nombre_ActionSave; i++)
            {
                Saves.Add(new Save($"Sauvegarde {i}", $"Source {i}", $"Cible {i}", $"Type {i}"));
            }
            AddSave = new BaseCommand(AddExecute);

        }
        private void AddExecute(object parameter)
        {
            AddSaveView addWindow = new AddSaveView();
            addWindow.ShowDialog(); 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
