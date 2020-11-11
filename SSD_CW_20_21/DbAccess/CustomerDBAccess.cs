using SSD_CW_20_21.Objects;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SSD_CW_20_21.DbAccess
{
    class CustomerDBAccess
    {
        private Database Db;
        
        public CustomerDBAccess(Database db)
        {
            Db = db;
        }

        public Customer getOwnerById(int id)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"SELECT * FROM CUSTOMER WHERE CustomerID = {id}";
            Db.Reader = Db.Command.ExecuteReader();
            Db.Reader.Read();
            Customer owner = getCustomerFromReader(Db.Reader);
            Db.Reader.Close();
            return owner;
        }

        public List<Customer> getAllCustomers()
        {
            List<Customer> result = new List<Customer>();
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = "SELECT * FROM CUSTOMER";
            Db.Reader = Db.Command.ExecuteReader();
            while (Db.Reader.Read())
            {
                result.Add(getCustomerFromReader(Db.Reader));
            }
            Db.Reader.Close();
            return result;
        }

        private Customer getCustomerFromReader(SqlDataReader rdr)
        {
            return new Customer(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7));
        }
    }
}
