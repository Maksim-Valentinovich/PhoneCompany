using Dapper;
using Microsoft.Data.Sqlite;
using PhoneCompany.Domain.Entities;
using PhoneCompany.Domain.Models;

namespace PhoneCompany.Domain
{
    public class AbonentRepository : BaseRepository , IAbonentRepository
    {
        public Task<FullModel> Get()
        {
            throw new NotImplementedException();
        }

        public List<FullModel> GetUsers()
        {
            var connection = new SqliteConnection("Data Source=:memory:; Mode=Memory");
            connection.Open();

            List<FullModel> fullModels = (List<FullModel>)connection.Query<FullModel>("select * from Abonents join Addreses on Addreses.AbonentId = Abonents.Id " +
                "join Streets on Streets.Id = Addreses.StreetId join PhoneNumbers on PhoneNumbers.AbonentId = Abonents.Id", new DynamicParameters());

            return fullModels;
        }

    }
}
