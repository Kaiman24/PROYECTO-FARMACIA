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
    public class RecursosHumanosController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/RecursosHumanos
        public IQueryable<RecursosHumanos> GetPersona()
        {
            return (IQueryable<RecursosHumanos>)db.Persona;
        }

        // GET: api/RecursosHumanos/5
        [ResponseType(typeof(RecursosHumanos))]
        public IHttpActionResult GetRecursosHumanos(int id)
        {
            RecursosHumanos recursosHumanos = (RecursosHumanos)db.Persona.Find(id);
            if (recursosHumanos == null)
            {
                return NotFound();
            }

            return Ok(recursosHumanos);
        }

        // PUT: api/RecursosHumanos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecursosHumanos(int id, RecursosHumanos recursosHumanos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recursosHumanos.id)
            {
                return BadRequest();
            }

            db.Entry(recursosHumanos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursosHumanosExists(id))
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

        // POST: api/RecursosHumanos
        [ResponseType(typeof(RecursosHumanos))]
        public IHttpActionResult PostRecursosHumanos(RecursosHumanos recursosHumanos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persona.Add(recursosHumanos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recursosHumanos.id }, recursosHumanos);
        }

        // DELETE: api/RecursosHumanos/5
        [ResponseType(typeof(RecursosHumanos))]
        public IHttpActionResult DeleteRecursosHumanos(int id)
        {
            RecursosHumanos recursosHumanos = (RecursosHumanos)db.Persona.Find(id);
            if (recursosHumanos == null)
            {
                return NotFound();
            }

            db.Persona.Remove(recursosHumanos);
            db.SaveChanges();

            return Ok(recursosHumanos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecursosHumanosExists(int id)
        {
            return db.Persona.Count(e => e.id == id) > 0;
        }
    }
}