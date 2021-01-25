using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Implimentation;
using ServiceLayer.Interface;
using ServiceLayer.TokenAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookStoreApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [TokenAuthentificationFilter]
    public class CartController : Controller
    {
        private readonly ServiceLayer.Interface.ICartInterface _service;
        public CartController(ICartInterface service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
