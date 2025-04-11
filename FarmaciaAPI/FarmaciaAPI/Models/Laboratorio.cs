using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaAPI.Models
{
	public class Laboratorio
	{
		public int id { get; set; }
        public string nombreLaboratorio { get; set; }
        public string ciudadLaboratorio { get; set; }
        public string direccionLaboratorio { get; set; }
        public string telefonoLaboratorio { get; set; }

    }
}