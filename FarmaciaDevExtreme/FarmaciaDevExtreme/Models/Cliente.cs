using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaDevExtreme.Models
{
	public class Cliente: Persona
	{
        public int id { get; set; }
        public int idCliente { get; set; }
        public TarjetaCredito tarjetaCredito { get; set; }
    }
}