using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HouseKeeper2.Core.Models;

namespace HouseKeeper2.Core.ViewModels
{
    public class ServiceBillFormView
    {
        public int Id { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int TariffId { get; set; }

        [Required]
        public DateTime Period { get; set; }

        public int Measurement { get; set; }
        public decimal TotalForPayment { get; set; }

        public ICollection<Service> Services { get; set; }
        public ICollection<Tariff> Tariffs { get; set; }

    }
}