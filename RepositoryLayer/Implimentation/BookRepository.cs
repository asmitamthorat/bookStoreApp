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
        ///    SqlCommand command = new SqlCommand("insert into Book(bookName,bookImage,author,description,quantity,price,addedTocard) values(@bookName,@bookImage,@author,@description,@quantity,@price,@addedTocard)");
            SqlCommand command = new SqlCommand("spAddBook")
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
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
      
         public List<BookProduct> getBooks()
         {
             List<BookProduct> books = new List<BookProduct>();
             using (_conn)
             {
                   _conn.Open();
                   SqlCommand command = new SqlCommand("Select bookId, bookName ,bookImage , author, description, quantity,price,addedTocard from Book ", _conn);
                   using (SqlDataReader reader = command.ExecuteReader())
                   {
                            while (reader.Read())
                            {
                                books.Add(new BookProduct
                                {
                                 /*   bookId = (int)reader[" bookId"],*/
                                    bookName=(string)reader["bookName"],
                                    bookImage=(string)reader["bookImage"],
                                    price = (int)reader["price"],
                                    quantity = (int)reader["quantity"],
                                    author = (string)reader["author"],
                                    description = (string)reader["description"]
                                });
                            }
                   }
                   _conn.Close();
             }
                    return books;
         }


        public int deleteBook(int id) {
            SqlCommand command = new SqlCommand("spdeleteBook")
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@bookId", id);
            _conn.Open();
            command.Connection = _conn;
            command.ExecuteNonQuery();
            _conn.Close();
            return id;

        }

        public List<BookProduct> getBookById(int id) {
            List<BookProduct> book = new List<BookProduct>();
            _conn.Open();
            SqlCommand command = new SqlCommand("spGetBookById",_conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@bookId", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    book.Add(new BookProduct
                    {
                  /*      bookId = (int)reader[" bookId"],*/
                        bookName = (string)reader["bookName"],
                        bookImage = (string)reader["bookImage"],
                        price = (int)reader["price"],
                        quantity = (int)reader["quantity"],
                        author = (string)reader["author"],
                        description = (string)reader["description"]
                    });
                }
            }
            _conn.Close();
            return book;
        }
        
    }
}
