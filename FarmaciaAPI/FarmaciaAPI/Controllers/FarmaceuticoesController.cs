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
    public class FarmaceuticoesController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Farmaceuticoes
        public IQueryable<Farmaceutico> GetPersona()
        {
            return (IQueryable<Farmaceutico>)db.Persona;
        }

        // GET: api/Farmaceuticoes/5
        [ResponseType(typeof(Farmaceutico))]
        public IHttpActionResult GetFarmaceutico(int id)
        {
            Farmaceutico farmaceutico = (Farmaceutico)db.Persona.Find(id);
            if (farmaceutico == null)
            {
                return NotFound();
            }

            return Ok(farmaceutico);
        }

        // PUT: api/Farmaceuticoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFarmaceutico(int id, Farmaceutico farmaceutico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != farmaceutico.id)
            {
                return BadRequest();
            }

            db.Entry(farmaceutico).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmaceuticoExists(id))
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

        // POST: api/Farmaceuticoes
        [ResponseType(typeof(Farmaceutico))]
        public IHttpActionResult PostFarmaceutico(Farmaceutico farmaceutico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persona.Add(farmaceutico);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = farmaceutico.id }, farmaceutico);
        }

        // DELETE: api/Farmaceuticoes/5
        [ResponseType(typeof(Farmaceutico))]
        public IHttpActionResult DeleteFarmaceutico(int id)
        {
            Farmaceutico farmaceutico = (Farmaceutico)db.Persona.Find(id);
            if (farmaceutico == null)
            {
                return NotFound();
            }

            db.Persona.Remove(farmaceutico);
            db.SaveChanges();

            return Ok(farmaceutico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FarmaceuticoExists(int id)
        {
            return db.Persona.Count(e => e.id == id) > 0;
        }
    }
}