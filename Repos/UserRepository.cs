using Dapper;
using Microsoft.Data.SqlClient;
using Dapper.Models;
using System;

namespace Dapper.Repositories
{
    class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // create
        public void CreateUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (Name, Age) VALUES (@Name, @Age)";

                connection.Execute(query, new { Name = user.Name, Age = user.Age });
            }
        }

        // read
        public IEnumerable<User> GetAllUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Users";

                return connection.Query<User>(query);
            }
        }

        // read
        public User GetUserById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Users WHERE Id = @Id";

                return connection.QuerySingleOrDefault<User>(query, new { Id = id });
            }
        }

        // update
        public void UpdateUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";

                connection.Execute(query, new { Name = user.Name, Age = user.Age, Id = user.Id });
            }
        }

        // delete
        public void DeleteUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string deleteOrdersQuery = "DELETE FROM Orders WHERE id_user = @Id";

                connection.Execute(deleteOrdersQuery, new { Id = id });

                string query = "DELETE FROM Users WHERE Id = @Id";

                connection.Execute(query, new { Id = id });
            }
        }
    }
}
