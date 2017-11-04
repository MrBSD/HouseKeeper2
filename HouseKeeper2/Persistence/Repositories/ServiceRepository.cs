using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HouseKeeper2.Core.Models;
using HouseKeeper2.Core.Repositories;

namespace HouseKeeper2.Persistence.Repositories
{
    public class ServiceRepository: IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository()
        {
            this._context = new ApplicationDbContext();
        }

        public async Task<IEnumerable<Service>> GetAllServices()
        {
            var result = await _context.Services.ToListAsync();
            return result;
        }
    }
}