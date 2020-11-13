using SSD_CW_20_21.Objects;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace SSD_CW_20_21.DbAccess
{
    class OrderDBAccess
    {
        private Database Db;

        public OrderDBAccess(Database db)
        {
            Db = db;
        }

        public Orders getOrderById(int id)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"SELECT * FROM ORDERS WHERE OrderID = {id}";
            Db.Reader = Db.Command.ExecuteReader();
            Db.Reader.Read();
            Orders dog = getOrderFromReader(Db.Reader);
            Db.Reader.Close();
            return dog;
        }

        public bool updateOrder(Orders order)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"UPDATE ORDERS SET Cancelled = {order.Cancelled}, DogID = {order.DogId}, StaffID = {order.StaffId}, Date = '{order.Date}', StartTime = '{order.StartTime}', EndTime = '{order.EndTime}', Paid = {order.Paid} WHERE OrderID = {order.Id}";
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

        public bool insertOrder(Orders order)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"INSERT INTO ORDERS (OrderID, DogID, StaffID, Date, StartTime, EndTime, Paid, Cancelled) VALUES ({order.Id}, {order.DogId}, {order.StaffId}, '{order.Date}', '{order.StartTime}', '{order.EndTime}', {order.Paid}, {order.Cancelled})";
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

        public List<Orders> getAllOrders()
        {
            List<Orders> result = new List<Orders>();
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = "SELECT * FROM ORDERS";
            Db.Reader = Db.Command.ExecuteReader();
            while (Db.Reader.Read())
            {
                result.Add(getOrderFromReader(Db.Reader));
            }
            Db.Reader.Close();
            return result;
        }

        private Orders getOrderFromReader(SqlDataReader rdr)
        {
            return new Orders(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetInt32(6), rdr.GetInt32(7), rdr.GetInt32(8), rdr.GetInt32(9), rdr.GetInt32(10));
        }
    }
}
