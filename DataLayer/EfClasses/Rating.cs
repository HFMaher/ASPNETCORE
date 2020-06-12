using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EfClasses
{
   public class Rating
    {
        public long ratingId { get; set; }

        public int Stars { get; set; }

        public Product product { get; set; }


    }
}
