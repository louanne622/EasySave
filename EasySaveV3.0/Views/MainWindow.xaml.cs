using System.Windows;
using EasySaveV3._0.ViewModels;

namespace EasySaveV3._0.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new
            {
                paramView = new SettingsViewModel(),
                saveView = new SaveViewModel()
            };
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var SelectedItems = SaveListL.SelectedItems;
            var resultWindow = new ExecutionWindow(SelectedItems);
            resultWindow.Show();
        }
    }
}