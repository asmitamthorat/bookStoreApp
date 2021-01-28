using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using RepositoryLayer.Interface;
using ServiceLayer.Implimentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace bookStoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDetailsController : Controller
    {
        private readonly ICustomerDetailsRepository _service;
        public UserDetailsController(ICustomerDetailsRepository service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult addCustomerDetails(CustomerDetails customerDetails) 
        {
            CustomerDetails result = _service.AddCustomerDetails(customerDetails);
            return Ok(new response<CustomerDetails> { StatusCode = (int)HttpStatusCode.OK, Message = "successful", Data = result });
        }
    }
}
