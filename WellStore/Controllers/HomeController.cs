using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.EfCode;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ProductServices;
using ServiceLayer.ProductServices.Concrete;
using WellStore.Models;

namespace WellStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly EfCoreContext _context;

        public HomeController(EfCoreContext context)   
        {                                              
            _context = context;                        
        }                                              

        public IActionResult Index                     
            (SortFilterPageOptions options)            
        {
            var listService =                          
                new ListProductsService(_context);        

            var productList = listService                 
                .SortFilterPage(options)               
                .ToList();                             

            var traceIdent = HttpContext.TraceIdentifier;
        
            return View(new ProductListCombinedDto         
                (traceIdent, options, productList));
        }

            public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [HttpGet]
        public JsonResult GetFilterSearchContent    
           (SortFilterPageOptions options)         
        {
            var service = new                      
                ProductFilterDropDownService(_context);

            var traceIdent = HttpContext.TraceIdentifier; 

            return Json(                            
               
                service.GetFilterDropDownValues(    
                    options.FilterBy));            
        }
    }
}
