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
using UngDung_DiChoThue.Model;

namespace UngDung_DiChoThue.Controllers
{
    public class phan_hoi_khach_hangController : ApiController
    {
        private PhanHoiEntities db = new PhanHoiEntities();

        [Route("api/phanhoi")]
        // GET: api/phan_hoi_khach_hang
        public IQueryable<phan_hoi_khach_hang> Getphan_hoi_khach_hang()
        {
            return db.phan_hoi_khach_hang;
        }

        // GET: api/phan_hoi_khach_hang/5
        [ResponseType(typeof(phan_hoi_khach_hang))]
        public IHttpActionResult Getphan_hoi_khach_hang(int id)
        {
            phan_hoi_khach_hang phan_hoi_khach_hang = db.phan_hoi_khach_hang.Find(id);
            if (phan_hoi_khach_hang == null)
            {
                return NotFound();
            }

            return Ok(phan_hoi_khach_hang);
        }

        // PUT: api/phan_hoi_khach_hang/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putphan_hoi_khach_hang(int id, phan_hoi_khach_hang phan_hoi_khach_hang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phan_hoi_khach_hang.id)
            {
                return BadRequest();
            }

            db.Entry(phan_hoi_khach_hang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!phan_hoi_khach_hangExists(id))
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

        // POST: api/phan_hoi_khach_hang
        [ResponseType(typeof(phan_hoi_khach_hang))]
        public IHttpActionResult Postphan_hoi_khach_hang(phan_hoi_khach_hang phan_hoi_khach_hang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.phan_hoi_khach_hang.Add(phan_hoi_khach_hang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = phan_hoi_khach_hang.id }, phan_hoi_khach_hang);
        }

        // DELETE: api/phan_hoi_khach_hang/5
        [ResponseType(typeof(phan_hoi_khach_hang))]
        public IHttpActionResult Deletephan_hoi_khach_hang(int id)
        {
            phan_hoi_khach_hang phan_hoi_khach_hang = db.phan_hoi_khach_hang.Find(id);
            if (phan_hoi_khach_hang == null)
            {
                return NotFound();
            }

            db.phan_hoi_khach_hang.Remove(phan_hoi_khach_hang);
            db.SaveChanges();

            return Ok(phan_hoi_khach_hang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool phan_hoi_khach_hangExists(int id)
        {
            return db.phan_hoi_khach_hang.Count(e => e.id == id) > 0;
        }
    }
}