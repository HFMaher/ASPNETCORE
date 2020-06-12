using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EfClasses
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime DateOrderedUtc { get; set; }

       
        public Guid CustomerName { get; set; }

     

        public ICollection<OrderItem> LineItems { get; set; }

       

        public string OrderNumber => $"SO{OrderId:D6}";

        public Order()
        {
            DateOrderedUtc = DateTime.UtcNow;
        }
    }
}
