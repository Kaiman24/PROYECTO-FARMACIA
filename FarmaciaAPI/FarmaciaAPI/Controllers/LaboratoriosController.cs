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
    public class LaboratoriosController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        // GET: api/Laboratorios
        public IQueryable<Laboratorio> GetLaboratorio()
        {
            return db.Laboratorio;
        }

        // GET: api/Laboratorios/5
        [ResponseType(typeof(Laboratorio))]
        public IHttpActionResult GetLaboratorio(int id)
        {
            Laboratorio laboratorio = db.Laboratorio.Find(id);
            if (laboratorio == null)
            {
                return NotFound();
            }

            return Ok(laboratorio);
        }

        // PUT: api/Laboratorios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLaboratorio(int id, Laboratorio laboratorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laboratorio.id)
            {
                return BadRequest();
            }

            db.Entry(laboratorio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaboratorioExists(id))
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

        // POST: api/Laboratorios
        [ResponseType(typeof(Laboratorio))]
        public IHttpActionResult PostLaboratorio(Laboratorio laboratorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Laboratorio.Add(laboratorio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = laboratorio.id }, laboratorio);
        }

        // DELETE: api/Laboratorios/5
        [ResponseType(typeof(Laboratorio))]
        public IHttpActionResult DeleteLaboratorio(int id)
        {
            Laboratorio laboratorio = db.Laboratorio.Find(id);
            if (laboratorio == null)
            {
                return NotFound();
            }

            db.Laboratorio.Remove(laboratorio);
            db.SaveChanges();

            return Ok(laboratorio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LaboratorioExists(int id)
        {
            return db.Laboratorio.Count(e => e.id == id) > 0;
        }
    }
}