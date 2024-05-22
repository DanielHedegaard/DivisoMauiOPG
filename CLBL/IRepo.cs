using Models;
using WebModels;

namespace CLBL
{
    public interface IRepo
    {
        Task<List<DawaAddress>> GetAllAddresses();
        Task<bool> AddAdress(string address);
        Task<bool> DeleteAdresses(int id);
    }
}
