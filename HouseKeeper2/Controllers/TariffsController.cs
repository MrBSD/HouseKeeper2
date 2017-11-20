using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HouseKeeper2.Core.Models;
using HouseKeeper2.Persistence;

namespace HouseKeeper2.Controllers
{
    [Authorize]
    public class TariffsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TariffsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var tariff = new Tariff();
            return View("TariffViewForm", tariff);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var tariff = await _context.Tariffs.SingleOrDefaultAsync(t => t.Id == id);
            if (tariff == null)
                return HttpNotFound();

            _context.Tariffs.Remove(tariff);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Tariffs");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var tariff = await _context.Tariffs.SingleOrDefaultAsync(t => t.Id == id);
            if (tariff == null)
                return HttpNotFound();

            return View("TariffViewForm", tariff);
        }
        
        
        public async Task<ActionResult> Index()
        {
            var tariffsList = await _context.Tariffs.ToListAsync();
            return View(tariffsList);
        }

        [HttpPost]
        public async Task<ActionResult> Save(Tariff tariff)
        {
            if (!ModelState.IsValid)
                return View("TariffViewForm", tariff);

            if (tariff.Id == 0)
            {
                _context.Tariffs.Add(tariff);
            }
            else
            {
                var tariffInDb = await _context.Tariffs.SingleAsync(t => t.Id == tariff.Id);
            tariffInDb.BeginingDate = tariff.BeginingDate;
            tariffInDb.ExpirationDate = tariff.ExpirationDate;
            tariffInDb.Name = tariff.Name;
            tariffInDb.Price = tariff.Price;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Tariffs");
        }
    }
}