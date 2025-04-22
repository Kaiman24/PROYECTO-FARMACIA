using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaAPI.Models
{
	public class Producto
	{
        public int id { get; set; }
        public int idProducto {  get; set; }
        public string nombreProducto { get; set; }
        public string categoria { get; set; }
        public Proveedor proveedor { get; set; }
        public Laboratorio laboratorio { get; set; }
        
    }
}