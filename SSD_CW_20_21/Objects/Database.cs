using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;

namespace SSD_CW_20_21.Objects
{
    public class Database
    {
        private SqlCommand cmd;
        private SqlConnection conn;
        private SqlDataReader rdr;
        private bool connected;
        
        public Database()
        {

        }

        public void Disconnect()
        {
            if (!connected) return;
            conn = null;
            connected = false;
        }

        
        public void Connect()
        {
            SqlConnectionStringBuilder scStrBuild = new SqlConnectionStringBuilder();
            string str = Application.StartupPath;
            str = str.Remove((Convert.ToInt16(str.Length) - 9));

            scStrBuild.DataSource = "(LocalDB)\\MSSQLLocalDB";
            scStrBuild.AttachDBFilename = str + "Database1.mdf";
            scStrBuild.IntegratedSecurity = true;

            conn = new SqlConnection(scStrBuild.ToString());
            try
            {
                conn.Open();
                connected = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                connected = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public SqlCommand Command
        {
            get { return cmd; }
            set { cmd = value; }
        }

        public SqlConnection Connection
        {
            get { return conn; }
            set { conn = value; }
        }

        public SqlDataReader Reader
        {
            get { return rdr; }
            set { rdr = value; }
        }

        public bool Connected
        {
            get { return connected; }
        }
    }
}
