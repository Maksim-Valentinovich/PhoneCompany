using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.Entities
{
    public class PhoneNumber : Entity
    {

        public int AbonentId { get; set; }

        [ForeignKey(nameof(AbonentId))]
        public Abonent Abonent { get; set; }


        public int HomePhone { get; set; }

        public int WorkPhone { get; set; }

        public int MobilePhone { get; set; }
    }
}
