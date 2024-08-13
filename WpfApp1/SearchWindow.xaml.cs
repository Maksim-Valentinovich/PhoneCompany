using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using WpfApp1.Entities;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        //List<Abonent> abonents = new List<Abonent>();
        public SearchWindow()
        {
            InitializeComponent();
        }

        //private void LoadData(string number) 
        //{
        //    if (number != null)
        //    {

        //    }
        //    else MessageBox.Show("Нет абонентов, удовлетворяющих критерию поиска");
        //}

        private void Accept_Click(object sender, RoutedEventArgs e )
        {
            this.DialogResult = true;
            //LoadData(passwordBox.Text);
        }

        public string Password
        {
            get { return passwordBox.Text; }
        }
    }
}
