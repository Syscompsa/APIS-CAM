using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSyscompsa.Models;
using WebApplicationSyscompsa.Models.InventoryApp;

namespace WebApplicationSyscompsa.Controllers.InventoryApp_Controller
{
    [Route("api/Custodios")]
    [ApiController]
    public class Dp12a110Controller : ControllerBase
    {
        private readonly AppDbContext _context;
        public Dp12a110Controller(AppDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("PostCust")]
        public async Task<IActionResult> PostCust([FromBody] DP12A110 model)
        {



            if (ModelState.IsValid)
            {

                _context.DP12A110.Add(model);


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

    }
}
