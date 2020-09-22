using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationSyscompsa.Models;
using WebApplicationSyscompsa.Models.InventoryApp;

namespace WebApplicationSyscompsa.Controllers.InventoryApp_Controller
{
    [Route("api/Reporteria")]
    [ApiController]
    public class reporteInvController : ControllerBase
    {
        private readonly AppDbContext _context;

        public reporteInvController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        [Route("getReporte")]
        public ActionResult<DataTable> getReporte()
        {
            string Sentencia = "select * from reporteInv";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    // adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", Id));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpPost]
        [Route("reportSave")]
        public async Task<IActionResult> reportSave([FromBody] reporteInv model)
        {

            if (ModelState.IsValid)
            {
                _context.reporteInv.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(model);
                }
                else
                { return BadRequest("Datos incorrectos"); }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("DeleteReporte/{Id}")]
        public ActionResult<DataTable> DeleteReporte([FromRoute] int Id)
        {
            string Sentencia = "DELETE FROM reporteInv where Id = @Id";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", Id));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpGet]
        [Route("GetDptoReporte/{master}")]
        public ActionResult<DataTable> GetDptoReporte([FromRoute] string master)
        {

            string Sentencia = " declare @Departamento nvarchar(20) = @m " +
                               " select a.dpto, b.nombre nomDpto, a.CIUDAD, c.nombre nomCiudad, " +
                               " a.MARCA, d.nombre nomMarca, a.CUSTODIO, RTRIM(e.NOMBRE) + ' ' + " +
                               " RTRIM(e.APELLIDO) nombreCustodio ,  a.* " +
                               " from DP12A120 a " +
                               " left join alptabla b on b.master = '008' and b.codigo = a.dpto " +
                               " left join alptabla c on c.master = '007' and c.codigo = a.CIUDAD " +
                               " left join ALPTABLA d on d.master = 'IA1' and d.codigo = a.MARCA " +
                               " left join DP12A110 e on e.codigo = a.CUSTODIO " +
                               " where(len(@Departamento) = 0 or a.dpto like @Departamento or b.nombre like @Departamento)  " ;

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@m", "%" + master + "%"));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpGet]
        [Route("GetMarcaReporte/{master}")]
        public ActionResult<DataTable> GetMarcaReporte([FromRoute] string master)
        {

            string Sentencia = " declare @Marca nvarchar(20) = @m " +
                               " select a.dpto, b.nombre nomDpto, a.CIUDAD, c.nombre nomCiudad, " +
                               " a.MARCA, d.nombre nomMarca, a.CUSTODIO, RTRIM(e.NOMBRE) + ' ' + " +
                               " RTRIM(e.APELLIDO) nombreCustodio ,  a.* " +
                               " from DP12A120 a " +
                               " left join alptabla b on b.master = '008' and b.codigo = a.dpto " +
                               " left join alptabla c on c.master = '007' and c.codigo = a.CIUDAD " +
                               " left join ALPTABLA d on d.master = 'IA1' and d.codigo = a.MARCA " +
                               " left join DP12A110 e on e.codigo = a.CUSTODIO " +
                               " where (len(@Marca)=0 or d.NOMBRE like @Marca) ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@m", "%" + master + "%"));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpGet]
        [Route("GetCustodioReporte/{master}")]
        public ActionResult<DataTable> GetCustodioReporte([FromRoute] string master)
        {

            string Sentencia = " declare @NomCust nvarchar(20) = @m " +
                               " select a.dpto, b.nombre nomDpto, a.CIUDAD, c.nombre nomCiudad, " +
                               " a.MARCA, d.nombre nomMarca, a.CUSTODIO, RTRIM(e.NOMBRE) + ' ' + " +
                               " RTRIM(e.APELLIDO) nombreCustodio ,  a.* " +
                               " from DP12A120 a " +
                               " left join alptabla b on b.master = '008' and b.codigo = a.dpto " +
                               " left join alptabla c on c.master = '007' and c.codigo = a.CIUDAD " +
                               " left join ALPTABLA d on d.master = 'IA1' and d.codigo = a.MARCA " +
                               " left join DP12A110 e on e.codigo = a.CUSTODIO " +
                               " where (len(@NomCust)=0 or e.APELLIDO like @NomCust or e.NOMBRE like @NomCust) ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@m", "%" + master + "%"));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

    }
}