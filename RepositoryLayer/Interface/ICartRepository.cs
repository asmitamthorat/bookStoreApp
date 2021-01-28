﻿using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRepository
    {
        CartItem AddToCart(int userId, CartItem cart);
        int RemoveFromCart(int userId, int bookId);
        List<CartItem> GetCartOfUser(int userId);
    }
}
