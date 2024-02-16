using System;
using System.Windows.Input;

namespace EasySaveV2._0
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;

        public RelayCommand(Action execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; // Toujours autoriser l'exécution de la commande
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke();
        }
    }
}
