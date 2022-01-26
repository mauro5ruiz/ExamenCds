namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crearTablaDetallesCompras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetallesCompras",
                c => new
                    {
                        DetalleCompraId = c.Int(nullable: false, identity: true),
                        CompraId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleCompraId)
                .ForeignKey("dbo.Compras", t => t.CompraId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .Index(t => t.CompraId)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallesCompras", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetallesCompras", "CompraId", "dbo.Compras");
            DropIndex("dbo.DetallesCompras", new[] { "ProductoId" });
            DropIndex("dbo.DetallesCompras", new[] { "CompraId" });
            DropTable("dbo.DetallesCompras");
        }
    }
}
