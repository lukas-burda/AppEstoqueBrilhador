using System;
using System.Collections.Generic;
using System.Text;

namespace AppDomain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Amount { get { return Quantity * Price; } }
        public int ProviderId { get; set; }
    }
}
