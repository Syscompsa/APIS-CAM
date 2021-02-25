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
using WebApplicationSyscompsa.Models.InventoryApp;

namespace WebApplicationSyscompsa.Controllers.InventoryApp_Controller
{
    [Route("api/Custodios")]
    [ApiController]
    public class Dp12a110Controller : ControllerBase
    {
        private readonly AppDbContext _context;

        public Dp12a110Controller(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("GetCustodiosGen")]
        public ActionResult<DataTable> getReporteByParam()
        {
            string Sentencia = "select * from dp12a110";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    // adapter.SelectCommand.Parameters.Add(new SqlParameter("@para", "%" + param + "%"));
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
        [Route("CustodioUpdate/{Id}")]
        //tctv //
        public async Task<IActionResult> CustodioUpdate([FromRoute] string Id, [FromBody] DP12A110 model)
        {
            //negfar //
            //public async Task<IActionResult> ProductUpdate([FromRoute] string Id, [FromBody] Dp12a120 model) {
            // string imagen = model.IMAGENBIT;
            if (Id != model.CODIGO)
            {
                return BadRequest("El CODIGO del producto no es compatible, o no existe");
            }

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(model);

        }

        [HttpPost]
        [Route("CustoSave")]
        public async Task<IActionResult> CustoSave([FromBody] DP12A110 model)
        {

            if (ModelState.IsValid)
            {
                _context.DP12A110.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                {

                    //if (model.TIPO == "true")
                    //{
                    //    model.TIPO = "E";
                    //}
                    //else
                    //{
                    //    model.TIPO = "P";
                    //}

                    //if( model.ESTADO == "true" )
                    //{
                    //    model.ESTADO = "A";
                    //}
                    //else
                    //{
                    //    model.ESTADO = "I";
                    //}

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
        [Route("DelCustodios/{id}")]
        public ActionResult<DataTable> DelCustodios([FromRoute] string param)
        {
            string Sentencia = "delete  from dp12a110";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    // adapter.SelectCommand.Parameters.Add(new SqlParameter("@para", "%" + param + "%"));
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
