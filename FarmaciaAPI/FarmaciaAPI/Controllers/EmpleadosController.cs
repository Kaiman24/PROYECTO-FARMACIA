using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FarmaciaAPI.Models;

namespace FarmaciaAPI.Controllers
{
    public class EmpleadosController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Empleados
        public IQueryable<Empleados> GetPersona()
        {
            return (IQueryable<Empleados>)db.Persona;
        }

        // GET: api/Empleados/5
        [ResponseType(typeof(Empleados))]
        public IHttpActionResult GetEmpleados(int id)
        {
            Empleados empleados = (Empleados)db.Persona.Find(id);
            if (empleados == null)
            {
                return NotFound();
            }

            return Ok(empleados);
        }

        // PUT: api/Empleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleados(int id, Empleados empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleados.id)
            {
                return BadRequest();
            }

            db.Entry(empleados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empleados
        [ResponseType(typeof(Empleados))]
        public IHttpActionResult PostEmpleados(Empleados empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persona.Add(empleados);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleados.id }, empleados);
        }

        // DELETE: api/Empleados/5
        [ResponseType(typeof(Empleados))]
        public IHttpActionResult DeleteEmpleados(int id)
        {
            Empleados empleados = (Empleados)db.Persona.Find(id);
            if (empleados == null)
            {
                return NotFound();
            }

            db.Persona.Remove(empleados);
            db.SaveChanges();

            return Ok(empleados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadosExists(int id)
        {
            return db.Persona.Count(e => e.id == id) > 0;
        }
    }
}