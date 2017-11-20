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
    [Authorize]
    public class ServiceBillsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ServiceBillsController()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<ActionResult> Create(DateTime period)
        {
            var viewModel = new ServiceBillFormView
            {
                Services = await _context.Services.ToListAsync(),
                Tariffs = await _context.Tariffs.ToListAsync(),
                Period = period
            };
            return View("ServiceBillForm", viewModel);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var serviceBill = await _context.ServiceBills.SingleAsync(s => s.Id == id);
            var viewModel = new ServiceBillFormView
            {
                Id = serviceBill.Id,
                ServiceId = serviceBill.ServiceId,
                TariffId = serviceBill.TariffId,
                Period = serviceBill.Period,
                Measurement = serviceBill.Measurement,
                TotalForPayment = serviceBill.TotalForPayment,
                Tariffs = await _context.Tariffs.ToListAsync(),
                Services = await  _context.Services.ToListAsync()
            };

            return View("ServiceBillForm", viewModel);
        }
        
        // GET: ServiceBills
        public async Task<ActionResult> Index(DateTime? period)
        {
            DateTime currentPeriod;
            if (period == null)
            {
                currentPeriod = Convert.ToDateTime("10.2017");
            }
            else
            {
                currentPeriod = (DateTime)period;
            }
            var serviceBills = await _context.ServiceBills
                .Include(s => s.Service)
                .Include(s=>s.Tariff)
                .Where(sb=>sb.Period==currentPeriod)
                .ToListAsync();

            var viewModel = new ServiceBillsListViewModel
            {
                ServiceBills = serviceBills,
                Period = currentPeriod
            };

            return View("Index", viewModel);
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
                    Period = serviceBillFormView.Period,
                    TotalForPayment = serviceBillFormView.TotalForPayment
                };
                _context.ServiceBills.Add(serviceBill);
            }
            else
            {
                var serviceBillInDb = await _context.ServiceBills.SingleAsync(s => s.Id == serviceBillFormView.Id);
                serviceBillInDb.Measurement = serviceBillFormView.Measurement;
                serviceBillInDb.Period = serviceBillFormView.Period;
                serviceBillInDb.ServiceId = serviceBillFormView.ServiceId;
                serviceBillInDb.TariffId = serviceBillFormView.TariffId;
                serviceBillInDb.TotalForPayment = serviceBillFormView.TotalForPayment;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "ServiceBills");
        }

       

     

    }
}