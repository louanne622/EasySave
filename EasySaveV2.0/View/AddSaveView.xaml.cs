using Microsoft.Win32;
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


namespace EasySaveV2._0
{
    /// <summary>
    /// Logique d'interaction pour AddReservationView.xaml
    /// </summary>
    public partial class AddSaveView : Window
    {
        public AddSaveView()
        {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;
        }

        private void OnBrowseButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ValidateNames = false;
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;
            openFileDialog.FileName = "Sélectionner ce dossier";

            if (openFileDialog.ShowDialog() == true)
            {
                string folderPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);

                if (sender == browseButtonSource)
                {
                    (DataContext as SaveViewModel).NewSourcePath = folderPath;
                    selectedPathSource.Content = $"Chemin sélectionné : {folderPath}";
                }
                else if (sender == browseButtonTarget)
                {
                    (DataContext as SaveViewModel).NewTargetPath = folderPath;
                    selectedPathTarget.Content = $"Chemin sélectionné : {folderPath}";
                }
            }
        }
    }
}