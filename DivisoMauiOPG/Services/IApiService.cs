using WebModels;

namespace CLDB.Interfaces
{
    public interface IApiService
    {
        Task<List<DawaAddress>> GetAdresses(string searchKeyWord);
    }
}
