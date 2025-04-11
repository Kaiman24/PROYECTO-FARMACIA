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
    public class TarjetaCreditoesController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/TarjetaCreditoes
        public IQueryable<TarjetaCredito> GetTarjetaCredito()
        {
            return db.TarjetaCredito;
        }

        // GET: api/TarjetaCreditoes/5
        [ResponseType(typeof(TarjetaCredito))]
        public IHttpActionResult GetTarjetaCredito(int id)
        {
            TarjetaCredito tarjetaCredito = db.TarjetaCredito.Find(id);
            if (tarjetaCredito == null)
            {
                return NotFound();
            }

            return Ok(tarjetaCredito);
        }

        // PUT: api/TarjetaCreditoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTarjetaCredito(int id, TarjetaCredito tarjetaCredito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tarjetaCredito.id)
            {
                return BadRequest();
            }

            db.Entry(tarjetaCredito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarjetaCreditoExists(id))
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

        // POST: api/TarjetaCreditoes
        [ResponseType(typeof(TarjetaCredito))]
        public IHttpActionResult PostTarjetaCredito(TarjetaCredito tarjetaCredito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TarjetaCredito.Add(tarjetaCredito);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tarjetaCredito.id }, tarjetaCredito);
        }

        // DELETE: api/TarjetaCreditoes/5
        [ResponseType(typeof(TarjetaCredito))]
        public IHttpActionResult DeleteTarjetaCredito(int id)
        {
            TarjetaCredito tarjetaCredito = db.TarjetaCredito.Find(id);
            if (tarjetaCredito == null)
            {
                return NotFound();
            }

            db.TarjetaCredito.Remove(tarjetaCredito);
            db.SaveChanges();

            return Ok(tarjetaCredito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TarjetaCreditoExists(int id)
        {
            return db.TarjetaCredito.Count(e => e.id == id) > 0;
        }
    }
}