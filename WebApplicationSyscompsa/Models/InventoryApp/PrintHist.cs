using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSyscompsa.Models.InventoryApp
{
    public class PrintHist
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string campoA { get; set; }
        public string campoB { get; set; }
        public string campoC { get; set; }
        public string codigo { get; set; }
    }
}
