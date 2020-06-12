using System.Globalization;
using DataLayer.EfClasses;
using DataLayer.EfCode;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using ServiceLayer.EditServices.Concrete;
using ServiceLayer.EditServices;

namespace WellStore.Controllers
{
    public class EditController :Controller
    {
        private readonly EfCoreContext _context;
        private readonly IHostingEnvironment _env;

        public EditController(EfCoreContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

       

        public IActionResult ChangePrice(int id)           //receive id and create a ChangePubDateDto and pass it to the View
        {
           

            var service = new ChangePriceService(_context);
            var dto = service.GetOriginal(id);
           
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePrice(ChangePriceDto dto)  //the ChangePubDateDto is received from the above method
        {
            

            var service = new ChangePriceService(_context);
            service.UpdateProduct(dto);
            
            return View("ProductUpdated", "Successfully changed publication date");
        }

    }


}