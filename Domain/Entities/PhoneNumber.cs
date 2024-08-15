using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneCompany.Domain.Entities
{
    public class PhoneNumber : Entity
    {
        public int AbonentId { get; set; }

        [ForeignKey(nameof(AbonentId))]
        public required Abonent Abonent { get; set; }


        public required string HomePhone { get; set; }

        public required string WorkPhone { get; set; }

        public required string MobilePhone { get; set; }
    }
}
