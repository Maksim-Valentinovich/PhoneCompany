using CsvHelper;
using Dapper;
using PhoneCompany.Commands;
using PhoneCompany.Models;
using PhoneCompany.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace PhoneCompany.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public List<FullModel> Abonents { get; set; }

        public void MainViewModel(SQLiteConnection connection)
        {
            Abonents = (List<FullModel>)connection.Query<FullModel>("select * from Abonents join Addreses on Addreses.AbonentId = Abonents.Id join Streets on Streets.Id = Addreses.StreetId join PhoneNumbers on PhoneNumbers.AbonentId = Abonents.Id", new DynamicParameters());
        }

        public MainWindowViewModel() 
        {
            MakeScvFileCommand = new LambdaCommand(OnMakeScvFileCommandExecute, CanMakeScvFileCommandExecute);

        }

        public ICommand MakeScvFileCommand { get; }

        private bool CanMakeScvFileCommandExecute(object p) => true;
        private void OnMakeScvFileCommandExecute(object p) 
        {
            string pathCsvFile = $"C:\\Users\\Alexandr\\Desktop\\Тестовые задания\\Владимир\\Telephone Company\\TelephoneCompany\\Выгрузка файлов\\report_{DateTime.Now:yyyy-MM-dd HH.mm.ss}.csv";

            try
            {
                using (var writer = new StreamWriter(pathCsvFile))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    //csv.WriteRecords(fullModels);

                    MainWindowViewModel windowModel = new MainWindowViewModel();
                    csv.WriteRecords(windowModel.Abonents);
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


        private string title = "Список абонентов";

        private string name;

        private string surname;

        private string middleName;
        public string FullName => $"{surname} {name} {middleName}";

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }
    }
}
