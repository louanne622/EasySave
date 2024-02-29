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

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EasySaveV3._0.Views
{
    /// <summary>
    /// Logique d'interaction pour ExecutionWindow.xaml
    /// </summary>
    public partial class ExecutionWindow : Window
    {
        private IPEndPoint clientie;
        private Socket socket;
        private Socket client;

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
            socket = seConnecter();
            client = AccepterConnexion(socket);
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
            int maxFileSizeInKb = UserProperties.Default.MaxSizeFile; // en Mo
            maxFileSizeInKb = maxFileSizeInKb * 1024;
            var decorators = lbResults.Items.Cast<ItemDecorator>().ToList();

            Save[] listSaves = new Save[decorators.Count];
            for (int i = 0; i < decorators.Count; i++)
            {
                listSaves[i] = decorators[i].Item;
            }

            var tasks = decorators.Select(async decorator =>
            {
                var item = decorator.Item;
                Directory.CreateDirectory(item.FilesTarget);

                var allFiles = Directory.GetFiles(item.FilesSource);
                string[] priorityExtensions = UserProperties.Default.PriorityFiles.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries); // Extensions prioritaires
                string[] cryptExtensions = UserProperties.Default.EncryptedExtensions.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries); // Extensions à chiffrer
                var orderedFiles = allFiles.OrderBy(file =>
                {
                    var extension = System.IO.Path.GetExtension(file).ToLower();
                    var index = Array.IndexOf(priorityExtensions, extension);
                    return index < 0 ? int.MaxValue : index;
                });

                /*
                 * Création des timer et DailyLog
                 */
                
                Stopwatch _stopWatch = new Stopwatch();
                _stopWatch.Start();
                long cryptedTimeStart;
                long cryptedTime = 0;
                for (int i = 0; i < orderedFiles.Count(); i++)
                {
                    await CheckForBlockingAppsAsync();
                    _pauseEvent.Wait();
                    if (_cts.IsCancellationRequested) break;

                    var file = orderedFiles.ElementAt(i);
                    var fileInfo = new FileInfo(file);
                    var totalFilesCount = orderedFiles.Count();

                    if (fileInfo.Length / 1024 <= maxFileSizeInKb)
                    {
                        var fileName = System.IO.Path.GetFileName(file);
                        var destFile = System.IO.Path.Combine(item.FilesTarget, fileName);


                        if (cryptExtensions.Contains(Path.GetExtension(file).ToLower()))
                        {
                            cryptedTimeStart = _stopWatch.ElapsedMilliseconds;
                            await CopyAndEncryptFileAsync(file, destFile, 255);
                            cryptedTime += (_stopWatch.ElapsedMilliseconds - cryptedTimeStart);
                        }
                        else
                        {
                            await CopyFileAsync(file, destFile);
                        }
                    }
                    decorator.ProgressValue = (double)(i + 1) / totalFilesCount * 100;
                    string a = "";
                    foreach(ItemDecorator dec in decorators)
                    {
                        a += dec.Item.Name + " : " + dec.ProgressValue + ";";
                    }
                    try
                    {
                        byte[] data = new byte[1024];
                        data = Encoding.UTF8.GetBytes(a);
                        client.Send(data, data.Length, SocketFlags.None);
                    } catch { }
                }
                _stopWatch.Stop();
                long totTime = _stopWatch.ElapsedMilliseconds;
                DailyLog dailyLog = new DailyLog();
                dailyLog.SetDailyLogDataInJson(listSaves, totTime.ToString(),
                    cryptedTime.ToString());
                decorator.ProgressValue = 100;
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
            string[] blockingApps = { "notepad", "calculator" };
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

        private Socket seConnecter()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            Socket newSock = new Socket(AddressFamily.InterNetwork,
                                       SocketType.Stream,
                                       ProtocolType.Tcp);
            newSock.Bind(ipep);  // Le sucket se met ses paramètres (ports, IP...)
            newSock.Listen(10);
            return newSock;
        }
        private Socket AccepterConnexion(Socket socket)
        {
            Socket client = socket.Accept();

            clientie = (IPEndPoint)client.RemoteEndPoint;

            return client;
        }
        private void EcouterReseau(Socket client, string i)
        {
            byte[] data = new byte[1024];
            data = Encoding.UTF8.GetBytes(i);
            client.Send(data, data.Length, SocketFlags.None);
        }
    }
}