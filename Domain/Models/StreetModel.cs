using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneCompany.Domain.Models
{
    public class StreetModel : INotifyPropertyChanged
    {
        public int id;

        public string streetName;

        public string info;

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
