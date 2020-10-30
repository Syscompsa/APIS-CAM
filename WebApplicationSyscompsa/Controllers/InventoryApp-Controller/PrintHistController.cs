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
    [Route("api/[controller]")]
    [ApiController]
    public class PrintHistController : ControllerBase
    {

        private readonly AppDbContext _context;

        public PrintHistController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("PrintSaveHist")]
        public async Task<IActionResult> PrintSaveHist([FromBody] PrintHist model)
        {
            if (ModelState.IsValid)
            {
                _context.PrintHist.Add(model);
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
        [Route("GetHistPrint/{placa}")]
        [HttpGet]
        [Route("getReporte")]
        public ActionResult<DataTable> GetHistPrint([FromRoute] string placa)
        {
            string Sentencia = "select * from reporteInv";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", placa));
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