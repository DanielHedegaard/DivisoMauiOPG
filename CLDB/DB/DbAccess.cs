﻿using Models;
using System.Data.SqlClient;

namespace CLDB.DB
{
    public class DbAccess : DbHelper, IDbAccess
    {
        public async Task<List<User>> GetUsers()
        {
            string command = "SELECT * FROM Users";

            List<User> users = new List<User>();

            SqlDataReader result = await ExecuteSelectQuery(command);

            if (result != null)
            {
                try
                {
                    while (await result.ReadAsync())
                    {
                        User user = new User()
                        {
                            id = (int)result["id"],
                            password = (string)result["Password"]
                        };
                        users.Add(user);
                    }
                    await dbConn.CloseAsync();

                    return users;
                }
                catch 
                {
                    await dbConn.CloseAsync();

                    return null;
                }
            }
            else return null;
        }

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
                            id = (int)result["id"],
                            Address_Name = (string)result["Address_Name"],
                            City = (string)result["City"],
                            Zip_Code = (string)result["Zip_Code"]
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

        public async Task<bool> AddAdress(Address address)
        {
            string command = $"EXEC sp_AddAddress @Address_Name = '{address.Address_Name}', @Zip_Code = {address.Zip_Code}, @City = '{address.City}'";

            return await ExecuteInsertQuery(command);
        }

        public async Task<bool> DeleteAdresses(int id)
        {
            string command = $"EXEC sp_DeleteAddress @id = {id}";

            return await ExecuteDeleteQuery(command);
        }
    }
}
