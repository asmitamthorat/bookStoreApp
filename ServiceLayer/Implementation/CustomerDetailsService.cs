using ModelLayer;
using RepositoryLayer.Implementation;
using RepositoryLayer.Interface;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Implementation
{
    public class CustomerDetailsService:ICustomerDetailsService
    {
        private CustomerDetailsRepository _repository;
        public CustomerDetailsService(CustomerDetailsRepository repository)
        {
            _repository = repository;
        }

        public CustomerDetails AddCustomerDetails(CustomerDetails customerDetails) 
        {
            CustomerDetails result = _repository.AddCustomerDetails(customerDetails);
            return result;
        }
    }
}
