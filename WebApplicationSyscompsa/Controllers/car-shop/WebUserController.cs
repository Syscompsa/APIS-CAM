using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSyscompsa.Models;

namespace WebApplicationSyscompsa.Controllers.car_shop
{
    [Route("api/User")]
    [ApiController]
    public class WebUserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WebUserController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("GetUsuarios")]
        public IEnumerable<WebUser> GetClientes()
        {
            return _context.WebUser;
        }

    }
}