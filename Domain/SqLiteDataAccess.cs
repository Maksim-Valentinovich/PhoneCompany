using Dapper;
using Microsoft.Data.Sqlite;
using PhoneCompany.Domain.Entities;
using System.Configuration;
using System.Data;

namespace PhoneCompany.Domain
{
    public class SqLiteDataAccess
    {
        public static List<Abonent> LoadAbonent()
        {
            using (IDbConnection conn = new SqliteConnection(LoadConnectionString()))
            {   // using Dapper
                var output = conn.Query<Abonent>("select * from Abonement order by Id desc", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SaveAbonent(Abonent abonent)
        {
            using (IDbConnection conn = new SqliteConnection(LoadConnectionString()))
            {
                conn.Execute("insert into Abonement (Name, SurName) values (@Name, @SurName)", abonent);
            }
        }
        private static string LoadConnectionString(string id = "DefaultConnection")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
