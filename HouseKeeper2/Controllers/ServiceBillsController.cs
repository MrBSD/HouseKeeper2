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
    public class ServiceBillsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ServiceBillsController()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<ActionResult> Create()
        {
            var viewModel = new ServiceBillFormView
            {
                Services = await _context.Services.ToListAsync(),
                Tariffs = await _context.Tariffs.ToListAsync()
            };
            return View("ServiceBillForm", viewModel);
        }
        
        // GET: ServiceBills
        public async Task<ActionResult> Index()
        {
            var serviceBills = await _context.ServiceBills
                .Include(s => s.Service)
                .Include(s=>s.Tariff)
                .ToListAsync();

            return View("Index", serviceBills);
        }

        public async Task<ActionResult> Save(ServiceBillFormView serviceBillFormView)
        {
            if (serviceBillFormView.Id == 0)
            {
                var serviceBill = new ServiceBill
                {
                    Id = serviceBillFormView.Id,
                    ServiceId = serviceBillFormView.ServiceId,
                    TariffId = serviceBillFormView.TariffId,
                    Measurement = serviceBillFormView.Measurement,
                    Period = serviceBillFormView.Period
                };
                _context.ServiceBills.Add(serviceBill);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "ServiceBills");
        }

    }
}