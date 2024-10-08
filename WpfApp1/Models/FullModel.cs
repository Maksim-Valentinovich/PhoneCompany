﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneCompany.Models
{
    public class FullModel : INotifyPropertyChanged
    {
        private string name;

        private string surname;

        private string middleName;
        public string FullName => $"{surname} {name} {middleName}";

        private string homePhone;

        private string mobilePhone;

        private string workPhone;

        private string streetName;

        private int numberHouse;

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

        public string StreetName
        {
            get { return streetName; }
            set
            {
                streetName = value;
                OnPropertyChanged("StreetName");
            }
        }

        public int NumHouse
        {
            get { return numberHouse; }
            set
            {
                numberHouse = value;
                OnPropertyChanged("NumHouse");
            }
        }

        public string HomePhone
        {
            get { return homePhone; }
            set
            {
                homePhone = value;
                OnPropertyChanged("HomePhone");
            }
        }

        public string MobilePhone
        {
            get { return mobilePhone; }
            set
            {
                mobilePhone = value;
                OnPropertyChanged("MobilePhone");
            }
        }

        public string WorkPhone
        {
            get { return workPhone; }
            set
            {
                workPhone = value;
                OnPropertyChanged("WorkPhone");
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
