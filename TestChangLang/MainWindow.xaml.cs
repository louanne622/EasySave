using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace TestChangLang
{
    public partial class MainWindow : Window
    {
        // ResourceManager pour gérer le chargement des ressources localisées
        private static ResourceManager resManager = new ResourceManager("TestChangLang.Resources.Resources", typeof(MainWindow).Assembly);

        public MainWindow()
        {
            InitializeComponent();
            SetLanguage("fr");
        }

        private void SetLanguage(string culture)
        {
            // Change la culture courante de l'application
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            // Met à jour les éléments de l'interface utilisateur avec les valeurs localisées
            UpdateUI();
        }

        private void UpdateUI()
        {
            welcomeLabel.Content = resManager.GetString("WelcomeText");
        }

        private void OnChangeLanguage(object sender, RoutedEventArgs e)
        {
            string culture = (sender as Button)?.Tag.ToString();
            if (!string.IsNullOrEmpty(culture))
            {
                SetLanguage(culture);
            }
        }
    }
}
