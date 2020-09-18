using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSyscompsa.Models.InventoryApp;

namespace WebApplicationSyscompsa.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Web_Paleta> Web_Paleta { get; set; }
        public DbSet<WebUser> WebUser { get; set; }
        public DbSet<Dp12a120> DP12A120 { get; set; }
        public DbSet<Inventory_Data> Inventory_Data { get; set; }
        public DbSet<Placa_Post_Url> Placa_Post_Url { get; set; }
        public DbSet<Demo> Demo { get; set; }
        public DbSet<Interface_activoFijo> Interface_activoFijo { get; set; }
        public DbSet<ALPTABLA> ALPTABLA { get; set; }
        public DbSet<DP12A110> DP12A110 { get; set; }
        public DbSet<reporteInv> reporteInv { get; set; }
        public DbSet<dp11a110> dp11a110 { get; set; }


    }
}
