using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class AddressModel : INotifyPropertyChanged
    {
        public int streetId;

        public int abonementId;

        public int numberHouse;

        public int StreetId
        {
            get { return streetId; }
            set
            {
                streetId = value;
                OnPropertyChanged("StreetId");
            }
        }
        public int AbonementId
        {
            get { return abonementId; }
            set
            {
                abonementId = value;
                OnPropertyChanged("AbonementId");
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
