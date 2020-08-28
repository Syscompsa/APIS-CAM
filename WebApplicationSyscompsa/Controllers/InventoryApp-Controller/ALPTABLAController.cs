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
                               "(select codigo from alptabla where nomtag='INVGRUPO') and codigo=@codigo";

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
        [Route("GrupoActivoGen")]
        public ActionResult<DataTable> GrupoActivoGen()
        {
            //actualmente solo hay un codigo asignado 001 = varios
            string Sentencia = "Select codigo,nombre from alptabla where master=" +
                               "(select codigo from alptabla where nomtag='INVGRUPO')";

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
        [Route("Modelo/{codigo}")]
        public ActionResult<DataTable> Modelo([FromRoute] string codigo)
        {
            string Sentencia = "Select codigo,nombre from alptabla where master=" +
                               "(select codigo from alptabla where nomtag='IA_MODELO') and codigo=@codigo";

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
        [Route("ModeloGen")]
        public ActionResult<DataTable> ModeloGen()
        {
            string Sentencia = "Select codigo,nombre from alptabla where master=" +
                               "(select codigo from alptabla where nomtag='IA_MODELO')";

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
        [Route("MarcaGen")]
        public ActionResult<DataTable> MarcaGen()
        {
            string Sentencia = "Select codigo,nombre from alptabla where master=" +
                               "(select codigo from alptabla where nomtag='IA_MARCA')";

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
        [Route("ACTCIU/{codigo}")]
        public ActionResult<DataTable> ACTCIU([FromRoute] string codigo)
        {
            string Sentencia = "Select codigo,nombre from alptabla where master=" +
                               "(select codigo from alptabla where nomtag='ACTCIU') and codigo=@codigo";

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
        [Route("CiudadGen/{codigo}")]
        public ActionResult<DataTable> CiudadGen([FromRoute] string codigo)
        {
            string Sentencia = "Select codigo,nombre from alptabla where master=" +
                               "(select codigo from alptabla where nomtag='ACTCIU')";

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
        [Route("DPTOS/{codigo}")]
        public ActionResult<DataTable> DPTOS([FromRoute] string codigo)
        {
            string Sentencia = "Select codigo,nombre from alptabla where master=" +
                               "(select codigo from alptabla where nomtag='DPTOS') and codigo=@codigo";

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
        [Route("DPTOSGen")]
        public ActionResult<DataTable> DPTOSGen()
        {
            string Sentencia = "Select codigo,nombre from alptabla where master=" +
                               "(select codigo from alptabla where nomtag='DPTOS')";

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




    }
}