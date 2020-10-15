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
                listaComputadoras = (from d in db.Computadora
                                     select new TablaComputadorasViewModel
                                     {
                                         IDcomputadora = d.IDcomputadora,
                                         ST = d.ST,
                                         numerSerie = d.Nro_Serie,
                                         Equipo = d.Equipo,
                                         Lugar = d.Lugar,
                                         Sector = d.Sector,
                                         Telefono = d.Nro__Telefono.Value, //para el tipo Int , se agrega el value al final
                                         stMonitor = d.ST_Monitor,
                                         nroSerieMonitor = d.Nro__Serie_Monitor,
                                         sistemaOperativo = d.Sistema_Operativo,
                                         memoriaRam = d.Memoria_Ram,
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
                        var oTabla = new Computadora();
                        oTabla.IDcomputadora = model.IDcomputadora;
                        oTabla.ST = model.ST;
                        oTabla.Nro_Serie = model.numerSerie;
                        oTabla.Equipo = model.Equipo;
                        oTabla.Lugar = model.Lugar;
                        oTabla.Sector = model.Sector;
                        oTabla.Nro__Telefono = model.Telefono;
                        oTabla.ST_Monitor = model.stMonitor;
                        oTabla.Nro__Serie_Monitor = model.nroSerieMonitor;
                        oTabla.Sistema_Operativo = model.sistemaOperativo;
                        oTabla.Memoria_Ram = model.memoriaRam;
                        oTabla.Procesador = model.Procesador;
                        oTabla.Observaciones = model.Observaciones;

                        db.Computadora.Add(oTabla);
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
                var oTabla = db.Computadora.Find(Id);
                model.IDcomputadora = oTabla.IDcomputadora;
                model.ST = oTabla.ST;
                model.numerSerie = oTabla.Nro_Serie;
                model.Equipo = oTabla.Equipo;
                model.Lugar = oTabla.Lugar;
                model.Sector = oTabla.Sector;
                model.Telefono = oTabla.Nro__Telefono.Value;
                model.stMonitor = oTabla.ST_Monitor;
                model.nroSerieMonitor = oTabla.Nro__Serie_Monitor;
                model.sistemaOperativo = oTabla.Sistema_Operativo;
                model.memoriaRam = oTabla.Memoria_Ram;
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
                        var oTabla = db.Computadora.Find(model.IDcomputadora);
                        oTabla.ST = model.ST;
                        oTabla.IDcomputadora = model.IDcomputadora;
                        oTabla.Nro_Serie = model.numerSerie;
                        oTabla.Equipo = model.Equipo;
                        oTabla.Lugar = model.Lugar;
                        oTabla.Sector = model.Sector;
                        oTabla.Nro__Telefono = model.Telefono;
                        oTabla.ST_Monitor = model.stMonitor;
                        oTabla.Nro__Serie_Monitor = model.nroSerieMonitor;
                        oTabla.Sistema_Operativo = model.sistemaOperativo;
                        oTabla.Memoria_Ram = model.memoriaRam;
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
                var oTabla = db.Computadora.Find(Id);
                db.Computadora.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("~/Tabla/");
        }
    }
}