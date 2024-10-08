﻿using System;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public string Password
        {
            get { return passwordBox.Text; }
        }

        public SearchWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (Password.Length == 9 || Password.Length == 5 && Password != null)
            {
                bool result = long.TryParse(Password, out var number); //проверка номера на цифры
                if (result == true)
                {
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Не корректный номер телефона!");
                    Close();
                }
            }
            else 
            {
                MessageBox.Show("Не корректный номер телефона!");
                Close();
            }
        }
    }
}
