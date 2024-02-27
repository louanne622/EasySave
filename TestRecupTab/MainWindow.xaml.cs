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

namespace TestRecupTab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var items = new List<Item>
            {
                new Item { Nom = "Save Test", Source = @"C:\Users\CESI\Desktop\Test\Source", Cible = @"C:\Users\CESI\Desktop\Test\Cible", Type = "Complète" },
                new Item { Nom = "Save Test2", Source = @"C:\Users\CESI\Desktop\Test\Source1", Cible = @"C:\Users\CESI\Desktop\Test\Cible1", Type = "Complète" },
                new Item { Nom = "Save 3", Source = "Source 2", Cible = "Cible 2", Type = "Type 2" },
            };

            lvItems.ItemsSource = items;
        }

        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = lvItems.SelectedItems;
            var resultsWindow = new SecondWindow(selectedItems);
            resultsWindow.Show();
        }
    }

    public class Item
    {
        public string Nom { get; set; }
        public string Source { get; set; }
        public string Cible { get; set; }
        public string Type { get; set; }
        public override string ToString()
        {
            return $"{Nom} - {Source} - {Cible} - {Type}";
        }
    }
}

