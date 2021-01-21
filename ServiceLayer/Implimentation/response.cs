using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Implimentation
{
    public class response<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public String Message { get; set; } = null;
    }
}
