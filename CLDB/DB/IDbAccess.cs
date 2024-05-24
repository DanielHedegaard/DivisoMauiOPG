using Models;

namespace CLDB.DB
{
    public interface IDbAccess
    {
        Task<List<Address>> GetAllAddresses();
        Task<bool> AddAdress(Address address);
        Task<bool> DeleteAdresses(int id);
    }
}
