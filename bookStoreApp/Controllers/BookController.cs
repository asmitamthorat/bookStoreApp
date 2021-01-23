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
             return Ok(new response<BookProduct> { StatusCode = (int)HttpStatusCode.OK, Message = "successful", Data = result });

        }
        
        [HttpGet]
        public IActionResult getBooks() {
            List<BookProduct> result = _service.getBooks();
            return Ok(new response<List<BookProduct>> { StatusCode = (int)HttpStatusCode.OK, Message = "successful", Data = result });

        }

        

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) {
            int result = _service.deleteBook(id);
            return Ok(new response<int> { StatusCode = (int)HttpStatusCode.OK, Message = "successful", Data = result });

        }

        [HttpGet("{id}")]
        public IActionResult getBookById(int id) {
            List<BookProduct> book = _service.getBookById(id);
            return Ok(book);
        }

    }
}
