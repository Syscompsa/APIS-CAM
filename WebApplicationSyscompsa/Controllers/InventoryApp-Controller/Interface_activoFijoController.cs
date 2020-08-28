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
    [Route("api/AR_2-Interface")]
    [ApiController]
    public class Interface_activoFijoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Interface_activoFijoController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        [Route("GetInterfaceConfig")]
        public ActionResult<DataTable> GetInterfaceConfig()
        {
            string Sentencia = "select * from Interface_activoFijo";

            DataTable dt = new DataTable();
            using (SqlConnection connection =
                new SqlConnection(                    
                    _context.Database.GetDbConnection().ConnectionString)
                )
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", Id));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);

        }
        [HttpPut]
        [Route("UpdateInterfaceConfig/{Id}")]
        public async Task<IActionResult> UpdateInterfaceConfig
                                         ([FromRoute] int Id,
                                          [FromBody] Interface_activoFijo model)
        {

         if(Id != model.Id) {
           return BadRequest();
         }

         _context.Entry(model).State = EntityState.Modified;
         await _context.SaveChangesAsync();

         return NoContent();

        }
    }
}