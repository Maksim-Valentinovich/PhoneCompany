namespace PhoneCompany.Domain.Models
{
    public class AbonentModel : Model
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? MiddleName { get; set; }

        //protected override BaseEntity Entity { get; }

        //public AbonentModel(Abonent entity)
        //{
        //    Entity = entity;
        //}

        //public IEnumerable<PhoneModel> phone => Multiple<PhoneModel>(x => x.AbonentId);
    }
}
