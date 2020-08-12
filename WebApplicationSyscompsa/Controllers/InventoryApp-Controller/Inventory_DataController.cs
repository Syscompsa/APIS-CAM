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
    [Route("api/AR_INV-Data")]
    [ApiController]
    public class Inventory_DataController : ControllerBase
    {
        private readonly AppDbContext _context;
        public Inventory_DataController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        [Route("getInvData/{Id}")]
        public ActionResult<DataTable> getInvData([FromRoute] int Id)
        {
            string Sentencia = "select * from inventory_data where Id = @Id";

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

        [HttpPost]
        [Route("invSave")]
        public async Task<IActionResult> invSave([FromBody] Inventory_Data model)
        {

            if (ModelState.IsValid)
            {
                _context.Inventory_Data.Add(model);
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
    }
}