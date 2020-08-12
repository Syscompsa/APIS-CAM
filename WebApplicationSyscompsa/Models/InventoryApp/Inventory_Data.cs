using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSyscompsa.Models.InventoryApp
{
    public class Inventory_Data
    {
        public int Id { get; set; }
        public DateTime? Fecha_Inv { get; set; }
        public string Aud_Usuario { get; set; }
        public DateTime? Aud_Dt { get; set; }
        public DateTime? Fecha_Actual { get; set; }
        public string No_Parte { get; set; }
        public string H_campo_A { get; set; }
        public string H_campo_B { get; set; }
        public string H_campo_C { get; set; }
        public string H_campo_D { get; set; }
    }
}
