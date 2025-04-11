using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FarmaciaAPI.Models
{
    public class DBContextProject : DbContext
    {
        public DBContextProject() : base("MyDbConnectionString")
        {
        }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Farmaceutico> Farmaceutico { get; set; }        
        public DbSet<Laboratorio> Laboratorio { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<RecursosHumanos> RecursosHumanos { get; set; }
        public DbSet<TarjetaCredito> TarjetaCredito { get; set; }

        public DbSet<DetalleFactura> DetalleFactura { get; set; }
        public DbSet<Administrativo> Administrativo { get; set; }
    }
}