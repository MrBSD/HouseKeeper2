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
    public class MeasurementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeasurementsController()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<ActionResult> Create(int counterId)
        {
            var counter = await _context.Counters.SingleAsync(c => c.Id == counterId);
            var viewModel = new MeasurementViewModel
            {
                CounterId = counterId,
                CounterName = counter.Name,
                Date = DateTime.Now
            };
            return View("MeasurementViewForm", viewModel);
        }

        // GET: Measurements
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Save(MeasurementViewModel measurementViewModel)
        {
            if (!ModelState.IsValid)
                return View("MeasurementViewForm", measurementViewModel);

            if (measurementViewModel.Id == 0)
            {
                var measurement = new Measurement
                {
                    CounterId = measurementViewModel.CounterId,
                    Date = measurementViewModel.Date,
                    Display = measurementViewModel.Display
                };
                _context.Measurements.Add(measurement);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Counters");
        }
    }
}