using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSyscompsa.Models.carshop;
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
        public DbSet<DP03A110> DP03A110 { get; set; }
        public DbSet<DP03ASAL> DP03ASAL { get; set; }

        //asignamos el valor de los decimales que estan truncandose mediante c#
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //DP03ASAL
            #region
            modelBuilder.Entity<DP03ASAL>().HasNoKey();
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo00).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo00).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo00).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo01).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo02).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo03).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo04).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo05).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo06).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo07).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo08).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo09).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo10).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo11).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.bodega).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo00).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo02).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo03).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo04).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo05).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo06).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo07).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo08).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo09).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo10).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo11).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo12).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu00).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu01).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu02).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu03).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu04).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu06).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu07).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu08).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu09).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu10).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu11).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu12).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci00).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci01).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci02).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci03).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci04).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci05).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci06).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci07).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci08).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci09).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci10).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci11).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.preci12).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.saldo12).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten00).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten01).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten02).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten03).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten04).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten05).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten06).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten07).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten08).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten09).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten10).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten11).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.ulten12).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costo01).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<DP03ASAL>().Property(b => b.costu05).HasColumnType("decimal(10, 2)");
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
            modelBuilder.Entity<AppConfig>().Property(a => a.BgOpacityDashA).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<AppConfig>().Property(a => a.BgOpacityDashB).HasColumnType("decimal(10,2)");
            #endregion

            //DP03A110
            #region
            modelBuilder.Entity<DP03A110>().Property(a => a.c_ultcom).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.cantini).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.cantini2).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.costini).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.costo_alor).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.cubicac).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.exmax).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.factor).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.hasta2).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.hasta3).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.hasta4).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.hasta5).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.master).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pesobruto).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.cubicau).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.exmin).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pesocaja).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pordes).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pvpc1).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pvpc2).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pvpc3).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pvpc4).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pvpc5).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pvpu1).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pvpu2).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pvpu3).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pvpu5).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.ultcompra).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.v_ultcom).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.v_ultven).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.porceArancel).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DP03A110>().Property(a => a.pvpu4).HasColumnType("decimal(10,2)");
            #endregion
        }

        public DbSet<PrintHist> PrintHist { get; set; }
        public DbSet<AppConfig> AppConfig { get; set; }


    }
}
