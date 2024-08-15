using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.Entities
{
    public class Abonent : Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        [NotMapped]
        public string FullName => $"{Surname} {Name} {MiddleName}";

    }
}
