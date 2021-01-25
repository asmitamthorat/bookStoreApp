using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ServiceLayer.Implimentation;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace bookStoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class userController : Controller
    {
        private readonly ServiceLayer.Interface.IuserService _service;
        public userController(IuserService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] userRegistration userData)
        {
            userRegistration result = _service.addUser(userData);
            return Ok(new response<userRegistration> { StatusCode = (int)HttpStatusCode.OK, Message = "successful", Data = result });
        }

        [HttpPost]
        public IActionResult loginUser([FromBody] userRegistration userData) {
            userRegistration result = _service.loginUser(userData);
            return Ok(new response<userRegistration> { StatusCode = (int)HttpStatusCode.OK, Message = "successful", Data = result });

        }
    }
}
