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

namespace WebApplicationSyscompsa.Controllers.InventoryApp_Controller
{
    [Route("api/ALPTABLA")]
    [ApiController]
    public class ALPTABLAController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ALPTABLAController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("GrupoActivo/{codigo}")]
        public ActionResult<DataTable> GrupoActivo([FromRoute] string codigo)
        {
            //actualmente solo hay un codigo asignado 001 = varios
            string Sentencia = "Select codigo,nombre from alptabla where master=" +
                               "(select codigo from alptabla where nomtag='INVGRUPO')" +
                               " and codigo=@codigo";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@codigo", codigo));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }


        [HttpGet]
        [Route("Modelo/{codigo}")]

        public ActionResult<DataTable> Modelo([FromRoute] string codigo)
        {
            //string Sentencia = "Select codigo,nombre from alptabla where master ="+
            //                   "(select codigo from alptabla where nomtag = 'IA_MODELO') and codigo= @codigo";

            string Sentencia = "declare @cc varchar(50)=@codigo Select codigo, nombre from alptabla where master = " +
                                "(select codigo from alptabla where nomtag = 'IA_MODELO')" +
                                "and(codigo like  @cc or nombre like @cc); ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@codigo", "%" + codigo + "%"));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpGet]
        [Route("Marca/{codigo}")]
        public ActionResult<DataTable> Marca([FromRoute] string codigo)
        {
            string Sentencia = "Select codigo,nombre from alptabla where master=" +
                               "(select codigo from alptabla where nomtag='IA_MARCA') and codigo=@codigo";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@codigo", codigo));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpGet]
        [Route("MasterIA1/{cod}")]
        public ActionResult<DataTable> MasterIA1([FromRoute] string cod)
        {
            string Sentencia = "declare @mod nvarchar(25) = @cod" +
                               " select master, codigo, nombre from alptabla where master = 'IA1'"
                               +" and (codigo like @mod or nombre like @mod)";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@cod", "%" + cod + "%"));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }




        [HttpGet]
        [Route("ACTCIU/{codigo}")]
        public ActionResult<DataTable> ACTCIU([FromRoute] string codigo)
        {
            //string Sentencia = "Select codigo,nombre from alptabla where master=" +
            //                   "(select codigo from alptabla where nomtag='ACTCIU') and codigo=@codigo";

            string Sentencia = "declare @cc varchar(50)=@codigo Select codigo, nombre from alptabla where master = " +
                                "(select codigo from alptabla where nomtag = 'ACTCIU')" +
                                "and(codigo like  @cc or nombre like @cc); ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@codigo", "%" + codigo + "%"));
                adapter.Fill(dt);
            }

            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpGet]
        [Route("CiudadGen")]
        public ActionResult<DataTable> CiudadGen()
        {
            string Sentencia = "Select codigo,nombre from alptabla where master=" +
                               "(select codigo from alptabla where nomtag='ACTCIU')";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                // adapter.SelectCommand.Parameters.Add(new SqlParameter("@codigo", codigo));
                adapter.Fill(dt);
            }

            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }


        [HttpGet]
        [Route("DPTOS/{dept}")]
        public ActionResult<DataTable> DPTOS([FromRoute] string dept)
        {
            string Sentencia =  "declare @dep nvarchar(25) = @depart "+
                                " select master, codigo, nombre from alptabla where master = '008'" +
                                " and(codigo like @dep or nombre like @dep)";



            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@depart", "%" + dept + "%"));
                adapter.Fill(dt);
            }

            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }



        [HttpGet]
        [Route("custodio/{codigo}")]
        public ActionResult<DataTable> custodio([FromRoute] string codigo)
        {
            //string Sentencia = "declare @ac varchar(200) = @codigo " +
            //                   "select codigo, apellido, nombre, FECCREA, USUCREA, CIUDAD, DPTO, FECMODI  from dp12a110 where " +
            //                   "CODIGO like @ac or APELLIDO like @ac or NOMBRE like @ac";

            string Sentencia =  " declare @ac varchar(200) = @codigo " +
                                " select a.codigo, a.apellido, a.nombre, a.CIUDAD, a.DPTO, b.nombre from dp12a110 a " +
                                " left join ALPTABLA b  on b.master = '008' and a.DPTO = b.codigo " +
                                " where a.CODIGO like @ac or a.APELLIDO like @ac or a.NOMBRE like @ac " +
                                " or b.nombre like @ac or a.DPTO like @ac";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@codigo", "%" + codigo + "%"));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }




        [HttpGet]
        [Route("RealClases/{codigo}")]
        public ActionResult<DataTable> RealClases([FromRoute] string codigo)
        {
            string Sentencia = "execute df_pLAN_aCTIVOS @codigo";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString)) {

                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@codigo", "%" + codigo + "%"));
                adapter.Fill(dt);
            
            }

            if (dt == null) {
                return NotFound("");
            }

            return Ok(dt);

        }
        
        [HttpGet]
        [Route("GetUserByCod/{name}")]
        public ActionResult<DataTable> GetUserByCod([FromRoute] string name)
        {
        
            string Sentencia = " declare @nomCust nvarchar(50) = @nameCu " +
                               " select LTRIM(RTRIM(b.NOMBRE +' ' + b.APELLIDO)) as nombreCustodio, a.Id, a.PLACA, " +
                               " a.CLASE, a.NOMBRE, a.CUSTODIO, a.DPTO, d.nombre as nomDpto, a.CIUDAD," +
                               " c.nombre as nomCiudad from dp12a120 as a " +
                               " left join dp12a110 as b ON b.CODIGO = a.CUSTODIO " +
                               " left join alptabla as c ON c.master = '007' and c.codigo = a.CIUDAD " +
                               " left join alptabla as d ON d.master = '008' and d.codigo = a.DPTO " +
                               " where b.NOMBRE like @nomCust ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString)) {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@nameCu", "%" + name + "%"));
                adapter.Fill(dt);
            }

            if (dt == null) {

                return NotFound("");
            
            }

            return Ok(dt);
        
        }
               

        [HttpGet]
        [Route("GetInfoQuest/{codigo}/{controlImgS}")]
        public ActionResult<DataTable> GetInfoQuest([FromRoute] string codigo, [FromRoute] string controlImgs)
        {
            string Sentencia = " declare @paramA nvarchar(10) = @codigo "                               +
                               " declare @paramB nvarchar(10) = @controlImgs "                          +
                               " select a.placa, a.CLASE, g.NOMBRE as NAMECLASS, "                      +
                               " a.NOMBRE , a.CUSTODIO, RTRIM(e.NOMBRE) + ' ' + "                       +
                               " RTRIM(e.APELLIDO) nombreCustodio, a.DPTO, "                            +
                               " b.nombre as DEPTNAME, a.CIUDAD, c.nombre as NAMECIUD, SERIE ,REFER, "  +
                               " a.USUCREA, a.USUMODI, USERFIN, a.GRUPO, f.nombre as NAMEGRUPO, "       +
                               " a.MARCA, d.nombre as NAMEMARCA, a.COLOR, a.controlImg, "                +
                               " PROVEEDOR, MODELO "                                                    +
                               " from dp12a120 as a "                                                   +
                               " left join ALPTABLA as b on master = '008' and b.codigo = a.DPTO "      +
                               " left join alptabla c on c.master = '007' and c.codigo = a.CIUDAD "     +
                               " left join ALPTABLA d on d.master = 'IA1' and d.codigo = a.MARCA "      +
                               " left join DP12A110 e on e.codigo = a.CUSTODIO "                        +
                               " left join dp11a110 f on f.grupo = a.GRUPO "                            +
                               " left join dp12a140 g on g.CODIGO_AUX = a.CLASE "                       +
                               " where a.dpto = @paramA and (len(@paramB)=0 or (len(@paramB)=1"         +
                               " and controlImg = @paramB) or (len(@paramB)!=1 and a.PLACA=@paramB)) ";


            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@codigo",  codigo ));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@controlImgs", controlImgs));
                adapter.Fill(dt);
            }

            if (dt == null) {
                return NotFound("");
            }

            return Ok(dt);

        }

        [HttpGet]
        [Route("cuentas/{codigo}")]
        public ActionResult<DataTable> cuentas([FromRoute] string codigo)
        {
            string Sentencia = "select codigo_aux codigo,nombre from DP01A110 where detalle = 1 or nombre like @codigo order by codigo_aux";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@codigo", "%" + codigo + "%"));
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