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

namespace WebApplicationSyscompsa.Controllers
{
    [Route("api/AR_3-User")]
    [ApiController]
    public class User_ColorController : ControllerBase
    {

        private readonly AppDbContext _context;
        public User_ColorController(AppDbContext context)
        {
            this._context = context;
        }

        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Login([FromBody] User_Color userInfo)
        //{
        //    var result = await _context.User_Color.FirstOrDefaultAsync(x =>
        //                        x.Name_U == userInfo.Name_U && x.Password == userInfo.Password);

        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        //ModelState.AddModelError(string.Empty, "Usuario o contraseña invalido");
        //        return BadRequest("Datos incorrectos");
        //    }
        //}
        
        //[HttpGet]
        //[Route("GetUser/{Id}")]
        //public ActionResult<DataTable> GetUser([FromRoute] int Id)
        //{
        //    string Sentencia = "select *  from User_Color where  Id = @Id";

        //    DataTable dt = new DataTable();
        //    using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(Sentencia, connection))
        //        {
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            adapter.SelectCommand.CommandType = CommandType.Text;
        //            //adapter.SelectCommand.Parameters.Add(new SqlParameter("@siembra", siembra));
        //            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", Id));
        //            adapter.Fill(dt);
        //        }
        //    }
        //    if (dt == null)
        //    {
        //        return NotFound("");
        //    }
        //    return Ok(dt);
        //}

    }
}