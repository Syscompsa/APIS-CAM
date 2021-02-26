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
        public ActionResult<DataTable> GetQR([FromRoute] string Id)
        {
            string Sentencia = "select * from DP12A120_F where placa = @Id";
           // string Sentencia = "select * from DP12A120 where Id = @Id";

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
        [Route("GetAnexo_DP12a120_F/{placa}")]
        public ActionResult<DataTable> GetAnexo_DP12a120_F([FromRoute] string placa)
        {
            string Sentencia = " declare @a nvarchar(50) = @placa " +
                               " select * from DP12a120_F as a " +
                               " left join ANEXO_DP12A120_F as b ON b.placa = a.placa " +
                               " where a.PLACA = @a ";

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
                return NotFound("");
            }
            return Ok(dt);
        }


        [HttpGet]
        [Route("apiGETDP12a120")]
        public ActionResult<DataTable> apiGETDP12a120()
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
        [Route("GetMasterBarra/{BARRA}")]
        public ActionResult<DataTable> GetMasterBarra([FromRoute] string BARRA)
        {
            string Sentencia = "declare @codBarra nvarchar(150) = @BARRA " +
                               " select nombre, barra from dp12a120 where barra like @codBarra; ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@BARRA", "%" + BARRA + "%"));
                adapter.Fill(dt);
            }

            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }


        [HttpGet]
        [Route("apiGETPROD12a120/{COD}")]
        public ActionResult<DataTable> apiGETPROD12a120([FromRoute] string COD)
        {
            string Sentencia = "declare @prod nvarchar(100) = @COD " +
                               " select * from dp12a120 where barra = @prod";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@COD", COD));
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
            string Sentencia =  " declare @par int = @param "                 +
                                " select id, a.custodio, a.placa, a.nombre, " +
                                " a.dpto, a.ciudad, a.FECCREA, b.APELLIDO, "  +
                                " b.nombre nomcust, d.nombre nomciudad from dp12a120 a " +
                                " left join DP12A110 b on b.CODIGO = a.CUSTODIO "        +
                                " left join alptabla d on master = '007' and a.CIUDAD = d.codigo " +
                                " order by (case @par when 1 then id else 0 end) desc, "           +
                                " 		   (case @par when 2 then id else 0 end) asc ";
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

        //declare @plac nvarchar(50) = '0101032088'
        //select placa, coalesce( imagenbit, '' ) as foto, len(ltrim(rtrim(coalesce(IMAGENBIT,''))))
        //as Peso from dp12a120 where PLACA = @plac
        [HttpGet]
        [Route("getImgByPlaca/{placa}")]
        public ActionResult<DataTable> getDataImg([FromRoute] string placa)
        {
            string Sentencia =         "declare @plac nvarchar(50) = @placa " + 
                                       " select placa, coalesce(imagenbit, '') as foto," +
                                       " len(ltrim(rtrim(coalesce(IMAGENBIT, '')))) " +
                                       " as Peso from dp12a120 where PLACA = @plac ";
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
        [Route("getDataImgFilter/{fotoCodecA}/{fotoCodecB}/{departamento}")]
        public ActionResult<DataTable> getDataImgFilter([FromRoute] string departamento, [FromRoute] string fotoCodecA, [FromRoute] string fotoCodecB)



        {
            string Sentencia =  " declare @BotonCI bit = @fotoCodecA, "           +
                                " @BotonSI bit = @fotoCodecB select placa, DPTO," +
                                " len(ltrim(rtrim(coalesce(IMAGENBIT, '')))) "    +
                                " as Peso from dp12a120 where (@BotonCI = 0 or "  +
                                " (@BotonCI = 1 and len(ltrim(rtrim(coalesce(IMAGENBIT, '')))) > 0)) " +
                                " and(@BotonSI = 0 or(@BotonSI = 1 and "          + 
                                " len(ltrim(rtrim(coalesce(IMAGENBIT, '')))) = 0)) " +
                                " and DPTO =  @departamento ";
            
            DataTable dt = new DataTable();
            
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters
                                     .Add(new SqlParameter("@departamento", departamento));
                adapter.SelectCommand.Parameters
                                     .Add(new SqlParameter("@fotoCodecA", fotoCodecA));
                adapter.SelectCommand.Parameters
                                     .Add(new SqlParameter("@fotoCodecB", fotoCodecB));
                adapter.Fill(dt);
            }

            if (dt == null)
            {
                return NotFound("NO SE ENCONTRO DATA, PUEDE QUE TENGAS CONEXIÓN A INTERNET O ESTES ENVIANDO MAL LA VARIABLE");
            }

            return Ok(dt);

        }

        //declare @BotonCI bit = 0,
        //@BotonSI bit = 1
        //select placa, DPTO, coalesce( imagenbit, '' ) as foto, len(ltrim(rtrim(coalesce(IMAGENBIT,''))))
        //as Peso
        //from dp12a120 where
        //(@BotonCI= 0 or (@BotonCI= 1 and len(ltrim(rtrim(coalesce(IMAGENBIT,''))))>0))
        //and(@BotonSI= 0 or (@BotonSI= 1 and len(ltrim(rtrim(coalesce(IMAGENBIT,''))))=0))
        //and dpto = 'nf006'

        //[HttpGet]
        //[Route("getDataImg/{placa}")]
        //public ActionResult<DataTable> getDataImg([FromRoute] string placa)
        //{
        //    string Sentencia = " select IMAGENBIT, len(ltrim(rtrim(coalesce(IMAGENBIT, '')))) as Peso from dp12a120 where placa = @placa ";
        //    DataTable dt = new DataTable();
        //    using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
        //    {                
        //        using SqlCommand cmd = new SqlCommand(Sentencia, connection);
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        adapter.SelectCommand.CommandType = CommandType.Text;
        //        adapter.SelectCommand.Parameters.Add(new SqlParameter("@placa", placa));
        //        adapter.Fill(dt);
        //    }
        //    if (dt == null)
        //    {
        //        return NotFound("NO SE ENCONTRO DATA, PUEDE QUE TENGAS CONEXIÓN A INTERNET O ESTES ENVIANDO MAL LA VARIABLE");
        //    }
        //    return Ok(dt);
        //}


        [HttpGet]
        [Route("getQRGen")]
        public ActionResult<DataTable> GetQRGen()
        {
            //TC
            string Sentencia = "select * from DP12A120_F";
            
            //NEGFAR
            //string Sentencia = "select * from DP12A120";
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
            string img = model.IMAGEN;

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
        //tc
        public async Task<IActionResult> ProductUpdate([FromRoute] string Id, [FromBody] Dp12a120_f model) {    
        
        //NEGFAR
        //public async Task<IActionResult> ProductUpdate([FromRoute] string Id, [FromBody] Dp12a120 model) {
            // string imagen = model.IMAGENBIT;
            if (Id != model.PLACA) {
                return BadRequest("El ID del producto no es compatible, o no existe");
            }

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(model);

        }

        [HttpGet]
        [Route("GetImage_a120F/{PLACA}")]
        public ActionResult<DataTable> GetDP12a120F([FromRoute] string PLACA)
        {
            string Sentencia = "select IMAGEN from dp12a120_f where PLACA = @PLACA and (IMAGEN != null or IMAGEN != '')";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@PLACA", PLACA));
                adapter.Fill(dt);
            }

            if (dt == null)
            {
                return NotFound("");
            }

            return Ok(dt);

        }

        [HttpGet]
        [Route("Get_data_120F/{inventrier}/{option}/{valueSql}")]
        public ActionResult<DataTable> Get_data_120F( [FromRoute] string inventrier, [FromRoute] string option, [FromRoute] string valueSql)
        {
            string Sentencia = " declare @UserInvetory nvarchar(50) = @inventrier " +
                               " declare @ValorSQL nvarchar(100) = @valueSql " +
                               " select a.NOMBRE as Nombre_f, a.BARRA as Barra_f, b.VAL_NORMAL, " +
                               " a.placa, a.nombre, a.USUCREA, a.MARCA, a.FECHAC, a.MODELO, a.USUMODI, a.REFER, a.SERIE, a.cpadre, " +
                               " a.custodio, b.VALOR, b.cpadre as c_padre_f, isnull(ltrim(rtrim(c.NOMBRE + ' ' + c.APELLIDO)), '--') " +
                               " as NAME_CUSTODIO , b.NOMBRE, b.BARRA from DP12a120_F as a " + 
                               " left join DP12a120 as b ON b.BARRA = a.BARRA " +
                               " left join dp12a110 as c on C.CODIGO = a.CUSTODIO " +
                               " where a.USUCREA != '' and(a.USUCREA = @UserInvetory) " +
                               " and c.NOMBRE + ' ' + c.APELLIDO like @ValorSQL or a.CUSTODIO like @ValorSQL " +
                               " order by a.custodio " + option;

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@inventrier", inventrier));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@valueSql", valueSql));
                adapter.Fill(dt);
            }

            if (dt == null)
            {
                return NotFound("");
            }

            return Ok(dt);

        }


        [HttpGet]
        [Route("Get_Inventariadores")]
        public ActionResult<DataTable> Get_Inventariadores()
        {
            string Sentencia = "select * from alptabla where master = 'ACTIV'";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(dt);
            }

            if (dt == null)
            {
                return NotFound("");
            }

            return Ok(dt);

        }

        [HttpPost]
        [Route("InvSave")]
        public async Task<IActionResult> InvSave([FromBody] Demo model)
        {
            if (ModelState.IsValid) {

                _context.Demo.Add(model);
                
                if (await _context.SaveChangesAsync() > 0) {
                    
                    return Ok(model);

                }

                else {
                    
                    return BadRequest("Datos incorrectos");
                
                }
            }

            else {

                return BadRequest(ModelState);
            
            }
        }

        [HttpGet]
        [Route("getPlacaProduct/{placa}")]
        public ActionResult<DataTable> GetPlacaProduct([FromRoute] string placa)
        {
            string Sentencia = "select * from DP12A120_F where PLACA = @PLACA";
            //string Sentencia = "select * from DP12A120 where PLACA = @PLACA";

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
            return Redirect("https://tc-inv.web.app/");
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