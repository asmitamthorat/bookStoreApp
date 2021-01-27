using Microsoft.Extensions.Configuration;
using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Implimentation
{
    public class userRepository:IuserRepository
    {
        private IConfiguration _configuration;
        private string _connectionString;
        private SqlConnection _conn;
        public userRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("BookStoreAppDB");
            _conn = new SqlConnection(_connectionString);
        }


        public userRegistration addUser(userRegistration userData) {
            SqlCommand command = new SqlCommand("spAddUser")
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@firstName", userData.firstName);
            command.Parameters.AddWithValue("@lastName", userData.lastName);
            command.Parameters.AddWithValue("@email", userData.email);
            command.Parameters.AddWithValue("@password", userData.password);
            command.Parameters.AddWithValue("@phone", userData.phone);
            _conn.Open();
            command.Connection = _conn;
            command.ExecuteNonQuery();
            _conn.Close();
            return userData;
        }

        public userRegistration loginUser(userRegistration userData) {
           userRegistration user = new userRegistration();
            _conn.Open();
            SqlCommand command = new SqlCommand("spGetuser", _conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@email", userData.email);
            command.Parameters.AddWithValue("@password",userData.password);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    user=(new userRegistration
                    {
                        userId = (int)reader["userId"],
                        firstName = (string)reader["firstName"],
                        lastName = (string)reader["lastName"],
                        email = (string)reader["email"],
                        password = (string)reader["password"],
                        role=(string)reader["role"]
                    });
                }
            }
            _conn.Close();
            return user;


        }
    }
}
