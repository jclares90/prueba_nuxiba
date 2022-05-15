using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestNuxiba.Models.ViewModels
{
    public class TblempleadoViewModel
    {
        public int id { get; set; }
        public int userid { get; set; }
        [Required]
        [Display(Name = "Sueldo")]
        public double Sueldo { get; set; }
        [Required]
        [Display(Name = "FechaIngreso")]
        public string FechaIngreso { get; set; }
    }
}