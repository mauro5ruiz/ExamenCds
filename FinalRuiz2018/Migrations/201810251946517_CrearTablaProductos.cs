namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaProductos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cds",
                c => new
                    {
                        CdId = c.Int(nullable: false, identity: true),
                        EstiloId = c.Int(nullable: false),
                        InterpreteId = c.Int(nullable: false),
                        Pistas = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        AñoGrabacion = c.Int(nullable: false),
                        Duracion = c.Int(nullable: false),
                        PrecioCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CdId)
                .ForeignKey("dbo.Estiloes", t => t.EstiloId)
                .ForeignKey("dbo.Interpretes", t => t.InterpreteId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .Index(t => t.EstiloId)
                .Index(t => t.InterpreteId)
                .Index(t => t.Nombre, unique: true, name: "IX_Cd_Nombre")
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        TipoProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.TipoProductoes", t => t.TipoProductoId)
                .Index(t => t.TipoProductoId, unique: true, name: "IX_Productos_TipoProductoId");
            
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        CategoriaId = c.Int(nullable: false),
                        TipoDvdId = c.Int(nullable: false),
                        GeneroId = c.Int(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 100),
                        AñoGrabacion = c.Int(nullable: false),
                        Duracion = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DvdId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId)
                .ForeignKey("dbo.Generoes", t => t.GeneroId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .ForeignKey("dbo.TipoDvds", t => t.TipoDvdId)
                .Index(t => t.CategoriaId)
                .Index(t => t.TipoDvdId)
                .Index(t => t.GeneroId)
                .Index(t => t.Titulo, unique: true, name: "IX_Dvd_Titulo")
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.TipoProductoes",
                c => new
                    {
                        TipoProductoId = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.TipoProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "TipoProductoId", "dbo.TipoProductoes");
            DropForeignKey("dbo.Dvds", "TipoDvdId", "dbo.TipoDvds");
            DropForeignKey("dbo.Dvds", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.Dvds", "GeneroId", "dbo.Generoes");
            DropForeignKey("dbo.Dvds", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Cds", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.Cds", "InterpreteId", "dbo.Interpretes");
            DropForeignKey("dbo.Cds", "EstiloId", "dbo.Estiloes");
            DropIndex("dbo.Dvds", new[] { "ProductoId" });
            DropIndex("dbo.Dvds", "IX_Dvd_Titulo");
            DropIndex("dbo.Dvds", new[] { "GeneroId" });
            DropIndex("dbo.Dvds", new[] { "TipoDvdId" });
            DropIndex("dbo.Dvds", new[] { "CategoriaId" });
            DropIndex("dbo.Productoes", "IX_Productos_TipoProductoId");
            DropIndex("dbo.Cds", new[] { "ProductoId" });
            DropIndex("dbo.Cds", "IX_Cd_Nombre");
            DropIndex("dbo.Cds", new[] { "InterpreteId" });
            DropIndex("dbo.Cds", new[] { "EstiloId" });
            DropTable("dbo.TipoProductoes");
            DropTable("dbo.Dvds");
            DropTable("dbo.Productoes");
            DropTable("dbo.Cds");
        }
    }
}
