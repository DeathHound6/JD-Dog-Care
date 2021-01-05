using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSD_CW_20_21.Objects;
using System.Data.SqlClient;

namespace SSD_CW_20_21.DbAccess
{
    class ServiceDBAccess
    {
        private Database database;

        public ServiceDBAccess(Database db)
        {
            database = db;
        }
        public List<Service> getAllServices()
        {
            List<Service> result = new List<Service>();
            database.Command = database.Connection.CreateCommand();
            database.Command.CommandText = "SELECT * FROM SERVICE";
            database.Reader = database.Command.ExecuteReader();
            while (database.Reader.Read())
            {
                result.Add(getserviceFromReader(database.Reader));
            }
            database.Reader.Close();
            return result;
        }


        public Service getServiceById(int id)
        {
            database.Command = database.Connection.CreateCommand();
            database.Command.CommandText = $"SELECT * FROM SERVICE WHERE ServiceId = {id}";
            database.Reader = database.Command.ExecuteReader();
            database.Reader.Read();
            Service serv = getserviceFromReader(database.Reader);
            database.Reader.Close();
            return serv;
        }

        public Service getServiceByDesc(string text)
        {
            database.Command = database.Connection.CreateCommand();
            database.Command.CommandText = $"SELECT * FROM SERVICE WHERE Description = '{text}'";
            database.Reader = database.Command.ExecuteReader();
            database.Reader.Read();
            Service serv = getserviceFromReader(database.Reader);
            database.Reader.Close();
            return serv;
        }

        public bool insertService(Service serv)
        {
            database.Command = database.Connection.CreateCommand();
            database.Command.CommandText = $"INSERT INTO SERVICE(ServiceId, Description, Time, Cost) VALUES({serv.ServiceID}, '{serv.Description}', '{serv.Time}', {Convert.ToDecimal(serv.Cost)})";
            try
            {
                database.Command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        private bool updateService(Service serv)
        {
            database.Command = database.Connection.CreateCommand();
            database.Command.CommandText = $"UPDATE SERVICE SET Cost = {Convert.ToDecimal(serv.Cost)}, Description = '{serv.Description}', Time = '{serv.Time}' WHERE ServiceId = {serv.ServiceID}";
            try
            {
                database.Command.ExecuteNonQuery();
                return true;
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        private Service getserviceFromReader(SqlDataReader rdr)
        {
            Service serv = new Service();
            serv.ServiceID = rdr.GetInt32(0);
            serv.Description = rdr.GetString(1);
            serv.Time = rdr.GetInt32(2);
            serv.Cost = Convert.ToDouble(rdr.GetDecimal(3));
            return serv;
        }
    }
}
