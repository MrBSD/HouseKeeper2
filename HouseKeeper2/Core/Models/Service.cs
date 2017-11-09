using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseKeeper2.Core.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public int? CounterId { get; set; }
        public Counter Counter { get; set; }

    }
}