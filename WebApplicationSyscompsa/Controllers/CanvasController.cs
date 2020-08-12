using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSyscompsa.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;


namespace WebApplicationSyscompsa.Controllers
{
    [Route("api/AR_2-Canvas")]
    [ApiController]
    public class CanvasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CanvasController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("CanvaSave")]
        public async Task<IActionResult> CanvaSave([FromBody] Web_Paleta model)
        {       

            if (ModelState.IsValid)
            {
                _context.Web_Paleta.Add(model);
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
        [Route("GetCanvas")]

        public ActionResult<DataTable> GetCanvas()
        {
            string Sentencia = "select * from Web_Paleta";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
                    adapter.Fill(dt);
                }
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpGet]
        [Route("GetCanvasID/{Id}")]

        public ActionResult<DataTable> GetCanvasID([FromRoute] int Id)
        {
            string Sentencia = "select * from Web_Paleta where Id = @Id";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", Id));
                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
                    adapter.Fill(dt);
                }
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpDelete]
        [Route("DelCanvas/{Id}")]

        public ActionResult<DataTable> DelCanvas([FromRoute] int Id)
        {
            string Sentencia = "delete from Web_Paleta where Id = @Id";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", Id));
                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
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

//var result = await _context.Web_Paleta.FirstOrDefaultAsync(x =>                
//    x.Color_A == model.Color_A 
//    && x.Color_B == model.Color_B
//    && x.Color_C == model.Color_C 
//    && x.Color_D == model.Color_D
//    && x.Color_Tabla == model.Color_Tabla
//    && x.Nombre == model.Nombre
//);
