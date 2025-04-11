using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaDevExtreme.Models
{
	public class Factura
	{
        public int id { get; set; }
        public DateTime fechaFactura { get; set; }
        public Cliente cliente { get; set; }
        public Empleados empleados { get; set; }
    }
}