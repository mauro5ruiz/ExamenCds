namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaProveedores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        ProveedorId = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(nullable: false, maxLength: 256),
                        Cuil = c.String(nullable: false, maxLength: 12),
                        NroTelefono = c.String(),
                        Direccion = c.String(),
                        Email = c.String(),
                        Observacion = c.String(),
                    })
                .PrimaryKey(t => t.ProveedorId)
                .Index(t => t.RazonSocial, unique: true, name: "IX_Proveedores_RazonSocial");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Proveedors", "IX_Proveedores_RazonSocial");
            DropTable("dbo.Proveedors");
        }
    }
}
