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

        public Service getServiceById(int id)
        {
            database.Command = database.Connection.CreateCommand();
            database.Command.CommandText = $"SELECT * FROM DOG WHERE DogID = {id}";
            database.Reader = database.Command.ExecuteReader();
            database.Reader.Read();
            Service serv = getserviceFromReader(database.Reader);
            database.Reader.Close();
            return serv;
        }

        public bool insertService(Service serv)
        {
            database.Command = database.Connection.CreateCommand();
            database.Command.CommandText = $"INSERT INTO SERVICE(ServiceID, ServiceOption, Nails, Ears, Teeth) VALUES({serv.ServiceID}, {serv.ServiceOption}, {serv.Nails}, {serv.Ears}, {serv.Teeth})";
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

        public bool updateService(Service serv)
        {
            database.Command = database.Connection.CreateCommand();
            database.Command.CommandText = $"UPDATE SERVICE SET ServiceOption = {serv.ServiceOption}, Nails = {serv.Nails}, Teeth = {serv.Teeth}, Ears = {serv.Ears} WHERE ServiceID = {serv.ServiceID}";
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
            serv.ServiceOption = rdr.GetInt32(1);
            serv.Nails = rdr.GetInt32(2);
            serv.Ears = rdr.GetInt32(3);
            serv.Teeth = rdr.GetInt32(4);
            return serv;
        }
    }
}
