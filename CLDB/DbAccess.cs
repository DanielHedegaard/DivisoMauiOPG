using System.Data.SqlClient;

namespace CLDB
{
    public class DbAccess : IDbAccess
    {
        private SqlConnection dbConn;
        public DbAccess()
        {
                
        }

        public Task<bool> AddAdress(string address)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAdresses(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetAllAddresses()
        {
            throw new NotImplementedException();
        }
    }
}
