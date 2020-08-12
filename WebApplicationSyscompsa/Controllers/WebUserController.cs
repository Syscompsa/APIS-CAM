using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationSyscompsa.Models;

namespace WebApplicationSyscompsa.Controllers
{
    [Route("api/UserLogin")]
    [ApiController]
    public class WebUserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WebUserController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] WebUser userInfo)
        {
            var result = await _context.WebUser.FirstOrDefaultAsync(x =>
                                x.WebUsu == userInfo.WebUsu && x.WebPass == userInfo.WebPass);

            if (result != null)
            {
                return Ok(result);
            }
            else {
                //ModelState.AddModelError(string.Empty, "Usuario o contraseña invalido");
                return BadRequest("Datos incorrectos");
            }
        }
    }
}