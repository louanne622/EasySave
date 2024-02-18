using System.Globalization;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EasySaveV2._0.Resources;
using System;
using System.Collections.ObjectModel; 
using System.Diagnostics;
using System.IO; 
using System.Windows.Input;
using EasySaveV2._0.Model;

namespace EasySaveV2._0.ViewModel
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public IUIBase UI { get; private set; }
        public ObservableCollection<string> FileNames { get; private set; }
        public ICommand OpenFileCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private string _selectedFile;
        private SettingsModel _settings;
        public string SelectedFile
        {
            get => _selectedFile;
            set
            {
                if (_selectedFile != value)
                {
                    _selectedFile = value;
                    OnPropertyChanged(nameof(SelectedFile));
                    (OpenFileCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }
        public SettingsViewModel()
        {
            UI = new IUIBase();
            _settings = new SettingsModel
            {
                Language = UserProperties.Default.Language,
                LogFilePath = UserProperties.Default.LogFilePath,
                EncryptedExtensions = UserProperties.Default.EncryptedExtensions,
                LogExtension = UserProperties.Default.LogExtension
            };
            UI = new IUIBase();
            FileNames = new ObservableCollection<string>();
            OpenFileCommand = new RelayCommand(ExecuteOpenFile, CanExecuteOpenFile);
            ChangeLanguage(UserProperties.Default.Language);
            LoadFiles();
        }
        public string Language
        {
            get => UserProperties.Default.Language;
            set
            {
                if (UserProperties.Default.Language != value)
                {
                    UserProperties.Default.Language = value;
                    OnPropertyChanged(nameof(Language));
                    SaveSettings();
                    ChangeLanguage(value);
                    LogExtension = UserProperties.Default.LogExtension;
                }
            }
        }
        public string LogFilePath
        {
            get => UserProperties.Default.LogFilePath;
            set
            {
                if (UserProperties.Default.LogFilePath != value)
                {
                    UserProperties.Default.LogFilePath = value;
                    OnPropertyChanged(nameof(LogFilePath));
                    SaveSettings();
                    LoadFiles();
                }
            }
        }
        public string EncryptedExtensions
        {
            get => UserProperties.Default.EncryptedExtensions;
            set
            {
                if (UserProperties.Default.EncryptedExtensions != value)
                {
                    UserProperties.Default.EncryptedExtensions = value;
                    OnPropertyChanged(nameof(EncryptedExtensions));
                    SaveSettings();
                }
            }
        }
        public string LogExtension
        {
            get => _settings.LogExtension;
            set
            {
                if (_settings.LogExtension != value)
                {
                    _settings.LogExtension = value;
                    OnPropertyChanged();
                    SaveSettings();
                }
            }
        }
        private void SaveSettings()
        {
            UserProperties.Default.Save();
        }
        private void ChangeLanguage(string languageFriendlyName)
        {
            string cultureCode = languageFriendlyName switch
            {
                "Français" => "FR",
                "English" => "EN",
                _ => "EN"
            };

            CultureInfo culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = culture;
            UI.UpdateLocalizedProperties(cultureCode);
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void LoadFiles()
        {
            FileNames.Clear();
            var logPath = UserProperties.Default.LogFilePath;
            if (Directory.Exists(logPath))
            {
                var files = Directory.GetFiles(logPath);
                foreach (var file in files)
                {
                    FileNames.Add(Path.GetFileName(file));
                }
            }
        }
        private bool CanExecuteOpenFile(object parameter)
        {
            return !string.IsNullOrEmpty(SelectedFile);
        }
        private void ExecuteOpenFile(object parameter)
        {
            var fullPath = Path.Combine(UserProperties.Default.LogFilePath, SelectedFile);
            Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
        }
    }
}