using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        
        // GET: Services
        public ActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }
    }
}