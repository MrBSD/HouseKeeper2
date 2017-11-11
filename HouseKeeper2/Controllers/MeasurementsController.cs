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

        public async Task<ActionResult> Edit(int id)
        {
            var measurementInDb = await _context.Measurements
                .SingleOrDefaultAsync(m => m.Id == id);

            var counter = await _context.Counters.SingleOrDefaultAsync(c => c.Id == measurementInDb.CounterId);

            var viewModel = new MeasurementViewModel
            {
                Id = measurementInDb.Id,
                CounterId = measurementInDb.CounterId,
                CounterName = counter.Name,
                Date = measurementInDb.Date,
                Display = measurementInDb.Display

            };

            return View("MeasurementViewForm", viewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var measurementInDb = await _context.Measurements.SingleAsync(m => m.Id == id);
            _context.Measurements.Remove(measurementInDb);
            await _context.SaveChangesAsync();

            return RedirectToAction("ShowMeasurementsHistory", "Measurements", new {counterId=measurementInDb.CounterId});
        }

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

            else
            {
                var measurementInDb = await _context.Measurements.SingleAsync(m => m.Id == measurementViewModel.Id);
            measurementInDb.Date = measurementViewModel.Date;
            measurementInDb.Display = measurementViewModel.Display;
            }
            

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Counters");
        }

        public async Task<ActionResult> ShowMeasurementsHistory(int counterId)
        {
            var measurements = await _context.Measurements
                .Where(m => m.CounterId == counterId)
                .ToListAsync();

            return View("MeasurementsHistoryView", measurements);
        }

    }
}