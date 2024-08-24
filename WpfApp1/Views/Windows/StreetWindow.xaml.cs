using PhoneCompany.ViewModels;
using System.Data.SQLite;
using System.Linq;
using System.Windows;

namespace PhoneCompany.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для StreetWindow.xaml
    /// </summary>
    public partial class StreetWindow : Window
    {
        public StreetWindow(SQLiteConnection Connection)
        {
            InitializeComponent();
            DataContext = new StreetWindowViewModel(Connection);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
