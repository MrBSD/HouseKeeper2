using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HouseKeeper2.Core.Models;
using HouseKeeper2.Core.Repositories;
using HouseKeeper2.Persistence;
using HouseKeeper2.Persistence.Repositories;

namespace HouseKeeper2.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController()
        {
            _context = new ApplicationDbContext();
        }
         
        // GET: Services/create
        public ActionResult Create()
        {
            var service = new Service(){Id = 0};
            return View("ServiceForm", service);
        }

        // PUT: Services/edit
       
        public async Task<ActionResult> Edit(int id)
        {
            var service = await _context.Services.SingleOrDefaultAsync(s => s.Id == id);
            return View("ServiceForm", service);
        }

        // GET: Services
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var services = await _context.Services.ToListAsync();
            return View(services);
        }

       

        //POST: Services/create
        [HttpPost]
        public async Task<ActionResult> Save(Service service)
        {
            if (!ModelState.IsValid)
                return View("ServiceForm", service);

            if (service.Id==0)
            {
                 _context.Services.Add(service);
            }
            else
            {
                var serviceInDb = await _context.Services.SingleAsync(s => s.Id == service.Id);
                serviceInDb.Name = service.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Services");
        }

     
        public async Task<ActionResult> Delete(int id)
        {
            var serviceToDelete = await _context.Services.SingleOrDefaultAsync(s => s.Id == id);

            if (serviceToDelete == null)
                return RedirectToAction("Index", "Services");

            _context.Services.Remove(serviceToDelete);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Services");
        }
    }
}