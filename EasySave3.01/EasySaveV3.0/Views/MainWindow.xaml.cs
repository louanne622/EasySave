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
using EasySaveV3._0.ViewModels;
using EasySaveV3._0.Models;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Save[] savesList = Json.getSavesFromJson();
            Save newSave = new Save("dg", "bla", "bla");

            //savesList = Json.getNewSaveList(savesList, newSave);
            savesList = Json.UpdateSaveList(savesList, savesList[1], "dg", "", "");

        }
    }
}