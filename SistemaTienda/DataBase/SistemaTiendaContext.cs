using SistemaTienda.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SistemaTienda.DataBase
{
    public class SistemaTiendaContext : DbContext
    {
        public SistemaTiendaContext() : base("name = SistemaTienda")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<GrupoDescuento> grupoDescuentos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<UnidadMedida> unidadMedidas { get; set; }
        public DbSet<CondicionPago> CondicionPago { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
    }
}