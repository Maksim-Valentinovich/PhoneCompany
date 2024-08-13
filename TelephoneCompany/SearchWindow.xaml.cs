using Dapper;
using Microsoft.Data.SqlClient;
using PhoneCompany.Domain;
using PhoneCompany.Domain.Entities;
using PhoneCompany.Domain.Models;
using System.Data;
using System.Windows;

namespace TelephoneCompany
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
    //IDbConnection GetConnection()
    //{
    //    return new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=phoneCompany;Integrated Security=true;");
    //}

    //private void LoadTable()
    //{
    //    try
    //    {
    //        using (IDbConnection conn = GetConnection())
    //        {
    //            // IEnumerable<Customer>
    //            var customer = conn.Query<Abonent>("SELECT * FROM Customers");
    //            dtaGrid.ItemsSource = customer;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        System.Windows.MessageBox.Show("Database Error: " + ex.Message, "DapperPusherYouTube", MessageBoxButton.OK, MessageBoxImage.Warning);
    //    }
    //}

    public partial class SearchWindow : Window
    {
        List<Abonent> abonents = [];
        public SearchWindow()
        {
            InitializeComponent();
            LoadAbonent();
        }

        private void LoadAbonent() 
        {
            abonents = SqLiteDataAccess.LoadAbonent();
            WireUpPeopleList();
        }
        private void WireUpPeopleList()
        {
            // attach the in-memory list (people) to the ListBox for display
            //listPeopleListBox.ItemsSource = null; // important to first make null
            //listPeopleListBox.ItemsSource = abonents;
        }


        private void Accept_Click(object sender, RoutedEventArgs e )
        {
            this.DialogResult = true;
        }

        public string Password
        {
            get { return passwordBox.Text; }
        }
    }
}
