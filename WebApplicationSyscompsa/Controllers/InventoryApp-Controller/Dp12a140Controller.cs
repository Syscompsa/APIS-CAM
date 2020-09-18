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

namespace WebApplicationSyscompsa.Controllers.InventoryApp_Controller
{
    [Route("api/ClaseDp12a140")]
    [ApiController]
    public class Dp12a140Controller : ControllerBase
    {
        private readonly AppDbContext _context;

        public Dp12a140Controller(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        [Route("clase/{codigo}")]
        public ActionResult<DataTable> GetInterfaceConfig([FromRoute] string codigo)
        {
            string Sentencia = "declare @cod nvarchar(15) = @codigo" +
                               " select CODIGO, NOMBRE, DETALLE, CUPO from dp12a140" +
                               " where CODIGO like @cod or NOMBRE like @cod";

            DataTable dt = new DataTable();
            using (SqlConnection connection =
                new SqlConnection(
                    _context.Database
                    .GetDbConnection()
                    .ConnectionString)
                )
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@Codigo", "%" + codigo + "%"));
                    
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);

        }

    }
}