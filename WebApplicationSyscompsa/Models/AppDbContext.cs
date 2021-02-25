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
        : base(options) { }
        public DbSet<Web_Paleta> Web_Paleta { get; set; }
        public DbSet<WebUser> WebUser { get; set; }
        public DbSet<Dp12a120> DP12A120 { get; set; }
        public DbSet<Dp12a120_f> DP12A120_F { get; set; }
        public DbSet<Inventory_Data> Inventory_Data { get; set; }
        public DbSet<Placa_Post_Url> Placa_Post_Url { get; set; }
        public DbSet<Demo> Demo { get; set; }
        public DbSet<Interface_activoFijo> Interface_activoFijo { get; set; }
        public DbSet<ALPTABLA> ALPTABLA { get; set; }

        public DbSet<DP12A110> DP12A110 { get; set; }
        public DbSet<reporteInv> reporteInv { get; set; }
        public DbSet<dp11a110> dp11a110 { get; set; }
        public DbSet<ANEXO_DP12A120_F> ANEXO_DP12A120_F { get; set; }
   
        //asignamos el valor de los decimales que estan truncandose mediante c#
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Dp12a120>().HasKey(pk => pk.PLACA).HasName("PLACA");
            modelBuilder.Entity<Dp12a120_f>().HasKey(pk => pk.PLACA).HasName("PLACA");
            // modelBuilder.Entity<ANEXO_DP12A120_F>().HasKey(pk => pk.placa).HasName("placa");

            //ANEXO_DP12A120_F
            #region
            modelBuilder.Entity<ANEXO_DP12A120_F>().Property(a => a.avcomer).HasColumnType("decimal(10,2)");
            #endregion

            //dp12a120
            #region
            modelBuilder.Entity<Dp12a120>().Property(a => a.VALOR).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120>().Property(a => a.VALOR2).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120>().Property(a => a.VALOR_RES2).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120>().Property(a => a.VALOR_RESI).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120>().Property(a => a.VALRES).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120>().Property(a => a.VAL_NORMAL).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120>().Property(a => a.VAL_REVAL).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120>().Property(a => a.VIDAUTIL).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120_f>().Property(a => a.VALOR).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120_f>().Property(a => a.VALOR2).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120_f>().Property(a => a.VALOR_RES2).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120_f>().Property(a => a.VALOR_RESI).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120_f>().Property(a => a.VAL_NORMAL).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120_f>().Property(a => a.VAL_REVAL).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120_f>().Property(a => a.VIDAUTIL).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Dp12a120_f>().Property(a => a.VALRES).HasColumnType("decimal(10,2)");
            #endregion

            //ALPTABLA
            #region
            modelBuilder.Entity<ALPTABLA>().Property(a => a.Lencod).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<ALPTABLA>().Property(a => a.Valor).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<ALPTABLA>().Property(a => a.VALOR2).HasColumnType("decimal(10,2)");
            #endregion

            //DP12A110
            #region
            //modelBuilder.Entity<Dp12a120>().Property(a => a.VALOR).HasColumnType("decimal(10,2)");
            //modelBuilder.Entity<Dp12a120>().Property(a => a.VALOR2).HasColumnType("decimal(10,2)");
            //modelBuilder.Entity<Dp12a120>().Property(a => a.VALOR_RES2).HasColumnType("decimal(10,2)");
            //modelBuilder.Entity<Dp12a120>().Property(a => a.VALOR_RESI).HasColumnType("decimal(10,2)");
            //modelBuilder.Entity<Dp12a120>().Property(a => a.VALRES).HasColumnType("decimal(10,2)");
            //modelBuilder.Entity<Dp12a120>().Property(a => a.VAL_NORMAL).HasColumnType("decimal(10,2)");
            //modelBuilder.Entity<Dp12a120>().Property(a => a.VAL_REVAL).HasColumnType("decimal(10,2)");
            //modelBuilder.Entity<Dp12a120>().Property(a => a.VIDAUTIL).HasColumnType("decimal(10,2)");
            #endregion

            //AppConfig
            #region
            //modelBuilder.Entity<AppConfig>().Property(a => a.BgOpacityDashA).HasColumnType("decimal(10,2)");
            //modelBuilder.Entity<AppConfig>().Property(a => a.BgOpacityDashB).HasColumnType("decimal(10,2)");
            #endregion
                 
        }

        public DbSet<PrintHist> PrintHist { get; set; }

    }
}
