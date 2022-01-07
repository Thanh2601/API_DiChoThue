using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UngDung_DiChoThue.Controllers
{
    public class QuanLyTKController : ApiController
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=QL_DiChoThue;Integrated Security=True");

        [Route("api/QuanLyTaiKhoan")]
        // GET: QuanLyTK
        public HttpResponseMessage Get()
        {
            string query = @"
                        SELECT *
                        FROM TaiKhoan TK";
            return GetData(query);
        }

        [Route("api/QuanLyTaiKhoan/ChinhSua/{ID}")]
        // PUT: QuanLyTK
        public HttpResponseMessage UpdateTK(int ID, string vaitro, string trangthai)
        {
            try
            {
                string query = @"
                        UPDATE TaiKhoan TK SET 
                        TK.TrangThai=N'"+trangthai+ "', TK.VaiTro=N'" + vaitro + "'" +
                        "WHERE TK.ID = '"+ID+"'";
       
                return UpdateData(query);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // GET: QuanLyTK
        public HttpResponseMessage GetData(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // Post: QuanLyTK
        public HttpResponseMessage UpdateData(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

    }
}
