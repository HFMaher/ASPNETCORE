using DataLayer.EfClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.CheckoutServices
{
    public class CheckoutItemDto
    {
        public long ProductId { get; internal set; }

        

        public string Name { get; internal set; }

        public decimal Price { get; internal set; }

        public int ProductCount { get; set; }

        public Supplier supplier;

       

    }
}
