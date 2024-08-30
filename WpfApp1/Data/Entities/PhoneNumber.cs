using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneCompany.Entities
{
    public class PhoneNumber
    {
        public int AbonentId { get; set; }

        [ForeignKey(nameof(AbonentId))]
        public Abonent Abonent { get; set; }


        public string HomePhone { get; set; }

        public string WorkPhone { get; set; }

        public string MobilePhone { get; set; }
    }
}
