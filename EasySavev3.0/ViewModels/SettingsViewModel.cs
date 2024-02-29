using System.Globalization;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using EasySaveV3._0.Models;
using EasySaveV3._0.Commands;
using EasySaveV3._0.Resources;


namespace EasySaveV3._0.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public IUIBase UI { get; private set; }
        public ObservableCollection<string> FileNames { get; private set; } = new ObservableCollection<string>();
        public ICommand OpenFileCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private string _selectedFile;
        private readonly SettingsModel _settings = new SettingsModel();
        public string SelectedFile
        {
            get => _selectedFile;
            set
            {
                if (_selectedFile != value)
                {
                    _selectedFile = value;
                    OnPropertyChanged();
                    (OpenFileCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }
        public SettingsViewModel()
        {
            UI = new IUIBase();
            InitializeSettings();
            OpenFileCommand = new RelayCommand(ExecuteOpenFile, CanExecuteOpenFile);
            LoadFiles();
        }

        private void InitializeSettings()
        {
            var userProps = UserProperties.Default;
            _settings.Language = userProps.Language;
            _settings.LogFilePath = userProps.LogFilePath;
            _settings.EncryptedExtensions = userProps.EncryptedExtensions;
            _settings.LogExtension = userProps.LogExtension;
            _settings.PriorityFiles = userProps.PriorityFiles;
            _settings.MaxSizeFile = userProps.MaxSizeFile;

            ChangeLanguage(userProps.Language);
        }

        public string Language
        {
            get => UserProperties.Default.Language;
            set
            {
                if (UserProperties.Default.Language != value)
                {
                    UserProperties.Default.Language = value;
                    OnPropertyChanged();
                    SaveSettings();
                    ChangeLanguage(value);
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
            get => UserProperties.Default.LogExtension;
            set
            {
                if (UserProperties.Default.LogExtension != value)
                {
                    UserProperties.Default.LogExtension = value;
                    OnPropertyChanged();
                    SaveSettings();
                }
            }
        }
        public string PriorityFiles
        {
            get => UserProperties.Default.PriorityFiles;
            set
            {
                if (UserProperties.Default.PriorityFiles != value)
                {
                    UserProperties.Default.PriorityFiles = value;
                    OnPropertyChanged();
                    SaveSettings();
                }
            }
        }
        public int MaxSizeFile
        {
            get => UserProperties.Default.MaxSizeFile;
            set
            {
                if (UserProperties.Default.MaxSizeFile != value)
                {
                    UserProperties.Default.MaxSizeFile = value;
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
                "Spanish" => "ES",
                _ => "FR"
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