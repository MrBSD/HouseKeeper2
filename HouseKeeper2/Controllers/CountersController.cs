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

        public async Task<ActionResult> Delete(int id)
        {
            var counterInDb = await _context.Counters.SingleAsync(c => c.Id == id);
            _context.Counters.Remove(counterInDb);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Counters");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var counter = await _context.Counters.SingleOrDefaultAsync(c => c.Id == id);
            if (counter == null)
                return HttpNotFound();

            var viewModel = new CounterViewModel
            {
                Id = counter.Id,
                Name = counter.Name,
                SerialNumber = counter.SerialNumber
            };

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

            var counterInDb = await _context.Counters.SingleAsync(c=>c.Id==counterViewModel.Id);
            counterInDb.Name = counterViewModel.Name;
            counterInDb.SerialNumber = counterViewModel.SerialNumber;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Counters");
        }
    }
}