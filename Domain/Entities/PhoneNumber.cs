using OutCode.EscapeTeams.ObjectRepository;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneCompany.Domain.Entities
{
    public class PhoneNumber : Entity /*BaseEntity*/
    {
        //public PhoneNumber(Guid id) 
        //{
        //    Id = id;
        //}

        //public Guid AbonentId { get; set; }

        public Guid AbonentId { get; set; }

        [ForeignKey(nameof(AbonentId))]
        public required Abonent Abonent { get; set; }

       
        public int HomePhone { get; set; }

        public int WorkPhone { get; set; }

        public int MobilePhone { get; set; }
    }
}
