using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HouseKeeper2.Core.Models;
using HouseKeeper2.Core.Repositories;
using HouseKeeper2.Core.ViewModels;
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
            var viewModel = new ServiceViewModel();
            return View("ServiceForm", viewModel);
        }

        // PUT: Services/edit
       
        public async Task<ActionResult> Edit(int id)
        {
            var serviceInDb = await _context.Services
                .SingleAsync(s => s.Id == id);
            var viewModel = new ServiceViewModel
            {
                Id = serviceInDb.Id,
                Name = serviceInDb.Name
            };
            
        
            return View("ServiceForm", viewModel);
        }

        // GET: Services
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var services = await _context.Services
                .ToListAsync();
            return View(services);
        }

       

        //POST: Services/create
        [HttpPost]
        public async Task<ActionResult> Save(ServiceViewModel serviceViewModel)
        {
            if (!ModelState.IsValid)
                return View("ServiceForm", serviceViewModel);

            if (serviceViewModel.Id ==0)
            {
                var service = new Service
                {
                    Name = serviceViewModel.Name,
                };
                _context.Services.Add(service);
            }
            else
            {
                var serviceInDb = await _context.Services.SingleAsync(s => s.Id == serviceViewModel.Id);
                serviceInDb.Name = serviceViewModel.Name;
            }
            await _context.SaveChangesAsync();
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