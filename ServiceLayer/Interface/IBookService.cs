using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interface
{
    public interface IBookService
    {
        BookProduct AddBook(BookProduct book);
        List<BookProduct> getBooks();
        int deleteBook(int id);
        List<BookProduct> getBookById(int id);
    }
}
