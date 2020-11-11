using System;
using SSD_CW_20_21.Objects;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SSD_CW_20_21.DbAccess
{
    class ServiceDBAccess
    {
        private Database Db;

        public ServiceDBAccess(Database db)
        {
            Db = db;
        }

        public bool updateService(Service serv)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"UPDATE SERVICE SET Option = {serv.Option}, Nails = {serv.Nails}, Ears = {serv.Ears}, Teeth = {serv.Teeth} WHERE OrderID = {serv.OrderID}";
            try
            {
                Db.Command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool insertService(Service serv)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"INSERT INTO SERVICE (OrderID, Option, Nails, Ears, Teeth) VALUES ({serv.OrderID}, {serv.Option}, {serv.Nails}, {serv.Ears}, {serv.Teeth})";
            try
            {
                Db.Command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Service> getAllServices()
        {
            List<Service> result = new List<Service>();
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = "SELECT * FROM SERVICE";
            Db.Reader = Db.Command.ExecuteReader();
            while (Db.Reader.Read())
            {
                result.Add(getCustomerFromReader(Db.Reader));
            }
            Db.Reader.Close();
            return result;
        }

        private Service getCustomerFromReader(SqlDataReader rdr)
        {
            return new Service(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4));
        }
    }
}
