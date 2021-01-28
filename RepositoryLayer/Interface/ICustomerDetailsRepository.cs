using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICustomerDetailsRepository
    {
        CustomerDetails AddCustomerDetails(CustomerDetails customerDetails);
    }
}
