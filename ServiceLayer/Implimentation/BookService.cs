using ModelLayer;
using RepositoryLayer.Interface;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Implimentation
{
    public class BookService:IBookService
    {
        private IBookRepository _repository ;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
         
        }
        public BookProduct AddBook(BookProduct book) {

            return _repository.AddBook(book);
        }
    }
}
