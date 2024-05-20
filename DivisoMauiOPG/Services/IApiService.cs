using Models;

namespace CLDB.Interfaces
{
    public interface IApiService
    {
        Task<List<Address>> GetAdresses(string searchKeyWord);
    }
}
