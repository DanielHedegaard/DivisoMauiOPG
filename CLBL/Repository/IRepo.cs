using WebModels;

namespace CLBL.Repository
{
    public interface IRepo
    {
        Task<bool> Login(string password);
        Task<List<DawaAddress>> GetAllAddresses();
        Task<bool> AddAdress(DawaAddress address);
        Task<bool> DeleteAdresses(int id);
    }
}
