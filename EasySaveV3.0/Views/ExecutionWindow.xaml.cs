using System;
using System.Windows;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Linq;
using EasySaveV3._0.Models;
using EasySaveV3._0.Resources;

namespace EasySaveV3._0.Views
{
    /// <summary>
    /// Logique d'interaction pour ExecutionWindow.xaml
    /// </summary>
    public partial class ExecutionWindow : Window
    {
        private IEnumerable _selectedItems;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private bool _isPaused = false;
        private ManualResetEventSlim _pauseEvent = new ManualResetEventSlim(true);
        public ExecutionWindow()
        {
            InitializeComponent();
        }
        public ExecutionWindow(IEnumerable selectedItems)
        {
            InitializeComponent();
            _selectedItems = selectedItems;
            foreach (var item in _selectedItems)
            {
                if (item is Save)
                {
                    var decorator = new ItemDecorator((Save)item);
                    lbResults.Items.Add(decorator);
                }
            }
        }
        private async void BtnCopyFiles_Click(object sender, RoutedEventArgs e)
        {
            int maxFileSizeInKb = UserProperties.Default.MaxSizeFile * 1024; // Convertir en Ko
            var decorators = lbResults.Items.Cast<ItemDecorator>().ToList();
            string[] priorityExtensions = { ".txt", ".pdf", ".docx" }; // Extensions prioritaires
            string[] cryptExtensions = { ".txt", ".json" }; // Extensions à chiffrer

            var tasks = decorators.SelectMany(decorator => Directory.GetFiles(decorator.Item.FilesSource)
                .OrderBy(file =>
                {
                    var extension = Path.GetExtension(file).ToLower();
                    var index = Array.IndexOf(priorityExtensions, extension);
                    return index < 0 ? int.MaxValue : index;
                })
                .Where(file => new FileInfo(file).Length / 1024 <= maxFileSizeInKb)
                .Select(async file =>
                {
                    await CheckForBlockingAppsAsync();
                    _pauseEvent.Wait();
                    if (_cts.IsCancellationRequested) return;

                    var fileName = Path.GetFileName(file);
                    var destFile = Path.Combine(decorator.Item.FilesTarget, fileName);
                    if (cryptExtensions.Contains(Path.GetExtension(file).ToLower()))
                    {
                        await CopyAndEncryptFileAsync(file, destFile, 255); // Utiliser la clé de cryptage spécifiée
                    }
                    else
                    {
                        await CopyFileAsync(file, destFile);
                    }

                })).ToList();

            await Task.WhenAll(tasks);
        }
        private async Task CopyAndEncryptFileAsync(string sourceFile, string destFile, byte key)
        {
            byte[] inputBytes = await File.ReadAllBytesAsync(sourceFile);
            byte[] encryptedBytes = new byte[inputBytes.Length];
            for (int i = 0; i < inputBytes.Length; i++)
            {
                encryptedBytes[i] = (byte)(inputBytes[i] ^ key); // Cryptage simple XOR
            }
            await File.WriteAllBytesAsync(destFile, encryptedBytes);
        }
        private async Task CopyFileAsync(string sourceFile, string destFile)
        {
            byte[] bytes = await File.ReadAllBytesAsync(sourceFile);
            await File.WriteAllBytesAsync(destFile, bytes);
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            _isPaused = !_isPaused;

            if (_isPaused)
            {
                _pauseEvent.Reset();
                MessageBox.Show("Processus mis en pause.");
            }
            else
            {
                _pauseEvent.Set();
                MessageBox.Show("Processus repris.");
            }
        }

        private async Task CheckForBlockingAppsAsync()
        {
            string[] blockingApps = { "notepad", "calc" };
            bool isBlockingAppRunning;

            do
            {
                isBlockingAppRunning = Process.GetProcesses().Any(p => blockingApps.Contains(p.ProcessName.ToLower()));

                if (isBlockingAppRunning)
                {
                    await Task.Delay(5000);
                }
            } while (isBlockingAppRunning);

        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            _cts.Cancel();
            MessageBox.Show("Arrêt du processus demandé.");
        }

        private double _progressValue;
        public double ProgressValue
        {
            get { return _progressValue; }
            set
            {
                _progressValue = value;
                OnPropertyChanged(nameof(ProgressValue));
                OnPropertyChanged(nameof(ProgressPercentage));
            }
        }
        public string ProgressPercentage => $"{ProgressValue}%";

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
