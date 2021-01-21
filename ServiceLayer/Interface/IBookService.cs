using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interface
{
    public interface IBookService
    {
      BookProduct AddBook(BookProduct book);
    }
}
