using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp1.Models;

namespace WpfApp1.Views
{
    public class AbonentViewModel : INotifyPropertyChanged
    {

        //private AbonentModel selectedAbonentModel;

        public ObservableCollection<AbonentModel> AbonentModels { get; set; }

        //public AbonentModel SelectedAbonentModel
        //{
        //    get { return selectedAbonentModel; }
        //    set
        //    {
        //        selectedAbonentModel = value;
        //        OnPropertyChanged("SelectedAbonentModel");
        //    }
        //}

        public AbonentViewModel()
        {
            AbonentModels = new ObservableCollection<AbonentModel>
            {
                new AbonentModel {Name = "Максим", Surname = "Иванов", MiddleName = "Валентинович" },
            };
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
