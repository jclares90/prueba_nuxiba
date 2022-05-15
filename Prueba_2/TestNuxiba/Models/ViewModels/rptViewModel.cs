using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestNuxiba.Models;
using TestNuxiba.Models.ViewModels;

namespace TestNuxiba.Models.ViewModels
{
    public class rptViewModel
    {
        public string Login { get; set; }
        public string Nombre { get; set; }
        public decimal? Sueldo { get; set; }
        public DateTime? FechaIngreso { get; set; }

        public static List<rptViewModel> GenerarDummyReporte()
        {
            List<rptViewModel> registros = new List<rptViewModel>();
            using (TestDevEntities bd = new TestDevEntities())
            {
                registros = (from d in bd.vw_usuarios
                       select new rptViewModel
                       {
                           Login = d.Login,
                           Nombre = d.Nombre,
                           Sueldo = d.Sueldo,
                           FechaIngreso = d.FechaIngreso
                       }).ToList();
            }
            return registros;
        }
    }
}