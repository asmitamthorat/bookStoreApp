using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookStoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookProduct book) {
             BookProduct result= _service.AddBook(book);
            return Ok(result);

        }

       
    }
}
