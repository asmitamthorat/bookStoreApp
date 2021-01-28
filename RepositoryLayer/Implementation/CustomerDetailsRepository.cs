using Microsoft.Extensions.Configuration;
using ModelLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Implementation
{
    public class CustomerDetailsRepository:ICustomerDetailsRepository
    {
        private IConfiguration _configuration;
        private string _connectionString;
        private SqlConnection _conn;
        public CustomerDetailsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("BookStoreAppDB");
            _conn = new SqlConnection(_connectionString);
        }

        public CustomerDetails AddCustomerDetails(CustomerDetails customerDetails)
        {
            SqlCommand command = new SqlCommand("spAddCutomerDetails")
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Fullname", customerDetails.Fullname);
            command.Parameters.AddWithValue("@fullAddress", customerDetails.fullAddress);
            command.Parameters.AddWithValue("@email", customerDetails.email);
            command.Parameters.AddWithValue("@city", customerDetails.city);
            command.Parameters.AddWithValue("@addressType", customerDetails.addressType);
            command.Parameters.AddWithValue("@phone", customerDetails.phone);
            command.Parameters.AddWithValue("@pincode", customerDetails.pincode);
            command.Parameters.AddWithValue("@state", customerDetails.state);
           
            _conn.Open();
            command.Connection = _conn;
            command.ExecuteNonQuery();
            _conn.Close();
            return customerDetails;

        }

    }
}
