using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSyscompsa.Models.carshop
{
    public class Promocionales
    {
      public int Id { get; set; }
      public string DataProm { get; set; }
      public string Usuario { get; set; }
      public string ImgA { get; set; }
      public string ImgB { get; set; }
      public string ImgC { get; set; }
      public string DataB { get; set; }
      public string DataC { get; set; }
      public decimal PpromA { get; set; }
      public decimal PpromB { get; set; }
      public DateTime? Fedesde { get; set; }
      public DateTime? Fehasta { get; set; }
    }
}
