using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseKeeper2.Core.Models
{
    public class ServiceBill
    {
        public int Id { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        [Required]
        public int TariffId { get; set; }   
        public Tariff Tariff { get; set; }

        [Required]
        public DateTime Period { get; set; }

        public int Measurement { get; set; }    

        public decimal TotalForPayment { get; set; }
    }
}