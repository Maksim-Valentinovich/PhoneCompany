namespace PhoneCompany.Domain.Entities
{
    public abstract class Entity<TPrimatyKey>
    {
        public TPrimatyKey Id { get; set; }

    }

    public abstract class Entity : Entity<int>
    {

    }
}
