using Models;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace CLDB.DB
{
    public class DbAccess : IDbAccess
    {
        private SqlConnection dbConn;
        public DbAccess()
        {
            dbConn = new SqlConnection("Data Source=PCVDATAWRK003\\MSSQLSERVER01;Initial Catalog=Diviso_addresses;Integrated Security=True;Trust Server Certificate=True");
        }

        public async Task<bool> AddAdress(string address)
        {
            string command = "EXEC SP";

            SqlCommand sqlCommand = new SqlCommand(command, dbConn);

            try
            {
                await dbConn.OpenAsync();

                //Check
                var result = await sqlCommand.ExecuteNonQueryAsync();

                await dbConn.CloseAsync();

                return result > 0;
            }
            catch
            {
                await dbConn.CloseAsync();

                return false;
            }
        }

        public async Task<bool> DeleteAdresses(int id)
        {
            string command = "EXEC SP";

            SqlCommand sqlCommand = new SqlCommand(command, dbConn);

            try
            {
                await dbConn.OpenAsync();

                //Check
                var result = await sqlCommand.ExecuteNonQueryAsync();

                await dbConn.CloseAsync();

                return result > 0;
            }
            catch
            {
                await dbConn.CloseAsync();

                return false;
            }
        }

        public async Task<List<Address>> GetAllAddresses()
        {
            string command = "SELECT * FROM Address";

            SqlCommand sqlCommand = new SqlCommand(command, dbConn);

            try
            {
                await dbConn.OpenAsync();

            }
            catch
            {
                await dbConn.CloseAsync();

                return null;
            }

            SqlDataReader result = await sqlCommand.ExecuteReaderAsync();

            List<Address> addresses = new();

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
                }
            }
            catch
            {
                await dbConn.CloseAsync();

                return null;
            }

            //?hvis db connection is open
            await dbConn.CloseAsync();

            return addresses;
        }
    }
}
