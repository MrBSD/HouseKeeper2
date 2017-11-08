using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HouseKeeper2.Core.Models;
using HouseKeeper2.Core.ViewModels;
using HouseKeeper2.Persistence;

namespace HouseKeeper2.Controllers
{
    public class CountersController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CountersController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var viewModel = new CounterViewModel();
            return View("CounterViewForm", viewModel);
        }
        
        // GET: Counters
        public async Task<ActionResult> Index()
        {
            var counters = await _context.Counters
                .Include(c => c.Measurements)
                .ToListAsync();
            return View(counters);
        }


        public async Task<ActionResult> Save(CounterViewModel counterViewModel)
        {
            if (!ModelState.IsValid)
                return View("CounterViewForm", counterViewModel);

            if (counterViewModel.Id == 0)
            {
                var counter = new Counter
                {
                    Name = counterViewModel.Name,
                    SerialNumber = counterViewModel.SerialNumber
                };
                
               
                _context.Counters.Add(counter);
             }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Counters");
        }
    }
}