using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HouseKeeper2.Core.Models;

namespace HouseKeeper2.Core.ViewModels
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }


    }
}