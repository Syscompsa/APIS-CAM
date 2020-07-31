using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using WebApplicationSyscompsa.Models;

namespace WebApplicationSyscompsa.Controllers
{
    [Route("api/AR_1-GraficasCamApp")]
    [ApiController]
    public class GraficasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GraficasController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("sp_0314e/{siembra}")]
        public ActionResult<DataTable> Getsp_0314e([FromRoute] string siembra)
        {
            string Sentencia = "exec sp_0314e @siembra, 1";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
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
        [Route("SP_GRAFICAWEB/{siembra}")]
        public ActionResult<DataTable> GetSP_GRAFICAWEB([FromRoute] string siembra)
        {
            string Sentencia = "exec SP_GRAFICAWEB @siembra";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
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
        [Route("sp_datagraph/{siembra}")]
        public ActionResult<DataTable> Sp_datagraph([FromRoute] string siembra)
        {
            string Sentencia = "exec sp_datagraph @siembra";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
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
        [Route("sp_alimenproy/{siembra}")]
        public ActionResult<DataTable> Sp_alimenproy([FromRoute] string siembra)
        {
            string Sentencia = "exec sp_alimenproy @siembra";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
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
        [Route("GetGenView")]
        public ActionResult<DataTable> GetGenView()
        {

            string Sentencia = "select A.codigo, A.fecha, A.fechaven, A.camaron, C.nombre as nomcamaronera,A.piscina, B.nombre as nompiscina" +
                                " from dp03a188 A left join dp13a110 C ON A.camaron = C.cod_cam left join dp03a130 B ON b.codigo = A.piscina" +
                                " where fechaven > GETDATE()";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            if (dt == null)
            { return NotFound(""); }

            return Ok(dt);
        }

    }
}