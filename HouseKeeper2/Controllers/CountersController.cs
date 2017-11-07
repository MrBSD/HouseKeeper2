using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
        // GET: Counters
        public async Task<ActionResult> Index()
        {
            var counters = await _context.Counters
                .Include(c => c.Measurements)
                .ToListAsync();

           

            return View(counters);
        }
    }
}