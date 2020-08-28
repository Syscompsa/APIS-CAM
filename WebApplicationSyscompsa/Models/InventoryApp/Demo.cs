using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSyscompsa.Models.InventoryApp
{
    public class Demo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Nombre_P { get; set; }
        public string Custodio { get; set; }
        public string Ciudad { get; set; }
        public DateTime? Fecha_Back { get; set; }
        public DateTime? Fecha_Inv { get; set; }
        public string Existe { get; set; }
        
    }
}
