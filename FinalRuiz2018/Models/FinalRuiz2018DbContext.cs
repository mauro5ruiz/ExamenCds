using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FinalRuiz2018.Models
{
    public class FinalRuiz2018DbContext:DbContext
    {
        public FinalRuiz2018DbContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<TipoDvd> TiposDvd { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estilo> Estilos { get; set; }
        public DbSet<Nacionalidad> Nacionalidades { get; set; }
        public DbSet<Interprete> Interpretes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetallesCompra> DetallesCompra { get; set; }
        public DbSet<DetallesCompraTmp> DetallesCompraTmps { get; set; }

        public System.Data.Entity.DbSet<FinalRuiz2018.Models.Cd> Cds { get; set; }

        public System.Data.Entity.DbSet<FinalRuiz2018.Models.Dvd> Dvds { get; set; }
    }
}