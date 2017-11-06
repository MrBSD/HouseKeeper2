using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseKeeper2.Core.Models
{
    public class Tariff
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime BeginingDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}