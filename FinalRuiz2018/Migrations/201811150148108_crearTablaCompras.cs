namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crearTablaCompras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        CompraId = c.Int(nullable: false, identity: true),
                        ProveedorId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.CompraId)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId)
                .Index(t => t.ProveedorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compras", "ProveedorId", "dbo.Proveedors");
            DropIndex("dbo.Compras", new[] { "ProveedorId" });
            DropTable("dbo.Compras");
        }
    }
}
