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


        public int RemoveFromCart(int userId, int bookId) 
        {
            _conn.Open();
            SqlCommand command = new SqlCommand("spRemoveFromCart",_conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@bookId",bookId);
            command.Parameters.AddWithValue("@userId",userId);
            
            int isDeleted = command.ExecuteNonQuery();
            _conn.Close();
            return isDeleted;

        }

        public List<CartItem> GetCartOfUser(int userId) 
        {
            List<CartItem> CartList = new List<CartItem>();
            _conn.Open();
            SqlCommand command = new SqlCommand("spGetCardById", _conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@userId", userId);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CartList.Add(new CartItem
                    {
                      /*  bookId = (int)reader[" bookId"],*/
                        quantity = (int)reader["quanity"],
                        cartItem_id = (int)reader["cartItem_id"],
                        price = (int)reader["price"]
                       
                    });
                }
            }
            _conn.Close();
            return CartList;
        }

    }
}
