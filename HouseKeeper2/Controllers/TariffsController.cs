using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HouseKeeper2.Persistence;

namespace HouseKeeper2.Controllers
{
    public class TariffsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TariffsController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET: Tariffs
        public async Task<ActionResult> Index()
        {
            var tariffsList = await _context.Tariffs.ToListAsync();
            return View(tariffsList);
        }
    }
}