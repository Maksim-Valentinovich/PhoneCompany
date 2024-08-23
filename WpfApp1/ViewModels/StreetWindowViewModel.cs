using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PhoneCompany.ViewModels
{
    public class StreetWindowViewModel : INotifyPropertyChanged
    {
        public ICommand MakeScvFileCommand { get; }

        private bool CanMakeScvFileCommandExecute(object p) => true;
        private void OnMakeScvFileCommandExecute(object p)
        {
        }

        private int id;

        private string streetName;

        private string info;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string StreetName
        {
            get { return streetName; }
            set
            {
                streetName = value;
                OnPropertyChanged("StreetName");
            }
        }
        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
