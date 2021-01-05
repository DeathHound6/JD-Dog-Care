using SSD_CW_20_21.Objects;
using System.Data.SqlClient;
using System;

namespace SSD_CW_20_21.DbAccess
{
    class ServiceOrderDBAccess
    {
        private Database DB;

        public ServiceOrderDBAccess(Database db)
        {
            DB = db;
        }

        public bool insertServiceOrder(ServiceOrder so)
        {
            DB.Command = DB.Connection.CreateCommand();
            DB.Command.CommandText = $"INSERT INTO SERVICEORDER(ServiceID, OrderID) VALUES({so.ServiceID}, {so.OrderID})";
            try
            {
                DB.Command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public ServiceOrder getObjectByOrderID(int id)
        {
            ServiceOrder obj;
            DB.Command = DB.Connection.CreateCommand();
            DB.Command.CommandText = $"SELECT * FROM SERVICEORDER WHERE OrderID = {id}";
            DB.Reader = DB.Command.ExecuteReader();
            DB.Reader.Read();
            obj = getObjectFromReader(DB.Reader);
            DB.Reader.Close();
            return obj;
        }

        public bool updateServOrder(ServiceOrder so)
        {
            DB.Command = DB.Connection.CreateCommand();
            DB.Command.CommandText = $"UPDATE SERVICEORDER SET ServiceID = {so.ServiceID} WHERE OrderID = {so.OrderID}";
            try
            {
                DB.Command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        private ServiceOrder getObjectFromReader(SqlDataReader rdr)
        {
            ServiceOrder obj = new ServiceOrder();
            obj.ServiceID = rdr.GetInt32(0);
            obj.OrderID = rdr.GetInt32(1);
            return obj;
        }
    }
}
