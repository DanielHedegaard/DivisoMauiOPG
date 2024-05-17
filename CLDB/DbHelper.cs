using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLDB
{
    public class DbHelper
    {
        protected SqlConnection dbConn;

        public DbHelper()
        {
            dbConn = new SqlConnection("Data Source=PCVDATAWRK003\\MSSQLSERVER01;Initial Catalog=Diviso_addresses;Integrated Security=True;Trust Server Certificate=True");
        }

        public async Task<bool> ExecuteInsertQuery(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, dbConn);

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
    }
}
