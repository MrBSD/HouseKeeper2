﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseKeeper2.Core.Models
{
    public class Counter
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string SerialNumber { get; set; }

        public ICollection<Measurement> Measurements { get; set; }

        public Counter()
        {
            Measurements = new List<Measurement>();
        }

       
    }
}