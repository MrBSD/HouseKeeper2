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

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string SerialNumber { get; set; }



    }
}