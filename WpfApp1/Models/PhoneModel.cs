using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.Models
{
    public class PhoneModel : INotifyPropertyChanged
    {
        public int abonentId;

        public string homePhone;

        public string workPhone;

        public string mobilePhone;

        public int AbonentId
        {
            get { return abonentId; }
            set
            {
                abonentId = value;
                OnPropertyChanged("AbonentId");
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
        public string WorkPhone
        {
            get { return workPhone; }
            set
            {
                workPhone = value;
                OnPropertyChanged("WorkPhone");
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


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
