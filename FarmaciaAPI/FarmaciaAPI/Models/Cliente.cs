using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaAPI.Models
{
	public class Cliente: Persona
	{
        public int id { get; set; }
        public int idCliente;
        public TarjetaCredito tarjetaCredito;
    }
}