using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebApplicationSyscompsa.Models;
using WebApplicationSyscompsa.Models.InventoryApp;

namespace WebApplicationSyscompsa.Controllers.InventoryApp_Controller
{
    [Route("api/AR_INV-QRcodProdGet")]
    [ApiController]
    public class Dp12a120Controller : ControllerBase
    {
        private readonly AppDbContext _context;

        public Dp12a120Controller(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        [Route("getQR/{Id}")]
        public ActionResult<DataTable> GetQR([FromRoute] int Id)
        {
            string Sentencia = "select * from DP12A120 where Id = @Id";

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
        [Route("getDataReportIng/{param}")]
        public ActionResult<DataTable> getDataReportIng([FromRoute] int param )
        {
            string Sentencia = " declare @par int = @param " +
                                " select id, a.custodio, a.placa, a.nombre, " +
                                " a.dpto, a.ciudad, a.FECCREA, b.APELLIDO, " +
                                " b.nombre nomcust, d.nombre nomciudad from dp12a120 a " +
                                " left join DP12A110 b on b.CODIGO = a.CUSTODIO " +
                                " left join alptabla d on master = '007' and a.CIUDAD = d.codigo " +
                                " order by (case @par when 1 then id else 0 end) desc, " +
                                " 		   (case @par when 2 then id else 0 end) asc   ";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@param", param));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpGet]
        [Route("getDataImg/{placa}")]
        public ActionResult<DataTable> getDataImg([FromRoute] string placa)
        {
            string Sentencia = " select IMAGENBIT, len(ltrim(rtrim(coalesce(IMAGENBIT, '')))) as Peso from dp12a120 where placa = @placa ";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {                
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@placa", placa));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("NO SE ENCONTRO DATA, PUEDE QUE TENGAS CONEXIÓN A INTERNET O ESTES ENVIANDO MAL LA VARIABLE");
            }
            return Ok(dt);
        }


        [HttpGet]
        [Route("getQRGen")]
        public ActionResult<DataTable> GetQRGen()
        {
            string Sentencia = "select * from DP12A120";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                //adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", Id));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpGet]
        [Route("DeletProduct/{placa}")]
        public ActionResult<DataTable> DeletProduct([FromRoute] string placa)
        {
            string Sentencia = "DELETE FROM DP12A120 WHERE PLACA = @plac;";
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

        [HttpPost]
        [Route("ProductoSave")]
        public async Task<IActionResult> CanvaSave([FromBody] Dp12a120 model)
        {
            string img = model.IMAGENBIT;

            if (ModelState.IsValid)
            {
                _context.DP12A120.Add(model);
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

        [HttpPut]
        [Route("productUpdate/{Id}")]
        public async Task<IActionResult> ProductUpdate([FromRoute] int Id,
                                                       [FromBody] Dp12a120 model)
        {
            // string imagen = model.IMAGENBIT;

            if (Id != model.Id)
            {
                return BadRequest();
            }
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPost]
        [Route("InvSave")]
        public async Task<IActionResult> InvSave([FromBody] Demo model)
        {

            if (ModelState.IsValid)
            {
                _context.Demo.Add(model);
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
        [Route("getPlacaProduct/{placa}")]
        public ActionResult<DataTable> GetPlacaProduct([FromRoute] string placa)
        {
            string Sentencia = "select * from DP12A120 where PLACA = @PLACA";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@PLACA", placa));
                adapter.Fill(dt);
            }
            if (dt == null)
            {

                return NotFound("");

            }
            return Ok(dt);
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Users");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue
                        .Parse(file.ContentDisposition)
                        .FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else

                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("getPlaca/{placa}")]
        public ActionResult<DataTable> GetPlaca([FromRoute] string placa)
        {
            string Sentencia = "INSERT INTO Placa_Post_Url (Placa_Post, Date_Placa) values (@placa, getDate())";
      
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@PLACA", placa));

                adapter.Fill(dt);
            }

            if (dt == null)            
            {
                return NotFound("");
            }
            return Redirect("https://inventory-bb9fa.web.app/");
            //return Ok(placa);

        }

        [HttpGet]
        [Route("GetProduct")]
        public ActionResult<DataTable> GetProducts()
        {
            string Sentencia = "select top(1)  * from Placa_Post_Url order by Id desc ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                //adapter.SelectCommand.Parameters.Add(new SqlParameter("@PLACA", placa));
                adapter.Fill(dt);
            }

            if (dt == null)
            {
                return NotFound("");
            }

            // return Redirect("https://inventory-bb9fa.web.app");
            return Ok(dt);

        }

        //[HttpPost]
        //[Route("ProductValidate")]
        //public async Task<IActionResult> ProductValidate([FromBody] Dp12a120 ProductInfo)
        //{
        //    var result = await _context.DP12A120.FirstOrDefaultAsync(x =>
        //        x.PLACA == ProductInfo.PLACA
        //    );

        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        //ModelState.AddModelError(string.Empty, "Usuario o contraseña invalido");
        //        return BadRequest("Producto no encontrado");
        //    }
        //}
    }
}