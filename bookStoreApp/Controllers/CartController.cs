﻿using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ServiceLayer.Implimentation;
using ServiceLayer.Interface;
using ServiceLayer.TokenAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace bookStoreApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [TokenAuthentificationFilter]
    public class CartController : Controller
    {
        private readonly ServiceLayer.Interface.ICartService _service;
        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddToCart(CartItem cart)
        {
            int userId = Convert.ToInt32(HttpContext.Items["userId"]);
            CartItem result = _service.AddTocart(userId,cart);
            return Ok(new response<CartItem> { StatusCode = (int)HttpStatusCode.OK, Message = "successful", Data = result });
        }
    }
}
