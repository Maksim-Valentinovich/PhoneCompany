using Dapper;
using PhoneCompany.Models;
using PhoneCompany.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;

namespace PhoneCompany.ViewModels
{
    public class StreetWindowViewModel : ViewModel
    {
        public ObservableCollection<FullModel> Streets { get; set; }
        private ObservableCollection<FullModel> Abonents { get; set; }

        public StreetWindowViewModel(SQLiteConnection Connection)
        {
            Abonents = new ObservableCollection<FullModel>((List<FullModel>)Connection.Query<FullModel>("select * from Abonents join Addreses on Addreses.AbonentId = Abonents.Id join Streets on Streets.Id = Addreses.StreetId join PhoneNumbers on PhoneNumbers.AbonentId = Abonents.Id", new DynamicParameters()));
            SortAbonent(Abonents);
        }

        public void SortAbonent(ObservableCollection<FullModel> Abonents)
        {
            Streets = (ObservableCollection<FullModel>)Abonents.GroupBy(x => x.StreetName).Select(g => new { StreetName = g.Key, Count = g.Count() });
        }

    }
}
