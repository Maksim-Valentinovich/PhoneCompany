using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.Models
{
    public class FullModel : INotifyPropertyChanged
    {
        public string name;

        public string surname;

        public string middleName;
        public string FullName => $"{surname} {name} {middleName}";

        public int homePhone;

        public int mobilePhone;

        public int workPhone;

        public string streetName;

        public int numberHouse;

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

        public int HomePhone
        {
            get { return homePhone; }
            set
            {
                homePhone = value;
                OnPropertyChanged("HomePhone");
            }
        }

        public int MobilePhone
        {
            get { return mobilePhone; }
            set
            {
                mobilePhone = value;
                OnPropertyChanged("MobilePhone");
            }
        }

        public int WorkPhone
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
