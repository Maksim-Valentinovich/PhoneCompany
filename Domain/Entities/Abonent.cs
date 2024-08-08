using OutCode.EscapeTeams.ObjectRepository;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneCompany.Domain.Entities
{
    public class Abonent : Entity /*BaseEntity*/
    {
        //public Abonent(Guid id) 
        //{
        //    Id = id;
        //}

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? MiddleName { get; set; }

        [NotMapped]
        public string FullName => $"{Surname} {Name} {MiddleName}";

    }
}
