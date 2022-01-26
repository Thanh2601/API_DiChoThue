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
    public class SanPham_ChonController : ApiController
    {
        private SanPham_ChonEntities db = new SanPham_ChonEntities();

        // GET: api/SanPham_Chon
        public IQueryable<SanPham_Chon> GetSanPham_Chon()
        {
            return db.SanPham_Chon;
        }

        // GET: api/SanPham_Chon/5
        [ResponseType(typeof(SanPham_Chon))]
        public IHttpActionResult GetSanPham_Chon(int id)
        {
            SanPham_Chon sanPham_Chon = db.SanPham_Chon.Find(id);
            if (sanPham_Chon == null)
            {
                return NotFound();
            }

            return Ok(sanPham_Chon);
        }

        // PUT: api/SanPham_Chon/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSanPham_Chon(int id, SanPham_Chon sanPham_Chon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanPham_Chon.MaKH)
            {
                return BadRequest();
            }

            db.Entry(sanPham_Chon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPham_ChonExists(id))
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

        // POST: api/SanPham_Chon
        [ResponseType(typeof(SanPham_Chon))]
        public IHttpActionResult PostSanPham_Chon(SanPham_Chon sanPham_Chon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SanPham_Chon.Add(sanPham_Chon);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SanPham_ChonExists(sanPham_Chon.MaKH))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sanPham_Chon.MaKH }, sanPham_Chon);
        }

        // DELETE: api/SanPham_Chon/5
        [ResponseType(typeof(SanPham_Chon))]
        public IHttpActionResult DeleteSanPham_Chon(int id)
        {
            SanPham_Chon sanPham_Chon = db.SanPham_Chon.Find(id);
            if (sanPham_Chon == null)
            {
                return NotFound();
            }

            db.SanPham_Chon.Remove(sanPham_Chon);
            db.SaveChanges();

            return Ok(sanPham_Chon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SanPham_ChonExists(int id)
        {
            return db.SanPham_Chon.Count(e => e.MaKH == id) > 0;
        }
    }
}