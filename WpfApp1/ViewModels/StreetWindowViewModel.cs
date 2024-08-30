using Dapper;
using PhoneCompany.Data;
using PhoneCompany.Models;
using PhoneCompany.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;

namespace PhoneCompany.ViewModels
{
    public class StreetWindowViewModel : ViewModel
    {
        public List<StreetModel> Streets { get; set; }

        public StreetWindowViewModel()
        {
            SortAbonent();
        }

        public void SortAbonent()
        {
            List<FullModel> Abonents = (List<FullModel>)SqLiteDataAccess.Connection.Query<FullModel>("select * from Abonents join Addreses on Addreses.AbonentId = Abonents.Id join Streets on Streets.Id = Addreses.StreetId", new DynamicParameters());

            Streets = Abonents.GroupBy(x => x.StreetName).Select(g => new StreetModel { StreetName = g.Key, Count = g.Count(), Info = "Информация о улице" }).OrderByDescending(z => z.Count).ToList();

        }

    }
}
