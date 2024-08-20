using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.Data;
using Dapper;

namespace WpfApp1
{
    public class SqLiteInMemoryDb
    {
        const string connectionString = "Data Source=InMemorySample;Mode=Memory;Cache=Shared";

    }
}
