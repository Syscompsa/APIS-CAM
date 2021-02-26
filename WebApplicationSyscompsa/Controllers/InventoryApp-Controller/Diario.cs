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

namespace WebApplicationSyscompsa.Controllers.InventoryApp_Controller
{
    [Route("api/Diario")]
    [ApiController]
    public class Diario : ControllerBase
    {
        private readonly AppDbContext _context;
        public Diario(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("GetReporteUser/{User}")]
        public ActionResult<DataTable> SelectAnexos([FromRoute] string user)
        {
            string Sentencia = " select a.NOMBRE as Nombre_f, a .BARRA as Barra_f, a.VAL_NORMAL, " +
                               " a.placa, a.nombre, a.USUCREA, a.MARCA, a.FECHAC, a.MODELO, a.DPTO, " +
                               " a.USUMODI, a.REFER, a.SERIE, a.cpadre, d.nombre as nam_dep, " +
                               " a.custodio, a.VALOR, a.VAL_REVAL, a.VAL_NORMAL, a.cpadre as c_padre_f, " +
                               " isnull(ltrim(rtrim(b.NOMBRE + ' ' + b.APELLIDO)), '--') as name_cust, c.nombre as ciudad " + 
                               " from DP12a120_F as a " +
                               " left join DP12A110 as b ON b.CODIGO = a.CUSTODIO " +
                               " left join ALPTABLA as c ON c.master = '007' and c.codigo = a.CIUDAD " +
                               " left join ALPTABLA as d ON d.master = '008' and d.codigo = a.DPTO " +
                               " where a.USUCREA = @User ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@User", user));
                adapter.Fill(dt);
            }

            if (dt == null)
            {
                return NotFound("");
            }

            return Ok(dt);

        }

        [HttpGet]
        [Route("GetReporteCustodio/{User}")]
        public ActionResult<DataTable> GetReporteCustodio([FromRoute] string user)
        {
            string Sentencia = " select a.DPTO as nam_dep, a.NOMBRE, a.REFER, a.SERIE, a.FECHAC, a.CUSTODIO from dp12a120_f  as a " +
                               " left join ALPTABLA as d ON d.master = '008' and d.codigo = a.DPTO where a.CUSTODIO = @User ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@User", user));
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
