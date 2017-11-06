using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseKeeper2.Core.Models
{
    public class Tariff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginingDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal Price { get; set; }

    }
}