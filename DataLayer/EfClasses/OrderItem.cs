using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.EfClasses
{
    public class OrderItem : IValidatableObject 
    {
        public int LineItemId { get; set; }

        [Range(1, 5, ErrorMessage =                      
            "This order is over the limit of 5 products.")] 
        public byte LineNum { get; set; }

        public short NumProducts { get; set; }

       
        public decimal ProductPrice { get; set; }

      

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public Product ChosenProduct { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate 
            (ValidationContext validationContext)                 
        {
            var currContext =
                validationContext.GetService(typeof(DbContext));

            if (ChosenProduct.Price < 0)                      
                yield return new ValidationResult(         
$"Sorry, the product '{ChosenProduct.Name}' is not for sale."); 

            if (NumProducts > 100)
                yield return new ValidationResult(
"If you want to order a 100 or more products" +       
" please phone us on 01234-5678-90",              
                    new[] { nameof(NumProducts) }); 
        }
    }
 
}

