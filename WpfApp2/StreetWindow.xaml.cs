using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для StreetWindow.xaml
    /// </summary>
    public partial class StreetWindow : Window
    {
        public StreetWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
