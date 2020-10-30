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
using WebApplicationSyscompsa.Models.carshop;
using ImageMagick;
using System.IO;
using System.Drawing;

namespace WebApplicationSyscompsa.Controllers.car_shop
{
    [Route("api/AppConfig")]
    [ApiController]
    public class AppConfigController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppConfigController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("Colors")]
        public ActionResult<DataTable> Colors()
        {
            string Sentencia = "select * from AppConfig order by Id desc";
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

        public void SaveImage(string base64)
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64)))
            {
                using (Bitmap bm2 = new Bitmap(ms))
                {
                    bm2.Save("SavingPath" + "ImageName.jpg");
                }
            }
        }

        [HttpPost]
        [Route("ConfigSave")]
        public async Task<IActionResult> ConfigSave([FromBody] AppConfig model)
        {
            string imgLg = model.Logotipo;
            using(MagickImage RedimMagickIm = new MagickImage(imgLg))
            {
                RedimMagickIm.Resize(900, 0);
                RedimMagickIm.Write(imgLg);
            }           

            if (ModelState.IsValid)
            {
                _context.AppConfig.Add(model);
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
        [Route("UpdateSave/{Id}")]
        public async Task<IActionResult> UpdateInterfaceConfig([FromRoute] int Id, [FromBody] AppConfig model)
        {
            if (Id != model.Id)
            {
                return BadRequest("No se ha pordido acutalizar");
            }
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(model);
        }

    }
}