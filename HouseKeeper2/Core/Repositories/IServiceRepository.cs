using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseKeeper2.Core.Models;

namespace HouseKeeper2.Core.Repositories
{
    interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServices();
    }
}
