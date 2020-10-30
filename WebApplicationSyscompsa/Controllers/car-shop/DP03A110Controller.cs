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

namespace WebApplicationSyscompsa.Controllers.car_shop
{
    [Route("api/DP03A110")]
    [ApiController]
    public class DP03A110Controller : ControllerBase
    {
        private readonly AppDbContext _context;

        public DP03A110Controller(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("GeneralInfoDp03ASAL")]
        public ActionResult<DataTable> GeneralInfoDp03ASAL()
        {
            string Sentencia = "select periodo, no_parte, bodega, saldo00, saldo01,saldo02," +
                                "saldo03,saldo04, saldo05, saldo06, saldo07, saldo08 " +
                                " ,saldo09, saldo10, saldo11, saldo12 from DP03ASAL";


            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    // adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", Id));
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
        [Route("GeneralInfo")]
        public ActionResult<DataTable> GeneralInfoDp03A110()
        {
            string Sentencia = " SELECT S.*,M.*,T.* FROM DP03ASAL S " +
                               " LEFT JOIN DP03A110 M ON S.no_parte = M.no_parte " +
                               " Left join alptabla t with(nolock) on T.master =" +
                               " (select codigo from alptabla where nomtag = 'I_BODE') and S.bodega = T.codigo " +
                               " WHERE T.campo2 = '1' ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    // adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", Id));
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
        [Route("GetProParam/{parm}")]
        public ActionResult<DataTable> GetProParam([FromRoute] string parm)
        {
            string Sentencia = "declare @param nvarchar(20) = @parm " +
                               " SELECT a.clase, clase.nombre nomclase " +
                               " FROM DP03A110 A " +
                               " LEFT JOIN(select codigo, nombre from alptabla where master = " +
                               " (select codigo from alptabla where nomtag = 'i_clase')) CLASE ON CLASE.codigo = A.clase " +
                               " where(len(@param) = 0 or clase.nombre like @param) and A.ESTADO = 'A' and a.tipo = 'N' " +
                               " group by a.clase, clase.nombre " +
                               " order By clase.nombre ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@parm", "%" + parm + "%"));
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
        [Route("GetByClase/{clas}")]
        public ActionResult<DataTable> GetByClase([FromRoute] string clas)
        {

            string Sentencia = " Declare @valor varchar(75)= @clas " +
                               " select a.clase,coalesce(iclase.nombre, '')" +
                               " nomClase,a.subclase,a.no_parte,a.nombre from dp03a110 a " +
                               " join(select codigo, nombre from alptabla where master = " +
                               " (select codigo from alptabla where nomtag = 'i_clase')) " +
                               " iclase on iclase.codigo = a.clase " +
                               " where(len(@valor) = 0 or a.clase = @valor) order by nombre ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@clas", clas ));
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
        [Route("GetBySubClase/{subclas}")]
        public ActionResult<DataTable> GetBySubClase([FromRoute] string subclas)
        {
            string Sentencia = " Declare @valor varchar(75)= @subclas " +
                               " select a.clase,coalesce(iclase.nombre, '')" +
                               " nomClase,a.subclase,a.no_parte,a.nombre from dp03a110 a " +
                               " join(select codigo, nombre from alptabla where master =" +
                               " (select codigo from alptabla where nomtag = 'i_subcla')) " +
                               " iclase on iclase.codigo = a.subclase " +
                               " where(len(@valor) = 0 or a.subclase = @valor) ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@subclas", subclas));
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
        [Route("GetClas")]
        public ActionResult<DataTable> GetClas()
        {
            // string Sentencia = " select codigo, nombre from dbo.df_alptabla('I_CLASE')";
            string Sentencia = "select codigo, nombre from alptabla where master = ( select codigo from alptabla where nomtag = 'I_CLASE')";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    // adapter.SelectCommand.Parameters.Add(new SqlParameter("@subclas", subclas));
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
        [Route("GetMarca")]
        public ActionResult<DataTable> GetMarca()
        {
            // string Sentencia = " select codigo, nombre from dbo.df_alptabla('I_CLASE')";
            string Sentencia = "select codigo, nombre from alptabla where master =(select codigo from alptabla where nomtag = 'i_marca')";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    // adapter.SelectCommand.Parameters.Add(new SqlParameter("@subclas", subclas));
                    adapter.Fill(dt);
                }
            }

            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [Route("GetProductsInits/{codeA}/{codeB}")]
        public ActionResult<DataTable> GetProductsInits([FromRoute] string codeA, [FromRoute] string codeB)
        {
            // string Sentencia = " select codigo, nombre from dbo.df_alptabla('I_CLASE')";
            string Sentencia = " Declare " + 
                               " @valorcla varchar(75) = @codeA, " +
                               " @valorsubcla varchar(75) = @codeB, " +
                               " @valormarca varchar(75) = '' " +
                               " select a.clase,coalesce(clase.nombre, '') clase, a.aplica, a.imagen, a.imagen2, " +
                               " a.pvpu1,a.subclase,coalesce(iclase.nombre, '') nomsubcla,a.marca ,coalesce(marca.nombre, '') nommarca " +
                               " ,a.no_parte,a.nombre " +
                               " from dp03a110 a" +
                               " left join(select codigo, nombre from alptabla where master " +
                               " = (select codigo from alptabla where nomtag = 'i_clase')) clase on clase.codigo = a.clase " +
                               " left join(select codigo, nombre from alptabla where master =" +
                               " (select codigo from alptabla where nomtag = 'i_subcla')) iclase on iclase.codigo = a.subclase " +
                               " left join(select codigo, nombre from alptabla where master = " + 
                               " (select codigo from alptabla where nomtag = 'i_marca')) marca on marca.codigo = a.marca " +
                               " where(len(@valorcla) = 0 or a.clase = @valorcla or a.subclase = @valorsubcla) " +
                               " order by a.subclase ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@codeA", codeA));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@codeB", codeB));
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
        [Route("GetProdVend")]
        public ActionResult<DataTable> GetProdVend()
        {
            // string Sentencia = " select codigo, nombre from dbo.df_alptabla('I_CLASE')";
            string Sentencia = " select a.no_parte,c.nombre,sum(a.cantidad) vendidos,c.pvpu1,c.pvpu2,c.pvpu3,c.pvpu4,c.pvpu5, c.imagen, c.imagen2 " +
                " from dp03amov a " +
                " left join dpinvcab b on b.tipo = a.tipo and a.numero = b.numero " +
                " left join dp03a110 c on c.no_parte = a.no_parte " +
                " where b.grupo = 'V' " +
                " group by a.no_parte,c.nombre,c.pvpu1,c.pvpu2,c.pvpu3,c.pvpu4,c.pvpu5,c.imagen, c.imagen2";
                
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    // adapter.SelectCommand.Parameters.Add(new SqlParameter("@subclas", subclas));
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