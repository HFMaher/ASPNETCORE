using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.EditServices
{
   public class ChangePriceDto
    {
        public long ProductId { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
