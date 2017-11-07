using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseKeeper2.Core.Models
{
    public class Measurement
    {
        public int Id { get; set; }

        
        public int CounterId { get; set; }
        public Counter Counter { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Display { get; set; }
    }
}