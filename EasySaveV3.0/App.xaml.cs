using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;

namespace EasySaveV3._0
{

    public partial class App : Application
    {
        private static Mutex _mutex = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            const string appName = "EasySaveV3._0"; // A changer en fonction du nom du projet
            bool createdNew;

            _mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("Une instance de l'application est déjà en cours d'exécution.");
                Application.Current.Shutdown();
            }

            base.OnStartup(e);
        }
    }
}
