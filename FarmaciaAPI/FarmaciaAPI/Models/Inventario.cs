using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaAPI.Models
{
	public class Inventario
	{
        public int id {  get; set; }
        public int cantidadStock { get; set; }
        public double precio { get; set; }
    }
}