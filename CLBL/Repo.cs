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
                        tekst = address.Address_Name + ", " + address.Zip_Code + ", " + address.City,
                        adgangsadresse = new Adgangsadresse() { id = address.id.ToString() },
                    };

                    returnList.Add(dawaAddress);
                }
            }

            return returnList;
        }

        //convert address string = address object
        public async Task<bool> AddAdress(DawaAddress dwAddress)
        {
            if (dwAddress != null)
            {
                Address paramAddress = new() { Address_Name = dwAddress.adgangsadresse.vejnavn + " " + dwAddress.adgangsadresse.husnr,
                    City = dwAddress.adgangsadresse.postnrnavn, Zip_Code = dwAddress.adgangsadresse.postnr
                };

                return await dbConn.AddAdress(paramAddress);
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
