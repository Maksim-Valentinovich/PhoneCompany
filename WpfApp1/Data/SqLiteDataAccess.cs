using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using PhoneCompany.Models;

namespace PhoneCompany.Data
{
    public class SqLiteDataAccess
    {
        public static SQLiteConnection Connection;


        public static List<FullModel> LoadData()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                List<FullModel> fullModels = (List<FullModel>)conn.Query<FullModel>("select * from Abonents join Addreses on Addreses.AbonentId = Abonents.Id join Streets on Streets.Id = Addreses.StreetId join PhoneNumbers on PhoneNumbers.AbonentId = Abonents.Id", new DynamicParameters());
                return fullModels;
            }
        }

        private static string LoadConnectionString(string id = "DefaultConnection")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static SQLiteConnection CreateConnectionDB()
        {
            Connection = new SQLiteConnection("Data Source=:memory:;Mode=Memory");
            Connection.Open();
            return Connection;
        }



        public static SQLiteConnection SqlDataFromDB()
        {
            var connection = CreateConnectionDB();

            var command = connection.CreateCommand();

            command.CommandText = "CREATE TABLE Abonents (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT , Surname TEXT, MiddleName TEXT)";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE Streets (Id INTEGER PRIMARY KEY AUTOINCREMENT, StreetName TEXT, Info TEXT)";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE PhoneNumbers (AbonentId INTEGER REFERENCES Abonents (Id), HomePhone TEXT, WorkPhone TEXT, MobilePhone TEXT )";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE Addreses (StreetId INTEGER REFERENCES Streets (Id), AbonentId INTEGER REFERENCES Abonents (Id), NumberHouse INTEGER)";
            command.ExecuteNonQuery();


            List<AbonentModel> abonentModels;
            List<StreetModel> streetModels;
            List<PhoneModel> phoneModels;
            List<AddressModel> addressModels;

            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                abonentModels = (List<AbonentModel>)conn.Query<AbonentModel>("select * from Abonents", new DynamicParameters());
                streetModels = (List<StreetModel>)conn.Query<StreetModel>("select * from Streets", new DynamicParameters());
                phoneModels = (List<PhoneModel>)conn.Query<PhoneModel>("select * from PhoneNumbers", new DynamicParameters());
                addressModels = (List<AddressModel>)conn.Query<AddressModel>("select * from Addreses", new DynamicParameters());
            }

            for (int i = 0; i < abonentModels.Count; i++)
            {
                command.CommandText = "INSERT INTO Abonents (Name,Surname,MiddleName) " + "VALUES ('" + abonentModels[i].Name + "','" + abonentModels[i].Surname + "','" + abonentModels[i].MiddleName + "')";
                command.ExecuteNonQuery();
            }
            for (int i = 0; i < streetModels.Count; i++)
            {
                command.CommandText = "INSERT INTO Streets (StreetName,Info) " + "VALUES ('" + streetModels[i].StreetName + "','" + streetModels[i].Info + "')";
                command.ExecuteNonQuery();
            }
            for (int i = 0; i < phoneModels.Count; i++)
            {
                command.CommandText = "INSERT INTO PhoneNumbers (AbonentId,HomePhone,WorkPhone,MobilePhone) " + "VALUES ('" + phoneModels[i].AbonentId + "','" + phoneModels[i].HomePhone + "','" + phoneModels[i].WorkPhone + "','" + phoneModels[i].MobilePhone + "')";
                command.ExecuteNonQuery();
            }
            for (int i = 0; i < addressModels.Count; i++)
            {
                command.CommandText = "INSERT INTO Addreses (StreetId,AbonentId,NumberHouse) " + "VALUES ('" + addressModels[i].StreetId + "','" + addressModels[i].AbonentId + "','" + addressModels[i].NumberHouse + "')";
                command.ExecuteNonQuery();
            }

            return connection;
        }

        public static SQLiteConnection SqlDataNew()
        {
            string[] names = { "Максим", "Валентин", "Светлана", "Дарья", "Ксения", "Ольга", "Александр", "Пётр", "Антон", "Сергей", "Владислав", "Виктор", "Михаил", "Оксана", "Георгий" };
            string[] surNames = { "Иванов", "Петров", "Сидоров", "Баринов", "Баннов", "Седов", "Васильков", "Барёзкин", "Фролов", "Сысоев", "Николаев", "Баев" };
            string[] middleNames = { "Максимович", "Валентинович", "Герогиевич", "Александрович", "Пётрович", "Антонович", "Сергеевич", "Владиславович", "Викторович", "Михаилович", "Георгиевич" };
            string[] streets = { "Ленина", "Гагарина", "Дьяконова", "Егорова", "Сенная", "Дыбенко", "Большевиков" };

            Random rnd = new Random();
            var connection = CreateConnectionDB();
            var command = connection.CreateCommand();

            command.CommandText = "CREATE TABLE Abonents (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT , Surname TEXT, MiddleName TEXT)";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE Streets (Id INTEGER PRIMARY KEY AUTOINCREMENT, StreetName TEXT, Info TEXT)";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE PhoneNumbers (AbonentId INTEGER REFERENCES Abonents (Id), HomePhone TEXT, WorkPhone TEXT, MobilePhone TEXT )";
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE Addreses (StreetId INTEGER REFERENCES Streets (Id), AbonentId INTEGER REFERENCES Abonents (Id), NumberHouse INTEGER)";
            command.ExecuteNonQuery();


            for (int i = 0; i < 10; i++)
            {
                command.CommandText = "INSERT INTO Abonents (Name,Surname,MiddleName) " + "VALUES ('" + names[rnd.Next(0, names.Length)] + "','" + surNames[rnd.Next(0, surNames.Length)] + "','" + middleNames[rnd.Next(0, middleNames.Length)] + "')";
                command.ExecuteNonQuery();
            }
            for (int i = 0; i < 7; i++)
            {
                command.CommandText = "INSERT INTO Streets (StreetName) " + "VALUES ('" + streets[rnd.Next(0, streets.Length)] + "')";
                command.ExecuteNonQuery();
            }
            for (int i = 1; i < 10; i++)
            {
                command.CommandText = "INSERT INTO PhoneNumbers (AbonentId,HomePhone,WorkPhone,MobilePhone) " + "VALUES ('" + i + "','" + rnd.Next(1, 10) + rnd.Next(1, 10) + rnd.Next(1, 10) + rnd.Next(1, 10) + rnd.Next(1, 10) + "','" + 8911 + rnd.Next(1, 10) + rnd.Next(1, 10) + rnd.Next(1, 10) + rnd.Next(1, 10) + rnd.Next(1, 10) + "','" + 8911 + rnd.Next(1, 10) + rnd.Next(1, 10) + rnd.Next(1, 10) + rnd.Next(1, 10) + rnd.Next(1, 10) + rnd.Next(1, 10) + "')";
                command.ExecuteNonQuery();
            }
            for (int i = 1; i < 10; i++)
            {
                command.CommandText = "INSERT INTO Addreses (StreetId,AbonentId,NumberHouse) " + "VALUES ('" + rnd.Next(1, 10) + "','" + i + "','" + rnd.Next(1, 100) + "')";
                command.ExecuteNonQuery();
            }

            return connection;
        }
    }
}
