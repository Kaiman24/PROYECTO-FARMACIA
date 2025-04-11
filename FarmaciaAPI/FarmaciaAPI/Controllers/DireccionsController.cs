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
    public class DireccionsController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Direccions
        public IQueryable<Direccion> GetDireccion()
        {
            return db.Direccion;
        }

        // GET: api/Direccions/5
        [ResponseType(typeof(Direccion))]
        public IHttpActionResult GetDireccion(int id)
        {
            Direccion direccion = db.Direccion.Find(id);
            if (direccion == null)
            {
                return NotFound();
            }

            return Ok(direccion);
        }

        // PUT: api/Direccions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDireccion(int id, Direccion direccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != direccion.id)
            {
                return BadRequest();
            }

            db.Entry(direccion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DireccionExists(id))
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

        // POST: api/Direccions
        [ResponseType(typeof(Direccion))]
        public IHttpActionResult PostDireccion(Direccion direccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Direccion.Add(direccion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = direccion.id }, direccion);
        }

        // DELETE: api/Direccions/5
        [ResponseType(typeof(Direccion))]
        public IHttpActionResult DeleteDireccion(int id)
        {
            Direccion direccion = db.Direccion.Find(id);
            if (direccion == null)
            {
                return NotFound();
            }

            db.Direccion.Remove(direccion);
            db.SaveChanges();

            return Ok(direccion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DireccionExists(int id)
        {
            return db.Direccion.Count(e => e.id == id) > 0;
        }
    }
}