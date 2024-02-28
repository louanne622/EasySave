using System.Windows;
using EasySaveV3._0.Models;
using EasySaveV3._0.ViewModels;
using Microsoft.Win32;

namespace EasySaveV3._0.Views
{
    /// <summary>
    /// Logique d'interaction pour EditSaveView.xaml
    /// </summary>
    public partial class EditSaveView : Window
    {
        public EditSaveView()
        {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;
        }
        public EditSaveView(Save save)
        {
            InitializeComponent();
            DataContext = Application.Current.MainWindow.DataContext;

            // Ici le TextBox ne sert à rien, mais si je n'en met pas, ça n'affiche pas le nom de la sauvegarde
            //                                          \(°_°)/
            MessageBox.Show("Attention, vous allez modifier une sauvegarde.");
            this.txtBackupName.Text = save.Name;
            this.selectedPathSource.Text = save.FilesSource;
            this.selectedPathTarget.Text = save.FilesTarget;
            Json.setDataSave(save.Name, save.FilesSource, save.FilesTarget);
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
                    this.selectedPathSource.Text = folderPath;
                }
                else if (sender == browseButtonTarget)
                {
                    this.selectedPathTarget.Text = folderPath;
                }
            }
        }
    }
}
