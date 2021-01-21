using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace RepositoryLayer.Implimentation
{
    public class BookRepository:IBookRepository
    {
        private IConfiguration _configuration;
        private string _connectionString;
        private SqlConnection _conn;
        public BookRepository(IConfiguration configuration) {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("BookStoreAppDB");
            _conn = new SqlConnection(_connectionString);
        }

        public BookProduct AddBook(BookProduct book) {
            SqlCommand command = new SqlCommand("insert into Book(bookName,bookImage,author,description,quantity,price,addedTocard) values(@bookName,@bookImage,@author,@description,@quantity,@price,@addedTocard)");
            command.Parameters.AddWithValue("@bookName", book.bookName);
            command.Parameters.AddWithValue("@bookImage", book.bookImage);
            command.Parameters.AddWithValue("@author", book.author);
            command.Parameters.AddWithValue("@description", book.description);
            command.Parameters.AddWithValue("@quantity", book.quantity);
            command.Parameters.AddWithValue("@price", book.price);
            command.Parameters.AddWithValue("@addedTocard", book.addedTocard);
            _conn.Open();
            command.Connection = _conn;
            command.ExecuteNonQuery();
            _conn.Close();
            return book;

        }
    }
}
