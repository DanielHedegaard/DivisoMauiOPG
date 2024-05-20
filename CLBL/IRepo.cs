using Models;

namespace CLBL
{
    public interface IRepo
    {
        Task<List<Address>> GetAllAddresses();
        Task<bool> AddAdress(string address);
        Task<bool> DeleteAdresses(int id);
    }
}
