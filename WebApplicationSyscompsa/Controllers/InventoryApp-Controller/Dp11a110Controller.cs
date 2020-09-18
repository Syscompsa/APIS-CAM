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
    [Route("api/Grup")]
    [ApiController]
    public class Dp11a110Controller : ControllerBase
    {
        private readonly AppDbContext _context;
        public Dp11a110Controller(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("GetGrupo/{codigo}")]
        public ActionResult<DataTable> GrupoActivo([FromRoute] string codigo)
        {       
            string Sentencia = "select grupo, nombre from dp11a110 where grupo like @codigo or nombre like @codigo";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@codigo", "%" + codigo + "%"));
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