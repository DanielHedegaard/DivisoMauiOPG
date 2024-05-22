using System.Data.SqlClient;

namespace CLDB
{
    public class DbHelper
    {
        protected SqlConnection dbConn;

        public DbHelper()
        {
            //work connection
            dbConn = new SqlConnection("Data Source=PCVDATAWRK003\\MSSQLSERVER01;Initial Catalog=Diviso_addresses;Integrated Security=True;Encrypt=True;");
            //home connection
            //dbConn = new SqlConnection("Data Source=DESKTOP-3CIKLKO\\SQLEXPRESS;Initial Catalog=Diviso_addresses;Integrated Security=True;Trust Server Certificate=True");
        }

        protected async Task<SqlDataReader> ExecuteSelectQuery(string sql)
        {
            SqlCommand command = new SqlCommand(sql, dbConn);

            try
            {
                await dbConn.OpenAsync();
            }
            catch 
            {
                return null;
            }

            return await command.ExecuteReaderAsync();
        }

        protected async Task<bool> ExecuteInsertQuery(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, dbConn);

            try
            {
                await dbConn.OpenAsync();
            }
            catch
            {
                return false;
            }

            try
            {
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

        protected async Task<bool> ExecuteDeleteQuery(string sql)
        {
            return await ExecuteInsertQuery(sql);
        }

        protected async Task<bool> ExecuteUpdateQuery(string sql)
        {
            return await ExecuteInsertQuery(sql);
        }
    }
}
