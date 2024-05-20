using CLDB.DB;
using Models;

namespace CLBL
{
    public class Repo : IRepo
    {
        private DbAccess dbConn;

        public Repo()
        {
            dbConn = new DbAccess();
        }

        public async Task<List<Address>> GetAllAddresses()
        {
            return await dbConn.GetAllAddresses();
        }

        //convert address string = address object
        public async Task<bool> AddAdress(string address)
        {
            if (!string.IsNullOrEmpty(address))
            {
                return await dbConn.AddAdress(address);
            }

            return false;
        }

        public async Task<bool> DeleteAdresses(int id)
        {
            if (id != 0)
            {
                return await dbConn.DeleteAdresses(id);
            }

            return false;
        }
    }
}
