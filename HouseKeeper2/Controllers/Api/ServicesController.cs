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
    public class ServicesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ServicesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var serviceInDb =  _context.Services.SingleOrDefault(s => s.Id == id);
            if (serviceInDb == null)
                return BadRequest();

            _context.Services.Remove(serviceInDb);
             _context.SaveChangesAsync();

            return Ok();
        }
    }
}
