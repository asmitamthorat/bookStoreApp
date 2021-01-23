using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookRepository
    {
        BookProduct AddBook(BookProduct book);
        int deleteBook(int id);
        List<BookProduct> getBooks();
       

        List<BookProduct> getBookById(int id);
    }
}
