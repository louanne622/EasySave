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
using System.IO;
using Microsoft.Win32;

namespace TestOpenDirectory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnBrowseButtonClick(object sender, RoutedEventArgs e)
        {
            // Utilisation d'OpenFileDialog à la place de FolderBrowserDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ValidateNames = false;
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;
            // Permettre à l'utilisateur de sélectionner un dossier en définissant le nom de fichier sur un libellé spécifique
            openFileDialog.FileName = "Sélectionner ce dossier";
            if (openFileDialog.ShowDialog() == true)
            {
                // Extraire le chemin du dossier à partir du chemin du fichier sélectionné
                string folderPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                pathTextBox.Text = folderPath;
                selectedPathLabel.Content = $"Chemin sélectionné : {folderPath}";
            }
        }

    }
}
