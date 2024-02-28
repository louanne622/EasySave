using System.ComponentModel;
using EasySaveV3._0.Models;

namespace EasySaveV3._0.ViewModels
{
    public class VMWorkspace : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Save[] listSaves;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
