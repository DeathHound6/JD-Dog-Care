using SSD_CW_20_21.Objects;
using System.Data.SqlClient;

namespace SSD_CW_20_21.DbAccess
{
    class ServiceOrderDBAccess
    {
        private Database DB;

        public ServiceOrderDBAccess(Database db)
        {
            DB = db;
        }

        public ServiceOrder getObjectByServiceID(int id)
        {
            ServiceOrder obj;
            DB.Command = DB.Connection.CreateCommand();
            DB.Command.CommandText = $"SELECT * FROM SERVICEORDER WHERE ServiceID = {id}";
            DB.Reader = DB.Command.ExecuteReader();
            DB.Reader.Read();
            obj = getObjectFromReader(DB.Reader);
            DB.Reader.Close();
            return obj;
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

        private ServiceOrder getObjectFromReader(SqlDataReader rdr)
        {
            ServiceOrder obj = new ServiceOrder();
            obj.ServiceID = rdr.GetInt32(0);
            obj.OrderID = rdr.GetInt32(1);
            return obj;
        }
    }
}
