using CLDB.DB;
using Models;
using WebModels;

namespace CLBL
{
    public class Repo : IRepo
    {
        private DbAccess dbConn;

        public Repo()
        {
            dbConn = new DbAccess();
        }

        public async Task<List<DawaAddress>> GetAllAddresses()
        {
            List<DawaAddress> returnList = new();
            List<Address> addresses = await dbConn.GetAllAddresses();

            if (addresses == null) { return null; }

            foreach (Address address in addresses)
            {
                if (address.Address_Name != null)
                {
                    DawaAddress dawaAddress = new DawaAddress()
                    {
                        tekst = address.Address_Name + " " + address.Zip_Code + " " + address.City,
                    };

                    returnList.Add(dawaAddress);
                }
            }

            return null;
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
