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
            Db.Command.CommandText = $"UPDATE DOG SET Name = '{dog.Name}', Deleted = {dog.Deleted}, OwnerID = {dog.OwnerId}, Breed = '{dog.Breed}', Aggression = '{dog.Aggression}' WHERE DogID = {dog.Id}";
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
            Db.Command.CommandText = $"INSERT INTO DOG (DogID, OwnerID, Name, Breed, Agression, Deleted) VALUES ({dog.Id}, {dog.OwnerId}, '{dog.Name}', '{dog.Breed}', '{dog.Aggression}', {dog.Deleted})";
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
            Dog dog = new Dog();
            dog.Id = rdr.GetInt32(0);
            dog.OwnerId = rdr.GetInt32(1);
            dog.Name = rdr.GetString(2);
            dog.Breed = rdr.GetString(3);
            dog.Aggression = rdr.GetString(4);
            dog.DOB = rdr.GetString(5);
            dog.HairLength = rdr.GetString(6);
            dog.Deleted = rdr.GetInt32(7);
            return dog;
        }
    }
}
