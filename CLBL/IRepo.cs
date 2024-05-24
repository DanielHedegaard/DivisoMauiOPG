using WebModels;

namespace CLBL
{
    public interface IRepo
    {
        Task<List<DawaAddress>> GetAllAddresses();
        Task<bool> AddAdress(DawaAddress address);
        Task<bool> DeleteAdresses(int id);
    }
}
