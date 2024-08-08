using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    //public partial class SearchWindow : Window
    //{
    //    public SearchWindow()
    //    {
    //        InitializeComponent();
    //    }


    //    private void Accept_Click(object sender, RoutedEventArgs e)
    //    {
    //        this.DialogResult = true;
    //    }

    //    public string Password
    //    {
    //        get { return passwordBox.Text; }
    //    }
    //}

    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
            LoadTable();
        }
        IDbConnection GetConnection()
        {
            return new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyApp1;Integrated Security=true;");
        }

        private void LoadTable()
        {
            try
            {
                using (IDbConnection conn = GetConnection())
                {
                    // IEnumerable<Customer>
                    var customer = conn.Query<Abonent>("SELECT * FROM Customers");
                    dtaGrid.ItemsSource = customer;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Database Error: " + ex.Message, "DapperPusherYouTube", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string Password
        {
            get { return passwordBox.Text; }
        }
    }
}
