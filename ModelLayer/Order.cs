using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer
{
    public class Order
    {
        public int  OrderId {get;set;}
        public List<CartItem> orders { get; set; }
        public CustomerDetails customer { get; set; }

    }
}
