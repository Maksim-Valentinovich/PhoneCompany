using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneCompany.Domain.Entities
{
    public class Abonent : Entity
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }

        public string? MiddleName { get; set; }

        [NotMapped]
        public string FullName => $"{Surname} {Name} {MiddleName}";

        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public required Address Address { get; set; }
    }
}
