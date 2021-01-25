using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookStoreApp.Controllers
{
    public class userController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
