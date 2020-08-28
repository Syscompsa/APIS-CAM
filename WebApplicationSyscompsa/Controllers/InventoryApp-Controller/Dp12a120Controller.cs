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
        public ActionResult<DataTable> getQR([FromRoute] int Id)
        {
            string Sentencia = "select * from DP12A120 where Id = @Id" ;

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", Id));
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
        [Route("getQRGen")]
        public ActionResult<DataTable> getQRGen([FromRoute] int Id)
        {
            string Sentencia = "select * from DP12A120";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
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

        [HttpPost]
        [Route("ProductoSave")]
        public async Task<IActionResult> CanvaSave([FromBody] Dp12a120 model)
        {

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
        public ActionResult<DataTable> getPlacaProduct([FromRoute] string placa)
        {
            string Sentencia = "select * from DP12A120 where PLACA = @PLACA";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@PLACA", placa));
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
        [Route("getPlaca/{placa}")]
        public ActionResult<DataTable> getPlaca([FromRoute] string placa)
        {
            string Sentencia = "INSERT INTO Placa_Post_Url (Placa_Post, Date_Placa) values (@placa, getDate())";
      
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@PLACA", placa));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)            
            {
                return NotFound("");
            }
            return Redirect("https://inventory-bb9fa.web.app");
            //return Ok(placa);

        }

        [HttpGet]
        [Route("GetProduct")]
        public ActionResult<DataTable> GetProducts()
        {
            string Sentencia = "SELECT * FROM Placa_Post_Url";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@PLACA", placa));
                    adapter.Fill(dt);
                }
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