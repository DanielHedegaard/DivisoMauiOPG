namespace CLDB
{
    public interface IDbAccess
    {
        Task<List<string>> GetAllAddresses();
        Task<bool> AddAdress(string address);
        Task<bool> DeleteAdresses(int id);
    }
}
