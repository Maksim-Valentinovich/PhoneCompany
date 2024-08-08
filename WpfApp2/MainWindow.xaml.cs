using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable phonesTable;

        public MainWindow()
        {
            InitializeComponent();
            //connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            LoadTable();
        }

        IDbConnection GetConnection()
        {
            return new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyApp1;Integrated Security=true;");
        }

        private void LoadTable()
        {
            //try
            //{
            //    using (IDbConnection conn = GetConnection())
            //    {
            //        // IEnumerable<Customer>
            //        var customer = conn.Query<Customer>("SELECT * FROM Customers");
            //        dtaGrid.ItemsSource = customer;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Database Error: " + ex.Message, "DapperPusherYouTube", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Abonement";
            phonesTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InsertPhone", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@title", SqlDbType.NVarChar, 50, "Title"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@company", SqlDbType.NVarChar, 50, "Company"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.Int, 0, "Price"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(phonesTable);
                phonesGrid.ItemsSource = phonesTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void SearcButton_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.Owner = this;


            if (searchWindow.ShowDialog() == true)
            {
                if (searchWindow.Password != null)
                {
                    //тут должен быть поиск в бд по номеру
                    //MessageBox.Show("Авторизация пройдена");
                }
                else
                    MessageBox.Show("Нет абонентов, удовлетворяющих критерию поиска");
            }
            else
            {
                searchWindow.Close();
            }
        }
        private void ScvButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void StreetButton_Click(object sender, RoutedEventArgs e)
        {
            StreetWindow streetWindow = new StreetWindow();
            streetWindow.ShowDialog();
        }
    }
}
