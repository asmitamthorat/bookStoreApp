﻿using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRepository
    {
        CartItem AddToCart(int userId, CartItem cart);
    }
}
