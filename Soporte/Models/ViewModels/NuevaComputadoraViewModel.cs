using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Soporte.Models.ViewModels
{
    public class NuevaComputadoraViewModel
    {
        [Required]
        public int IDcomputadora { get; set; }
        [Required]
        public string ST { get; set; }
        public string numerSerie { get; set; }
        [Required]
        public string Equipo { get; set; }
        [Required]
        public string Lugar { get; set; }
        [Required]
        public string Sector { get; set; }
        public int Telefono { get; set; }
        public string stMonitor { get; set; }
        public string nroSerieMonitor { get; set; }
        public string sistemaOperativo { get; set; }
        public string memoriaRam { get; set; }
        public string Procesador { get; set; }
        public string Observaciones { get; set; }

    }
}