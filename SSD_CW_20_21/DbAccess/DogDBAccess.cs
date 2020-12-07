using SSD_CW_20_21.Objects;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace SSD_CW_20_21.DbAccess
{
    class DogDBAccess
    {
        private Database Db;
        
        public DogDBAccess(Database db)
        {
            Db = db;
        }

        public Dog getDogById(int id)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"SELECT * FROM DOG WHERE DogID = {id}";
            Db.Reader = Db.Command.ExecuteReader();
            Db.Reader.Read();
            Dog dog = getDogFromReader(Db.Reader);
            Db.Reader.Close();
            return dog;
        }

        public bool updateDog(Dog dog)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"UPDATE DOG SET Name = '{dog.Name}', Deleted = {dog.Deleted}, OwnerID = {dog.OwnerId}, Breed = '{dog.Breed}' WHERE DogID = {dog.Id}";
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

        public bool insertDog(Dog dog)
        {
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = $"INSERT INTO DOG (DogID, OwnerID, Name, Breed, Size, Deleted) VALUES ({dog.Id}, {dog.OwnerId}, '{dog.Name}', '{dog.Breed}', '{dog.Size}', {dog.Deleted})";
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

        public List<Dog> getAllDogs()
        {
            List<Dog> result = new List<Dog>();
            Db.Command = Db.Connection.CreateCommand();
            Db.Command.CommandText = "SELECT * FROM DOG"; 
            Db.Reader = Db.Command.ExecuteReader();
            while (Db.Reader.Read())
            {
                result.Add(getDogFromReader(Db.Reader));
            }
            Db.Reader.Close();
            return result;
        }

        private Dog getDogFromReader(SqlDataReader rdr)
        {
            return new Dog(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));
        }
    }
}
