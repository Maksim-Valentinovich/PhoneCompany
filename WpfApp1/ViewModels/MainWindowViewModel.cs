using CsvHelper;
using Dapper;
using PhoneCompany.Commands;
using PhoneCompany.Data;
using PhoneCompany.Models;
using PhoneCompany.ViewModels.Base;
using PhoneCompany.Views.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace PhoneCompany.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {

        public ObservableCollection<FullModel> Abonents { get; set; }

        public MainWindowViewModel() 
        {
            var connection = SqLiteDataAccess.SqlDataNew();
            Abonents = new ObservableCollection<FullModel>((List<FullModel>)connection.Query<FullModel>("select * from Abonents join Addreses on Addreses.AbonentId = Abonents.Id join Streets on Streets.Id = Addreses.StreetId join PhoneNumbers on PhoneNumbers.AbonentId = Abonents.Id", new DynamicParameters()));
            
            MakeScvFileCommand = new LambdaCommand(OnMakeScvFileCommandExecute, CanMakeScvFileCommandExecute);
            ViewStreetCommand = new LambdaCommand(OnViewStreetExecute, CanViewStreetExecute);
            ReflashCommand = new LambdaCommand(OnReflashExecute, CanReflashExecute);
            SearchAbonentCommand = new LambdaCommand(OnSearchAbonentExecute, CanSearchAbonentExecute);
        }

        #region Команды
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
                    csv.WriteRecords(Abonents);
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

        public ICommand ViewStreetCommand { get; }
        private bool CanViewStreetExecute(object p) => true;
        private void OnViewStreetExecute(object p)
        {
            StreetWindow streetWindow = new StreetWindow();
            streetWindow.ShowDialog();
        }

        public ICommand ReflashCommand { get; }
        private bool CanReflashExecute(object p) => true;
        private void OnReflashExecute(object p)
        {

        }
        public ICommand SearchAbonentCommand { get; }
        private bool CanSearchAbonentExecute(object p) => true;
        private void OnSearchAbonentExecute(object p)
        {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.ShowDialog();
        }
        #endregion

        //#region Свойства
        //private string title = "Список абонентов";

        //private string name;

        //private string surname;

        //private string middleName;
        //public string FullName => $"{surname} {name} {middleName}";

        //private string homePhone;

        //private string mobilePhone;

        //private string workPhone;

        //private string streetName;

        //private int numberHouse;

        //public string Title
        //{
        //    get { return title; }
        //    set
        //    {
        //        title = value;
        //        OnPropertyChanged("Title");
        //    }
        //}
        //public string Name
        //{
        //    get { return name; }
        //    set
        //    {
        //        name = value;
        //        OnPropertyChanged("Name");
        //    }
        //}
        //public string Surname
        //{
        //    get { return surname; }
        //    set
        //    {
        //        surname = value;
        //        OnPropertyChanged("Surname");
        //    }
        //}
        //public string MiddleName
        //{
        //    get { return middleName; }
        //    set
        //    {
        //        middleName = value;
        //        OnPropertyChanged("MiddleName");
        //    }
        //}

        //public string StreetName
        //{
        //    get { return streetName; }
        //    set
        //    {
        //        streetName = value;
        //        OnPropertyChanged("StreetName");
        //    }
        //}
        //public int NumHouse
        //{
        //    get { return numberHouse; }
        //    set
        //    {
        //        numberHouse = value;
        //        OnPropertyChanged("NumHouse");
        //    }
        //}
        //public string HomePhone
        //{
        //    get { return homePhone; }
        //    set
        //    {
        //        homePhone = value;
        //        OnPropertyChanged("HomePhone");
        //    }
        //}
        //public string MobilePhone
        //{
        //    get { return mobilePhone; }
        //    set
        //    {
        //        mobilePhone = value;
        //        OnPropertyChanged("MobilePhone");
        //    }
        //}
        //public string WorkPhone
        //{
        //    get { return workPhone; }
        //    set
        //    {
        //        workPhone = value;
        //        OnPropertyChanged("WorkPhone");
        //    }
        //}
        //#endregion
    }
}
