using PhoneCompany.Domain.Models;

namespace PhoneCompany.Domain
{
    public interface IAbonentRepository
    {
        Task<FullModel> Get();
        List<FullModel> GetUsers();
    }
}
