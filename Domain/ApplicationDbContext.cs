using System.Collections.Generic;

namespace PhoneCompany.Domain
{
    public class ApplicationDbContext : IUserRepository
    {
        private string connectionString = string.Empty;

        public ApplicationDbContext(string conn)
        {
            connectionString = conn;
        }

        //public DbSet<Employee> Employees { get; set; }

        //public ApplicationDbContext(DbContextOptions options) : base(options)
        //{
        //}
    }
}
