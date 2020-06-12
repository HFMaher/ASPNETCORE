using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.EfCode;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.CheckoutServices;

namespace WellStore.Controllers
{
    public class CheckoutController :Controller
    {
        private readonly EfCoreContext _context;

        public CheckoutController(EfCoreContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {

            var listService = new CheckoutService(_context, HttpContext.Request.Cookies);
           
            return View(listService.GetCheckoutList());  //convert cookie into ImmutableList<CheckoutItemDto>
        }

        public IActionResult Buy(OrderItem itemToBuy)
        {
            var cookie = new CheckoutCookie(HttpContext.Request.Cookies, HttpContext.Response.Cookies);  //create a new cookie
            var service = new CheckoutCookieService(cookie.GetValue()); //create a new List of OrderLineItem and add the items in the existing cookie to it
            service.AddLineItem(itemToBuy);                             //add itemto Buy to the List of OrderLineitems
            cookie.AddOrUpdateCookie(service.EncodeForCookie());        //update cookie
          
            return RedirectToAction("Index");
        }

        public IActionResult DeleteLineItem(int lineNum)
        {
            var cookie = new CheckoutCookie(HttpContext.Request.Cookies, HttpContext.Response.Cookies);
            var service = new CheckoutCookieService(cookie.GetValue());
            service.DeleteLineItem(lineNum);
            cookie.AddOrUpdateCookie(service.EncodeForCookie());
           
            return RedirectToAction("Index");
        }

       
    }
}