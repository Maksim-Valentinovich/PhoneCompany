using System.Windows;

namespace PhoneCompany.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public string PhoneNumber
        {
            get { return phoneNumberBox.Text; }
        }

        public SearchWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneNumber.Length == 9 || PhoneNumber.Length == 5 && PhoneNumber != null)
            {
                bool result = long.TryParse(PhoneNumber, out var number); //проверка номера на цифры
                if (result == true)
                {
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Не корректный номер телефона!");
                }
            }
            else
            {
                MessageBox.Show("Не корректный номер телефона!");
            }
        }
    }
}
