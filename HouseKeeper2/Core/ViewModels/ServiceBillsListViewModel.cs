using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseKeeper2.Core.Models;

namespace HouseKeeper2.Core.ViewModels
{
    public class ServiceBillsListViewModel
    {
        public IEnumerable<ServiceBill> ServiceBills { get; set; }
        public DateTime Period { get; set; }
    }
}