using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestNuxiba.Models.ViewModels
{
    public class VwViewModel
    {
        public int userid { get; set; }
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Paterno")]
        public string Paterno { get; set; }
        [Required]
        [Display(Name = "Materno")]
        public string Materno { get; set; }
        [Required]
        [Display(Name = "Sueldo")]
        public decimal? Sueldo { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "FechaIngreso")]
        public DateTime? FechaIngreso { get; set; }
    }
}