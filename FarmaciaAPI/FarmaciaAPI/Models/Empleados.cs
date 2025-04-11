using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmaciaAPI.Models
{
	public class Empleados: Persona
	{
        public int id { get; set; }
        public int idEmpleado {  get; set; }
	}
}