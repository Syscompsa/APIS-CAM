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
            return Ok("Producto eliminado con éxito");
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

        //[HttpGet]
        //[Route("UpadteProdPlaca/{placa}/{clase}/{nombre}/{custodio}/{dpto}/{ciudad}/{serie}/" +
        //    "{valor}/{activo}/{refer}/{fecrea}/{usucrea}/{fecmodi}/{usumodi}/{fecfin}/{horafin}/" +
        //    "{userfin}/{barra}/{grupo}/{marca}/{color}/{fechac}/{proveedor}/{vidautil}/{valres}/{valor2}/" +
        //    "{fechaa}/{fcustodio}/{cgasto}/{cdan}/{cdar}/{val_normal}/{val_reval}/{imagen}/{valor_resi}/" +
        //    "{valor_res2}/{xxx}/{placa_aux}/{imagenbit}")]
        //public ActionResult<DataTable> UpadteProdPlaca(
        //    [FromRoute] string placa,
        //    [FromRoute] string clase        ,
        //    [FromRoute] string nombre       ,
        //    [FromRoute] string custodio     ,
        //    [FromRoute] string dpto         ,
        //    [FromRoute] string ciudad       ,
        //    [FromRoute] string serie        ,
        //    [FromRoute] decimal valor        ,
        //    [FromRoute] string activo       ,
        //    [FromRoute] string refer        ,
        //    [FromRoute] DateTime? fecrea       ,
        //    [FromRoute] string usucrea      ,
        //    [FromRoute] DateTime? fecmodi      ,
        //    [FromRoute] string usumodi      ,
        //    [FromRoute] DateTime? fecfin       ,
        //    [FromRoute] DateTime? horafin      ,
        //    [FromRoute] string userfin      ,
        //    [FromRoute] string barra        ,
        //    [FromRoute] string grupo        ,
        //    [FromRoute] string marca        ,
        //    [FromRoute] string color        ,
        //    [FromRoute] DateTime? fechac       ,
        //    [FromRoute] string proveedor     ,
        //    [FromRoute] decimal vidautil     ,
        //    [FromRoute] decimal valres       ,
        //    [FromRoute] decimal valor2       ,
        //    [FromRoute] DateTime? fechaa     ,
        //    [FromRoute] DateTime? fcustodio ,
        //    [FromRoute] string cgasto       ,
        //    [FromRoute] string cdan         ,
        //    [FromRoute] string cdar         ,
        //    [FromRoute] decimal val_normal     ,
        //    [FromRoute] decimal val_reval     ,
        //    [FromRoute] string imagen       ,
        //    [FromRoute] decimal valor_resi,
        //    [FromRoute] decimal valor_res2     ,
        //    [FromRoute] decimal xxx          ,
        //    [FromRoute] string placa_aux     ,
        //    [FromRoute] string imagenbit     

        //    )
        //{
        //    string Sentencia = "UPDATE [dbo].[DP12A120]"+
        //                        "SET PLACA = @placa"+
        //                        ", CLASE = @clase"+
        //                        ",[NOMBRE] = @nombre"+
        //                        ",[CUSTODIO] = @custodio"+
        //                        ",[DPTO] = @dpto     "+
        //                        ",[CIUDAD] = @ciudad   "+
        //                        ",[SERIE] = @serie    "+
        //                        ",[VALOR] = @valor     "+
        //                        ",[ACTIVO] = @activo   "+
        //                        ",[REFER] = @refer    "+
        //                        ",[FECCREA] = @fecrea  "+
        //                        ",[USUCREA] = @usucrea  "+
        //                        ",[FECMODI] = @fecmodi  "+
        //                        ",[USUMODI] = @usumodi  "+
        //                        ",[FECFIN] = @fecfin   "+
        //                        ",[HORAFIN] = @horafin"+
        //                        ",[USERFIN] = @userfin  "+
        //                        ",[BARRA] = @barra    "+
        //                        ",[GRUPO] = @grupo    "+
        //                        ",[MARCA] = @marca    "+
        //                        ",[COLOR] = @color    "+
        //                        ",[FECHAC] = @fechac   "+
        //                        ",[PROVEEDOR] = @proveedor "+
        //                        ",[MODELO] = @modelo   "+
        //                        ",[VIDAUTIL] = @vidautil  "+
        //                        ",[VALRES] = @valres    "+
        //                        ",[VALOR2] = @valor2    "+
        //                        ",[FECHAA] = @fechaa    "+
        //                        ",[FCUSTODIO] = @fcustodio "+
        //                        ",[CGASTO] = @cgasto   "+
        //                        ",[CDAN] = @cdan     "+
        //                        ",[CDAR] = @cdar     "+
        //                        ",[VAL_NORMAL] = @val_normal "+
        //                        ",[VAL_REVAL] = @val_reval "+
        //                        ",[IMAGEN] = @imagen"+
        //                        ",[VALOR_RESI] = @valor_resi"+
        //                        ",[VALOR_RES2] = @valor_res2"+
        //                        ",[xxx] = @xxx"+
        //                        ",[placa_aux] = @placa_aux"+
        //                        ",[IMAGENBIT] = @imagenbit"+
        //                        "WHERE[PLACA] = @placa";

        //    DataTable dt = new DataTable();
        //    using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
        //    {
        //        using SqlCommand cmd = new SqlCommand(Sentencia, connection);
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.SelectCommand.CommandType = CommandType.Text;
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@placa",         placa       ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@clase",         clase       ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@nombre",        nombre      ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@custodio",      custodio    ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@dpto",          dpto        ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@ciudad",        ciudad      ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@serie",         serie       ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@valor",         valor       ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@activo",        activo      ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@refer",         refer       ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@fecrea",        fecrea      ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@usucrea",       usucrea     ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@fecmodi",       fecmodi     ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@usumodi",       usumodi     ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@fecfin",        fecfin      ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@horafin",       horafin     ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@userfin" ,      userfin     ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@barra"   ,      barra       ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@grupo"   ,      grupo       ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@marca"   ,      marca       ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@color"   ,      color       ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@fechac"  ,      fechac      ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@proveedor",     proveedor   ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@vidautil" ,     vidautil    ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@valres"   ,     valres      ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@valor2"   ,     valor2      ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@fechaa"   ,     fechaa      ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@fcustodio",     fcustodio   ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@cgasto"   ,     cgasto      ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@cdan"     ,     cdan        ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@cdar"     ,     cdar        ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@val_normal",    val_normal  ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@val_reval" ,    val_reval   ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@imagen"    ,    imagen      ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@valor_resi",    valor_resi  ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@valor_res2",    valor_res2  ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@xxx"       ,    xxx         ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@placa_aux" ,    placa_aux   ));
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@imagenbit" ,    imagenbit   ));
        //        adapter.Fill(dt);
        //    }
        //    if (dt == null)
        //    {

        //        return NotFound("");

        //    }



        //    return Ok(dt);

        //}

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
            string Sentencia = "select * from Placa_Post_Url order by Id desc";

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