using OutCode.EscapeTeams.ObjectRepository;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneCompany.Domain.Entities
{
    public class Address
    {
        public int StreetId { get; set; }

        [ForeignKey(nameof(StreetId))]
        public required Street Street { get; set; }

        public int AbonementId { get; set; }

        [ForeignKey(nameof(AbonementId))]
        public required Abonent Abonent { get; set; }

        public int NubmerHouse { get; set; }
    }
}
