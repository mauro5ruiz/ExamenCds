namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crearTablaDetallesComprasTmp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetallesCompraTmps",
                c => new
                    {
                        DetallesCompraTmpId = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false, maxLength: 256),
                        ProductoId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DetallesCompraTmpId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallesCompraTmps", "ProductoId", "dbo.Productoes");
            DropIndex("dbo.DetallesCompraTmps", new[] { "ProductoId" });
            DropTable("dbo.DetallesCompraTmps");
        }
    }
}
