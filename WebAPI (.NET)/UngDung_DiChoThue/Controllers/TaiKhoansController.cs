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
using System.Web.Http.Cors;


namespace UngDung_DiChoThue.Controllers
{

    public class TaiKhoansController : ApiController
    {
        private TaiKhoanDBContext db = new TaiKhoanDBContext();

        [Route("api/QuanLyTaiKhoan")]
        // GET: api/TaiKhoans
        public IQueryable<TaiKhoan> GetTaiKhoans()
        {
            return db.TaiKhoans;
        }

        // GET: api/TaiKhoans/5
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult GetTaiKhoan(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return Ok(taiKhoan);
        }

        // PUT: api/TaiKhoans/5
        [EnableCors(origins: "http://localhost:3000/", headers: " x-my-custom-header", methods: "PUT")]
        [Route("api/QuanLyTaiKhoan/{id}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaiKhoan(int id, TaiKhoan taiKhoan)
        {
            try
            {
                var tk = db.TaiKhoans.FirstOrDefault(x => x.ID == taiKhoan.ID);
                if (tk == null)
                {
                    return BadRequest();
                }
                tk.Username = taiKhoan.Username;
                tk.TrangThai = taiKhoan.TrangThai;
                tk.VaiTro = taiKhoan.VaiTro;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
            return Ok();
        }

        [Route("api/QuanLyTaiKhoan")]
  
        // POST: api/TaiKhoans
        [HttpPost]
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult PostTaiKhoan(TaiKhoan taiKhoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaiKhoans.Add(taiKhoan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taiKhoan.ID }, taiKhoan);
        }

        // DELETE: api/TaiKhoans/5
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult DeleteTaiKhoan(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            db.TaiKhoans.Remove(taiKhoan);
            db.SaveChanges();

            return Ok(taiKhoan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaiKhoanExists(int id)
        {
            return db.TaiKhoans.Count(e => e.ID == id) > 0;
        }
    }
}