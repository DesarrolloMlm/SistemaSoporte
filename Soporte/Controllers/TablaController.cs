using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Soporte.Models;
using Soporte.Models.ViewModels;

namespace Soporte.Controllers
{
    //Agregas las directivas del viewmodel y del modelo de tu programa para que los puedas usar
    //Recordar que la vista tiene que estar en el mismo controlador
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {

            //se crea la lista de la tabla
            List<TablaComputadorasViewModel> listaComputadoras;
            //Creas la conecxion con tu View model para visualizar los datos
            using (baseSoporteEntities db = new baseSoporteEntities())
            {
                //Creas la lista de compus y asignas los nombres de las columnas de tu tabla
                listaComputadoras = (from d in db.ComputadorasSet
                                     select new TablaComputadorasViewModel
                                     {
                                         IDcomputadora = d.IDcomputadora,
                                         ST = d.ST,
                                         numerSerie = d.numerSerie,
                                         Equipo = d.Equipo,
                                         Lugar = d.Lugar,
                                         Sector = d.Sector,
                                         Telefono = d.Telefono, //para el tipo Int , se agrega el value al final
                                         stMonitor = d.stMonitor,
                                         nroSerieMonitor = d.nroSerieMonitor,
                                         sistemaOperativo = d.sistemaOperativo,
                                         memoriaRam = d.memoriaRam,
                                         Procesador = d.Procesador,
                                         Observaciones = d.Observaciones
                                     }).ToList();
            }
            return View(listaComputadoras);
        }

        public ActionResult NuevaComputadora()
        {
            return View();
        }

        //HttpPost es para ingresar datos a la base de datos, se deben crear dos action result, uno que 
        //reciba los datos para cargar y el otro que devuelva la vista.
        [HttpPost]
        public ActionResult NuevaComputadora(TablaComputadorasViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (baseSoporteEntities db = new baseSoporteEntities())
                    {
                        var oTabla = new Computadoras();
                        oTabla.IDcomputadora = model.IDcomputadora;
                        oTabla.ST = model.ST;
                        oTabla.numerSerie = model.numerSerie;
                        oTabla.Equipo = model.Equipo;
                        oTabla.Lugar = model.Lugar;
                        oTabla.Sector = model.Sector;
                        oTabla.Telefono = model.Telefono;
                        oTabla.stMonitor = model.stMonitor;
                        oTabla.nroSerieMonitor = model.nroSerieMonitor;
                        oTabla.sistemaOperativo = model.sistemaOperativo;
                        oTabla.memoriaRam = model.memoriaRam;
                        oTabla.Procesador = model.Procesador;
                        oTabla.Observaciones = model.Observaciones;

                        db.ComputadorasSet.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("~/Tabla/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult EditarComputadora(int Id)
        {
            TablaComputadorasViewModel model = new TablaComputadorasViewModel();
            using (baseSoporteEntities db = new baseSoporteEntities())
            {
                var oTabla = db.ComputadorasSet.Find(Id);
                model.IDcomputadora = oTabla.IDcomputadora;
                model.ST = oTabla.ST;
                model.numerSerie = oTabla.numerSerie;
                model.Equipo = oTabla.Equipo;
                model.Lugar = oTabla.Lugar;
                model.Sector = oTabla.Sector;
                model.Telefono = oTabla.Telefono;
                model.stMonitor = oTabla.stMonitor;
                model.nroSerieMonitor = oTabla.nroSerieMonitor;
                model.sistemaOperativo = oTabla.sistemaOperativo;
                model.memoriaRam = oTabla.memoriaRam;
                model.Procesador = oTabla.Procesador;
                model.Observaciones = oTabla.Observaciones;
            }
            return View(model);
        }

        //HttpPost es para editar y eliminar datos a la base de datos, se deben crear dos action result, uno que 
        //reciba los datos para cargar y el otro que devuelva la vista.
        [HttpPost]
        public ActionResult EditarComputadora(TablaComputadorasViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (baseSoporteEntities db = new baseSoporteEntities())
                    {
                        var oTabla = db.ComputadorasSet.Find(model.IDcomputadora);
                        oTabla.ST = model.ST;
                        oTabla.IDcomputadora = model.IDcomputadora;
                        oTabla.numerSerie = model.numerSerie;
                        oTabla.Equipo = model.Equipo;
                        oTabla.Lugar = model.Lugar;
                        oTabla.Sector = model.Sector;
                        oTabla.Telefono = model.Telefono;
                        oTabla.stMonitor = model.stMonitor;
                        oTabla.nroSerieMonitor = model.nroSerieMonitor;
                        oTabla.sistemaOperativo = model.sistemaOperativo;
                        oTabla.memoriaRam = model.memoriaRam;
                        oTabla.Procesador = model.Procesador;
                        oTabla.Observaciones = model.Observaciones;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Tabla/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult EliminarComputadora(int Id)
        {
            TablaComputadorasViewModel model = new TablaComputadorasViewModel();
            using (baseSoporteEntities db = new baseSoporteEntities())
            {
                var oTabla = db.ComputadorasSet.Find(Id);
                db.ComputadorasSet.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("~/Tabla/");
        }
    }
}