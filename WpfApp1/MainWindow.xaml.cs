using CsvHelper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<FullModel> fullModels = new List<FullModel>();
        private List<FullModel> findModel = new List<FullModel>();
        public MainWindow()
        {
            InitializeComponent();
            //LoadData();
            //SeeData();
            SqlDataNew();
            phonesGrid.ItemsSource = fullModels;
        }

        private List<FullModel> LoadData()
        {
            return fullModels = SqLiteDataAccess.LoadData();
        }

        private void SeeData()
        {
            var connection = SqLiteDataAccess.SqlDataFromDB();
            fullModels = (List<FullModel>)connection.Query<FullModel>("select * from Abonents join Addreses on Addreses.AbonentId = Abonents.Id join Streets on Streets.Id = Addreses.StreetId join PhoneNumbers on PhoneNumbers.AbonentId = Abonents.Id", new DynamicParameters());
        }

        private void SqlDataNew()
        {
            var connection = SqLiteDataAccess.SqlDataNew();
            fullModels = (List<FullModel>)connection.Query<FullModel>("select * from Abonents join Addreses on Addreses.AbonentId = Abonents.Id join Streets on Streets.Id = Addreses.StreetId join PhoneNumbers on PhoneNumbers.AbonentId = Abonents.Id", new DynamicParameters());
        }

        private void RefrashButton_Click(object sender, RoutedEventArgs e) 
        {
            findModel = new List<FullModel>();
            phonesGrid.ItemsSource = fullModels;
        }
        private void SearcButton_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();

            if (searchWindow.ShowDialog() == true)
            {
                if (fullModels.Any(s => s.HomePhone == searchWindow.Password))
                {
                    findModel.Add(fullModels.Find(x => x.HomePhone == searchWindow.Password || x.WorkPhone == searchWindow.Password || x.MobilePhone == searchWindow.Password));
                    phonesGrid.ItemsSource = findModel;
                }
                else
                {
                    MessageBox.Show("Нет абонентов, удовлетворяющих критерию поиска");
                }
            }
            else
            {
                searchWindow.Close();
            }
        }
        private void ScvButton_Click(object sender, RoutedEventArgs e)
        {
            string pathCsvFile = $"C:\\Users\\Alexandr\\Desktop\\Тестовые задания\\Владимир\\Telephone Company\\TelephoneCompany\\Выгрузка файлов\\report_{DateTime.Now:yyyy-MM-dd HH.mm.ss}.csv";

            try
            {
                using (var writer = new StreamWriter(pathCsvFile))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(fullModels);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла ошибка!");
            }
            finally
            {
                MessageBox.Show("Выполнено!");
            }
        }
        private void StreetButton_Click(object sender, RoutedEventArgs e)
        {
            StreetWindow streetWindow = new StreetWindow();
            streetWindow.ShowDialog();
        }
    }
}