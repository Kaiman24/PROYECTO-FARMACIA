using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaAPI.Models
{
	public class Proveedor
	{
		public int Id { get; set; }
		public string nombreProveedor { get; set;}
        public string ciudadProveedor { get; set; }
        public string direccionProveedor { get; set; }
        public string telefonoProveedor { get; set; }        
    }
}