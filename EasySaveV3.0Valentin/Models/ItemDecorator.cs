using System;
using System.ComponentModel;

namespace EasySaveV3._0.Models
{
    class ItemDecorator : INotifyPropertyChanged
    {
        private Save _item;
        private double _progressValue;
        private bool _isPaused;
        public ItemDecorator(Save item)
        {
            _item = item;
        }
        public Save Item
        {
            get { return _item; }
        }
        public string Nom => _item.Name;
        public string Source => _item.FilesSource;
        public string Cible => _item.FilesTarget;
        public double ProgressValue
        {
            get => _progressValue;
            set
            {
                if (_progressValue != value)
                {
                    _progressValue = value;
                    OnPropertyChanged(nameof(ProgressValue));
                    OnPropertyChanged(nameof(ProgressPercentage));
                }
            }
        }
        public string ProgressPercentage => $"{ProgressValue}%";
        public bool IsPaused
        {
            get => _isPaused;
            set
            {
                if (_isPaused != value)
                {
                    _isPaused = value;
                    OnPropertyChanged(nameof(IsPaused));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
