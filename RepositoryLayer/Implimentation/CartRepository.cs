using Microsoft.Extensions.Configuration;
using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Implimentation
{
    public class CartRepository:ICartRepository
    {
        private IConfiguration _configuration;
        private string _connectionString;
        private SqlConnection _conn;
        public CartRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("BookStoreAppDB");
            _conn = new SqlConnection(_connectionString);
        }


        public CartItem AddToCart(int userId, CartItem cart)
        {

            SqlCommand command = new SqlCommand("spAddCart")
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@bookId", cart.bookId);
            command.Parameters.AddWithValue("@price", cart.price);
            command.Parameters.AddWithValue("@quantity", cart.quantity);
            command.Parameters.AddWithValue("@userId", userId);
            _conn.Open();
            command.Connection = _conn;
            command.ExecuteNonQuery();
            _conn.Close();
            return cart;
        }






    }
}
