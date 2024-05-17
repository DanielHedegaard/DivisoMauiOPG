using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace CLDB
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
