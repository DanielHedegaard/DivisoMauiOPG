using Models;

namespace CLDB.DB
{
    public interface IDbAccess
    {
        Task<List<Address>> GetAllAddresses();
        Task<bool> AddAdress(string address);
        Task<bool> DeleteAdresses(int id);
    }
}
