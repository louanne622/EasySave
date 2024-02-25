using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace TestLogicielMetier.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private string statusMessage = "Statut du travail";
        public string StatusMessage
        {
            get { return statusMessage; }
            set { statusMessage = value; OnPropertyChanged(); }
        }

        private DispatcherTimer timer = new DispatcherTimer();
        private int workCount = 0;
        private string[] monitoredApps = { "notepad", "calc" };

        public ApplicationViewModel()
        {
            SetupTimer();
        }

        private void SetupTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (IsMonitoredAppRunning())
            {
                StatusMessage = "Travail en pause... (Application détectée)";
            }
            else
            {
                workCount++;
                StatusMessage = $"Travail {workCount} fait";
                // Ajoutez ici le code pour le travail réel à effectuer
            }
        }

        private bool IsMonitoredAppRunning()
        {
            foreach (var appName in monitoredApps)
            {
                var processes = Process.GetProcessesByName(appName);
                if (processes.Length > 0) return true;
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}