using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.Entities
{
    public class PhoneNumber : Entity
    {
        public int AbonentId { get; set; }

        [ForeignKey(nameof(AbonentId))]
        public Abonent Abonent { get; set; }


        public string HomePhone { get; set; }

        public string WorkPhone { get; set; }

        public string MobilePhone { get; set; }
    }
}
