using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly string _connectionString;

        public AnimalRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Animal> GetAnimals(string orderBy)
        {
            List<Animal> animals = new List<Animal>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM Animals ORDER BY {orderBy}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Animal animal = new Animal
                        {
                            IdAnimal = Convert.ToInt32(reader["IdAnimal"]),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            Category = reader["Category"].ToString(),
                            Area = reader["Area"].ToString()
                        };

                        animals.Add(animal);
                    }
                }
            }

            return animals;
        }

        public void AddAnimal(Animal animal)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Animals (Name, Description, Category, Area) " +
                               "VALUES (@Name, @Description, @Category, @Area)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", animal.Name);
                command.Parameters.AddWithValue("@Description", animal.Description);
                command.Parameters.AddWithValue("@Category", animal.Category);
                command.Parameters.AddWithValue("@Area", animal.Area);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateAnimal(Animal animal)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Animals " +
                               "SET Name = @Name, Description = @Description, " +
                               "Category = @Category, Area = @Area " +
                               "WHERE IdAnimal = @IdAnimal";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", animal.Name);
                command.Parameters.AddWithValue("@Description", animal.Description);
                command.Parameters.AddWithValue("@Category", animal.Category);
                command.Parameters.AddWithValue("@Area", animal.Area);
                command.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAnimal(int idAnimal)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Animals WHERE IdAnimal = @IdAnimal";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdAnimal", idAnimal);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}