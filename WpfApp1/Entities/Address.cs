using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.Entities
{
    public class Address
    {
        public int StreetId { get; set; }

        [ForeignKey(nameof(StreetId))]
        public Street Street { get; set; }

        public int AbonementId { get; set; }

        [ForeignKey(nameof(AbonementId))]
        public Abonent Abonent { get; set; }

        public int NubmerHouse { get; set; }
    }
}
