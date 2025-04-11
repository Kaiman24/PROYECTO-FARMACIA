using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaDevExtreme.Models
{
	public class TarjetaCredito
	{
        public int id { get; set; }
        public int noTarjeta {  get; set; }
        public DateTime fechaCaducidad {  get; set; }
    }
}