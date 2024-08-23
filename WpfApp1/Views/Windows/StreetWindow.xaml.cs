using System.Linq;
using System.Windows;

namespace PhoneCompany.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для StreetWindow.xaml
    /// </summary>
    public partial class StreetWindow : Window
    {
        public StreetWindow()
        {
            InitializeComponent();
            SortAbonent();
        }

        private void SortAbonent()
        {
            phonesGrid.ItemsSource = MainWindow.fullModels.GroupBy(x => x.StreetName).Select(g => new { StreetName = g.Key, Count = g.Count() });
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
