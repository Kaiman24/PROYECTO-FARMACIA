using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaDevExtreme.Models
{
	public class DetalleFactura
	{
		public int id { get; set; }
		public Producto idProducto { get; set; }
		public int cantidadProducto { get; set; }
		public double montoTotal { get; set; }
	}
}