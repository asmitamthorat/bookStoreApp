using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer
{
    public class CustomerDetails
    {
        public int CustomerId { get; set; }
       
        public string Fullname { get; set; }
       
        public string phone { get; set; }
       
        public string pincode { get; set; }
        public string addressType { get; set; }
        public string fullAddress { get; set; }
       
        public string email { get; set; }

        public string city { get; set; }

        public string state { get; set; }
    }
}
