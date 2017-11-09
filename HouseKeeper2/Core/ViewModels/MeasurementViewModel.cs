using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseKeeper2.Core.ViewModels
{
    public class MeasurementViewModel
    {
        public int Id { get; set; }


        public int CounterId { get; set; }
        public string CounterName { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Display { get; set; }
    }
}