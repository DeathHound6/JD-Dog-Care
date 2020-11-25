using SSD_CW_20_21.Objects;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SSD_CW_20_21.DbAccess
{
    class StaffDBAccess
    {
        private Database Db;
        
        public StaffDBAccess(Database db)
        {
            Db = db;
        }

        public Staff getStaffByName(string name)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"SELECT * FROM STAFF WHERE Name = '{name}'";
            Db.Reader = Db.Command.ExecuteReader();
            Db.Reader.Read();
            Staff staff = getStaffFromReader(Db.Reader);
            Db.Reader.Close();
            return staff;
        }

        public Staff getStaffById(int id)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"SELECT * FROM STAFF WHERE StaffID = {id}";
            Db.Reader = Db.Command.ExecuteReader();
            Db.Reader.Read();
            Staff staff = getStaffFromReader(Db.Reader);
            Db.Reader.Close();
            return staff;
        }

        public List<Staff> getAllStaff()
        {
            List<Staff> result = new List<Staff>();
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = "SELECT * FROM STAFF";
            Db.Reader = Db.Command.ExecuteReader();
            while (Db.Reader.Read())
            {
                result.Add(getStaffFromReader(Db.Reader));
            }
            Db.Reader.Close();
            return result;
        }

        private Staff getStaffFromReader(SqlDataReader rdr)
        {
            return new Staff(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetInt32(5));
        }
    }
}
