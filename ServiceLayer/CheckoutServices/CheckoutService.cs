using DataLayer.EfCode;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace ServiceLayer.CheckoutServices
{
    public class CheckoutService
    {
        private readonly EfCoreContext _context;
        private readonly IRequestCookieCollection _cookiesIn;

        public CheckoutService(EfCoreContext context, IRequestCookieCollection cookiesIn)
        {
            _context = context;
            _cookiesIn = cookiesIn;
        }

        public ImmutableList<CheckoutItemDto> GetCheckoutList()
        {
            var cookieHandler = new CheckoutCookie(_cookiesIn);
            var service = new CheckoutCookieService(cookieHandler.GetValue()); //convert cookie into CheckoutItemDto

            return GetCheckoutList(service.LineItems);
        }

        public ImmutableList<CheckoutItemDto> GetCheckoutList(IImmutableList<OrderItem> lineItems)
        {
            var result = new List<CheckoutItemDto>();
            foreach (var lineItem in lineItems)
            {
                result.Add(_context.Products.Select(product => new CheckoutItemDto
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                   
                    Price = product.Price,

                    supplier=product.Supplier
                   
                }).Single(y => y.ProductId == lineItem.ProductId));
            }
            return result.ToImmutableList();
        }
    }
}
