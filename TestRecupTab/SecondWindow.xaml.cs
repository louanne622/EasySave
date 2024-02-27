using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Linq;

namespace TestRecupTab
{
    public class ItemDecorator : INotifyPropertyChanged
    {
        private Item _item;
        private double _progressValue;
        private bool _isPaused;

        public ItemDecorator(Item item)
        {
            _item = item;
        }
        public Item Item
        {
            get { return _item; }
        }
        public string Nom => _item.Nom;
        public string Source => _item.Source;
        public string Cible => _item.Cible;
        public string Type => _item.Type;

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

        public string ProgressPercentage => $"{ProgressValue}%";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class SecondWindow : Window
    {
        private IEnumerable _selectedItems;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private bool _isPaused = false;
        private ManualResetEventSlim _pauseEvent = new ManualResetEventSlim(true);

        public SecondWindow(IEnumerable selectedItems)
        {
            InitializeComponent();
            _selectedItems = selectedItems;
            foreach (var item in _selectedItems)
            {
                if (item is Item)
                {
                    var decorator = new ItemDecorator((Item)item);
                    lbResults.Items.Add(decorator);
                }
            }
        }

        private async void BtnCopyFiles_Click(object sender, RoutedEventArgs e)
        {
            long maxFileSizeInKb = 800; // en Mo
            maxFileSizeInKb = maxFileSizeInKb * 1024;
            var decorators = lbResults.Items.Cast<ItemDecorator>().ToList();

            var tasks = decorators.Select(async decorator =>
            {
                var item = decorator.Item;
                Directory.CreateDirectory(item.Cible);

                var allFiles = Directory.GetFiles(item.Source);
                string[] priorityExtensions = { ".txt", ".pdf", ".docx" }; // Extensions prioritaires en premier.
                var orderedFiles = allFiles.OrderBy(file =>
                {
                    var extension = System.IO.Path.GetExtension(file).ToLower();
                    var index = Array.IndexOf(priorityExtensions, extension);
                    return index < 0 ? int.MaxValue : index; // Les fichiers non prioritaires sont mis à la fin.
                });

                for (int i = 0; i < orderedFiles.Count(); i++)
                {
                    await CheckForBlockingAppsAsync();
                    _pauseEvent.Wait();
                    if (_cts.IsCancellationRequested) break;

                    var file = orderedFiles.ElementAt(i);
                    var fileInfo = new FileInfo(file);

                    if (fileInfo.Length / 1024 <= maxFileSizeInKb)
                    {
                        var fileName = System.IO.Path.GetFileName(file);
                        var destFile = System.IO.Path.Combine(item.Cible, fileName);

                        if (System.IO.Path.GetExtension(file).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                        {
                            await CopyAndEncryptFileAsync(file, destFile, 255);
                        }
                        else
                        {
                            await CopyFileAsync(file, destFile);
                        }

                    }

                    decorator.ProgressValue = (double)(i + 1) / file.Length * 100;
                }
            });

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