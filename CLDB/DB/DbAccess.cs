using Models;
using System.Data.SqlClient;

namespace CLDB.DB
{
    public class DbAccess : DbHelper, IDbAccess
    {

        public async Task<List<Address>> GetAllAddresses()
        {
            string command = "SELECT * FROM Address";

            List<Address> addresses = new();

            SqlDataReader result = await ExecuteSelectQuery(command);

            if (result != null)
            {
                try
                {
                    while (await result.ReadAsync())
                    {
                        Address address = new Address()
                        {
                            Address_Name = (string)result["Address_Name"],
                            City = (string)result["City"],
                            Zip_Code = (int)result["Zip_Code"]
                        };
                        addresses.Add(address);
                    }
                    await dbConn.CloseAsync();

                    return addresses;
                }
                catch
                {
                    await dbConn.CloseAsync();

                    return null;
                }
            }
            else return null;
        }

        public async Task<bool> AddAdress(string address)
        {
            //get from parameter string
            Address addres = new Address() { };

            string command = $"EXEC sp_AddAddress @Address_Name = '{addres.Address_Name}', @Zip_Code = {addres.Zip_Code}, @City = '{addres.City}'";

            return await ExecuteInsertQuery(command);
        }

        public async Task<bool> DeleteAdresses(int id)
        {
            string command = $"EXEC sp_DeleteAddress @id = {id}";

            return await ExecuteDeleteQuery(command);
        }
    }
}
