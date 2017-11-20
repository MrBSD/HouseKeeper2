using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HouseKeeper2.Persistence;

namespace HouseKeeper2.Controllers.Api
{
    public class ServiceBillsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ServiceBillsController()
        {
            _context = new ApplicationDbContext();
            
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var serviceBill = await _context.ServiceBills.SingleOrDefaultAsync(sb => sb.Id == id);
            if (serviceBill == null)
                return NotFound();

            _context.ServiceBills.Remove(serviceBill);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetPreviousMeasurement(int serviceId, DateTime period)
        {
            var previousMonth = period.AddMonths(-1);
            var result = await _context.ServiceBills
                .Where(s => s.ServiceId == serviceId && s.Period == previousMonth)
                .SingleAsync();
            return Ok(result.Measurement);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTotal(int serviceId, int tariffId, DateTime period, int measurement)
        {
            //if (serviceBillDto == null)
            //    return BadRequest();
            var previousMonth = period.AddMonths(-1);

            var previousServiceBill = await _context.ServiceBills
                .Where(s => s.ServiceId == serviceId && s.Period == previousMonth)
                .SingleOrDefaultAsync();

            if (previousServiceBill == null)
                return NotFound();

            var tariff = await _context.Tariffs.SingleOrDefaultAsync(t => t.Id == tariffId);

            var result = (measurement - previousServiceBill.Measurement) * tariff.Price;

            return Ok(result);
        }


    }
}
