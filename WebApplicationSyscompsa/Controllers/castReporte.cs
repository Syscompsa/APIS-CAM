using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSyscompsa.Models;

namespace WebApplicationSyscompsa.Controllers
{
    [Route("api/Diario")]
    [ApiController]
    public class castReporte : ControllerBase
    {
        private readonly AppDbContext _context;

        public castReporte(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("GetReporteUser/{INV}/{NOMBRE}")]
        public ActionResult<DataTable> GetQR([FromRoute] string INV, [FromRoute] string NOMBRE) {
            string Sentencia = " declare @Nombre nvarchar(100) " +
                               " select a.CUSTODIO, RTRIM(LTRIM(b.apellido + b.NOMBRE)) as CustName, a.DPTO, RTRIM(LTRIM(c.NOMBRE)) as DepName, " +
                               " a.CIUDAD, d.NOMBRE as CiudName, a.REFER, a.BARRA, a.USUCREA, a.FECHAC, a.SERIE, a.NOMBRE from DP12a120_F as a "  +
                               " left join DP12A110 as b ON b.CODIGO = a.CUSTODIO " +
                               " left join ALPTABLA as c ON c.master = '008' and c.codigo = a.DPTO "   +
                               " left join ALPTABLA as d ON d.master = '007' and d.codigo = a.CIUDAD " +
                               " where a.USUCREA = @INV  and b.NOMBRE+' '+b.APELLIDO like @Nombre ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@INV", INV));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Nombre", "%" +  NOMBRE + "%"));
                adapter.Fill(dt);
            }

            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpGet]
        [Route("GetReporteCustodio/{NOMBRE}")]
        public ActionResult<DataTable> GetReporteCustodio([FromRoute] string NOMBRE) {
            string Sentencia = " declare @Value nvarchar(100) = @Nam" +
                               " select a.CUSTODIO, RTRIM(LTRIM(b.apellido + ' ' + b.NOMBRE)) as CustName, a.DPTO,  RTRIM(LTRIM(c.NOMBRE)) as DepName, " +
                               " a.CIUDAD, d.NOMBRE as CiudName, a.REFER, a.BARRA, a.USUCREA, a.FECHAC, a.SERIE, a.NOMBRE from DP12a120_F as a " +
                               " left join DP12A110 as b ON b.CODIGO = a.CUSTODIO " +
                               " left join ALPTABLA as c ON c.master = '008' and c.codigo = a.DPTO " +
                               " left join ALPTABLA as d ON d.master = '007' and d.codigo = a.CIUDAD " +
                               " where b.APELLIDO + ' ' + b.NOMBRE like @Value  or c.NOMBRE like @Value "; 

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                // adapter.SelectCommand.Parameters.Add(new SqlParameter("@INV", INV));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Nam", "%" + NOMBRE + "%"));
                adapter.Fill(dt);
            }

            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }
        
        [HttpGet]
        [Route("GetDeptALP/{NOMBRE}")]
        public ActionResult<DataTable> GetDept([FromRoute] string NOMBRE) {
            string Sentencia = " select * from alptabla where master = '008' and nombre like @NOMBRE ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                // adapter.SelectCommand.Parameters.Add(new SqlParameter("@INV", INV));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@NOMBRE", "%" + NOMBRE + "%"));
                adapter.Fill(dt);
            }

            if (dt == null) {
                return NotFound("");
            }

            return Ok(dt);

        }

    }
}
