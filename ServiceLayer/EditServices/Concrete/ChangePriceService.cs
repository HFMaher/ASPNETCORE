using DataLayer.EfClasses;
using DataLayer.EfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.EditServices.Concrete
{
   public class ChangePriceService
    {

        private readonly EfCoreContext _context;

        public ChangePriceService(EfCoreContext context)
        {
            _context = context;
        }



        public ChangePriceDto GetOriginal(int id)    
        {
            return _context.Products
                .Select(p => new ChangePriceDto      
                {                                      
                    ProductId = p.ProductId ,                 
                    Name=p.Name,          
                    Price=p.Price     
                })                                     
                .Single(k => k.ProductId == id);          
        }

        public Product UpdateProduct(ChangePriceDto dto)   
        {
            var product = _context.Find<Product>(dto.ProductId);
            product.Price = dto.Price;     
            _context.SaveChanges();                    
            return product;                               
        }
    }
}
