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
            Db.Command.CommandText = $"UPDATE ORDERS SET Cancelled = {order.Cancelled}, RoomID = {order.RoomID}, DogID = {order.DogId}, StaffID = {order.StaffId}, Date = '{order.Date}', StartTime = '{order.StartTime}', EndTime = '{order.EndTime}', Paid = {Convert.ToDecimal(order.Paid)} WHERE OrderID = {order.Id}";
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
            Db.Command.CommandText = $"INSERT INTO ORDERS (OrderID, DogID, StaffID, Date, StartTime, EndTime, Ears, Teeth, Nails, RoomID, Paid, Cancelled) VALUES ({order.Id}, {order.DogId}, {order.StaffId}, '{order.Date}', '{order.StartTime}', '{order.EndTime}', {order.Ears}, {order.Teeth}, {order.Nails}, {order.RoomID}, {Convert.ToDecimal(order.Paid)}, {order.Cancelled})";
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
            Orders order = new Orders();
            order.Id = rdr.GetInt32(0);
            order.DogId = rdr.GetInt32(1);
            order.StaffId = rdr.GetInt32(2);
            order.Date = rdr.GetString(3);
            order.StartTime = rdr.GetString(4);
            order.EndTime = rdr.GetString(5);
            order.Ears = rdr.GetInt32(6);
            order.Teeth = rdr.GetInt32(7);
            order.Nails = rdr.GetInt32(8);
            order.RoomID = rdr.GetInt32(9);
            order.Paid = Convert.ToDouble(rdr.GetDecimal(10));
            order.Cancelled = rdr.GetInt32(11);
            return order;
        }
    }
}
