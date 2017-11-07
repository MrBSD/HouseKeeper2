using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HouseKeeper2.Core.Models;

namespace HouseKeeper2.Core.ViewModels
{
    public class CounterViewModel
    {
        public Counter Counter { get; set; }
        public Measurement CurrentMeasurement { get; set; }
       
    }
}