using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interface
{
    public interface ICartService
    {
        CartItem AddTocart(int userId, CartItem cart);
        int RemoveFromCart(int userId, int bookId);
    }
}
