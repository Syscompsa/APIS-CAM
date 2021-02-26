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
    [Route("api/anexos")]
    [ApiController]
    public class ANEXO_DP12A120_FController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ANEXO_DP12A120_FController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("PostAnexo")]
        public async Task<IActionResult> PostAnexo([FromBody] ANEXO_DP12A120_F model)
        {
            if (ModelState.IsValid)
            {

                _context.ANEXO_DP12A120_F.Add(model);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(model);
                }

                else
                {

                    return BadRequest("Datos incorrectos");

                }
            }

            else
            {

                return BadRequest(ModelState);

            }
        }

        [HttpPut]
        [Route("PutAnexo/{Id}")]
        public async Task<IActionResult> ProductUpdate([FromRoute] int Id, [FromBody] ANEXO_DP12A120_F model)
        {
            
            if (Id != model.Id)
            {
                return BadRequest("El ID del producto no es compatible, o no existe");
            }

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(model);

        }


        [HttpGet]
        [Route("DeletAnexo/{Id}")]
        public ActionResult<DataTable> DeletAnexo([FromRoute] int Id) {
            string Sentencia = "DELETE FROM ANEXO_DP12A120_F WHERE Id = @Id;";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString)) {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", Id));
                adapter.Fill(dt);
            }

            if (dt == null) {
                return NotFound("");
            }

            return Ok(dt);
        
        }

        [HttpGet]
        [Route("SelectAnexoGen")]
        public ActionResult<DataTable> SelectAnexoGen([FromRoute] int Id)
        {
            string Sentencia = " select * from ANEXO_DP12A120_F";
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
        [Route("SelectAnexos/{placa}")]
        public ActionResult<DataTable> SelectAnexos([FromRoute] string placa) {
            string Sentencia = " declare @placa nvarchar(50) = @plac " +
                               " select a.placa, a.codBarra, a.avcomer, a.vidutil," +
                               " a.metodtec, a.observaciones from ANEXO_DP12A120_F as a " +
                               " left join DP12a120_F as b ON b.placa = a.placa " +
                               " where b.placa = @placa ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString)) {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@plac", placa));
                adapter.Fill(dt);
            }

            if (dt == null) {
                return NotFound("");
            }

            return Ok(dt);

        }


        [HttpGet]
        [Route("SelectAnexo/{placa}")]
        public ActionResult<DataTable> SelectAnexo([FromRoute] string placa)
        {
            string Sentencia = "select * FROM ANEXO_DP12A120_F WHERE placa = @plac;";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@plac", placa));
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