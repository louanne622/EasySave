using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace TabControlExample
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private SolidColorBrush _gridBackground;

        public SolidColorBrush GridBackground
        {
            get { return _gridBackground; }
            set
            {
                _gridBackground = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Set initial theme
            ToggleTheme(false);
        }

        private void ToggleTheme(bool isDarkMode)
        {
            if (isDarkMode)
            {
                GridBackground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                GridBackground = new SolidColorBrush(Colors.White);
            }
        }

        private void ToggleDarkMode_Click(object sender, RoutedEventArgs e)
        {
            ToggleTheme(true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}