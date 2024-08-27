using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneCompany.Models
{
    public class StreetModel : INotifyPropertyChanged
    {
        private int id;

        private string streetName;

        private string info;

        private int count;

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
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
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
