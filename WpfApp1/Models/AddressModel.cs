using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneCompany.Models
{
    public class AddressModel : INotifyPropertyChanged
    {
        private int streetId;

        private int abonentId;

        private int numberHouse;

        public int StreetId
        {
            get { return streetId; }
            set
            {
                streetId = value;
                OnPropertyChanged("StreetId");
            }
        }
        public int AbonentId
        {
            get { return abonentId; }
            set
            {
                abonentId = value;
                OnPropertyChanged("AbonentId");
            }
        }

        public int NumberHouse
        {
            get { return numberHouse; }
            set
            {
                numberHouse = value;
                OnPropertyChanged("NumberHouse");
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
