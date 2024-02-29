using System;
using System.Windows;
using Microsoft.Win32;

namespace EasySaveV3._0.Views
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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Sélectionner ce dossier"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string folderPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                if (sender == browseButtonSource)
                {
                    this.txtSourceFile.Text = folderPath;
                }
                else if (sender == browseButtonTarget)
                {
                    this.txtDestinationFile.Text = folderPath;
                }
            }
        }
    }
}