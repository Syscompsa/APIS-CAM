using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSyscompsa.Models.InventoryApp
{
    public class reporteInv
    {
      public int Id { get; set; }
      public string FechaInv { get; set; }
        public string PlacaInv { get; set; }
        public string DescripInv { get; set; }
        public string Custodio { get; set; }
        public string Ciudad { get; set; }
        public string CampoA { get; set; }
        public string CampoB { get; set; }
    }
}
