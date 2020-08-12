using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSyscompsa.Models
{
    public class WebUser
    {
        public int Id { get; set; }
        public string WebUsu { get; set; }
        public string WebPass { get; set; }
        public char TipoMu { get; set; }
    }
}
