using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaAPI.Models
{
	public class RecursosHumanos: Empleados
	{
        public int id { get; set; }
        public int idRRHH { get; set; }
	}
}