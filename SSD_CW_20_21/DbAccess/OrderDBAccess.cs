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

        public Orders exec(string query)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = query;
            Db.Reader = Db.Command.ExecuteReader();
            Db.Reader.Read();
            Orders order = getOrderFromReader(Db.Reader);
            Db.Reader.Close();
            return order;
        }

        public Orders getOrderById(int id)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"SELECT * FROM ORDERS WHERE OrderID = {id}";
            Db.Reader = Db.Command.ExecuteReader();
            Db.Reader.Read();
            Orders order = getOrderFromReader(Db.Reader);
            Db.Reader.Close();
            return order;
        }

        public void deleteOrder(Orders order)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"DELETE FROM ORDERS WHERE OrderID = {order.Id}";
            try
            {
                Db.Command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool updateOrder(Orders order)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"UPDATE ORDERS SET Cancelled = {order.Cancelled}, ServiceID = {order.ServiceID}, RoomID = {order.RoomID}, DogID = {order.DogId}, StaffID = {order.StaffId}, Date = '{order.Date}', StartTime = '{order.StartTime}', Paid = {Convert.ToDecimal(order.Paid)}, Teeth = {order.Teeth}, Ears = {order.Ears}, Nails = {order.Nails} WHERE OrderID = {order.Id}";
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
            Db.Command.CommandText = $"INSERT INTO ORDERS (OrderID, ServiceID, DogID, StaffID, Date, StartTime, Ears, Teeth, Nails, RoomID, Paid, Cancelled) VALUES ({order.Id}, {order.ServiceID}, {order.DogId}, {order.StaffId}, '{order.Date}', '{order.StartTime}', {order.Ears}, {order.Teeth}, {order.Nails}, {order.RoomID}, {Convert.ToDecimal(order.Paid)}, {order.Cancelled})";
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
            order.ServiceID = rdr.GetInt32(1);
            order.DogId = rdr.GetInt32(2);
            order.StaffId = rdr.GetInt32(3);
            order.Date = rdr.GetString(4);
            order.StartTime = rdr.GetString(5);
            order.Ears = rdr.GetInt32(6);
            order.Teeth = rdr.GetInt32(7);
            order.Nails = rdr.GetInt32(8);
            order.RoomID = rdr.GetInt32(9);
            order.Paid = rdr.GetInt32(10);
            order.Cancelled = rdr.GetInt32(11);
            return order;
        }
    }
}
