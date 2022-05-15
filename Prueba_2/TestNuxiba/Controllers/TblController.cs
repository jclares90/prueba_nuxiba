using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestNuxiba.Models;
using TestNuxiba.Models.ViewModels;

namespace TestNuxiba.Controllers
{
    public class TblController : Controller
    {
        // GET: Tbl
        public ActionResult Index()
        {
            List<ListTblViewModel> lst;
            using (TestDevEntities bd = new TestDevEntities())
            {
                lst = (from d in bd.usuarios
                       select new ListTblViewModel
                       {
                           userid = d.userid,
                           Login = d.Login,
                           Nombre = d.Nombre,
                           Paterno = d.Paterno,
                           Materno = d.Materno
                       }).Take(10).ToList();
            }
            return View(lst);
        }

        public void ExportToCSV()
        {
            StringWriter sw = new StringWriter();

            sw.WriteLine("\"Login\",\"Nombre\",\"Sueldo\",\"FechaIngreso\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=ExportedResgistros.csv");
            Response.ContentType = "text/csv";

            var registros = rptViewModel.GenerarDummyReporte();

            foreach (var registro in registros)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"",

                    registro.Login,
                    registro.Nombre,
                    registro.Sueldo,
                    registro.FechaIngreso
                    ));
            }

            Response.Write(sw.ToString());
            Response.End();
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(VwViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using (TestDevEntities bd = new TestDevEntities())
                    {
                        var oTbl = new usuarios();
                        oTbl.Login = model.Login;
                        oTbl.Nombre = model.Nombre;
                        oTbl.Paterno = model.Paterno;
                        oTbl.Materno = model.Materno;

                        bd.usuarios.Add(oTbl);
                        bd.SaveChanges();
                    }
                    return Redirect("~/Tbl/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            VwViewModel model = new VwViewModel();
            using (TestDevEntities bd = new TestDevEntities())
            {
                var oTabla = bd.vw_usuarios.Find(id);
                model.Login = oTabla.Login;
                model.Nombre = oTabla.Nombre;
                model.Paterno = oTabla.Paterno;
                model.Materno = oTabla.Materno;
                model.Sueldo = oTabla.Sueldo;
                model.userid = oTabla.userid;
            }
                return View(model);
        }

        [HttpPost]
        public ActionResult Editar(VwViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TestDevEntities bd = new TestDevEntities())
                    {
                        var oTabla = bd.empleados.Find(model.userid);
                        oTabla.Sueldo = model.Sueldo;

                        bd.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();
                    }
                    return Redirect("~/Tbl/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}