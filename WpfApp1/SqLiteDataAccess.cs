using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using WpfApp1.Models;

namespace WpfApp1
{
    public class SqLiteDataAccess
    {
        public static List<FullModel> LoadData()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                List<FullModel> fullModels = (List<FullModel>)conn.Query<FullModel>("select * from Abonents join Addreses on Addreses.AbonentId = Abonents.Id join Streets on Streets.Id = Addreses.StreetId join PhoneNumbers on PhoneNumbers.AbonentId = Abonents.Id", new DynamicParameters());
                return fullModels;
            }
        }

        //public static void SaveAbonent(Abonent abonent)
        //{
        //    using (IDbConnection conn = new SqliteConnection(LoadConnectionString()))
        //    {
        //        conn.Execute("insert into Abonement (Name, SurName) values (@Name, @SurName)", abonent);
        //    }
        //}
        private static string LoadConnectionString(string id = "DefaultConnection")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
