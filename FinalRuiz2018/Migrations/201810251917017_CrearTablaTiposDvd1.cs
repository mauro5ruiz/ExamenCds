namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaTiposDvd1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoDvds",
                c => new
                    {
                        TipoDvdId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TipoDvdId)
                .Index(t => t.Nombre, name: "IX_Tipos_Nombre");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TipoDvds", "IX_Tipos_Nombre");
            DropTable("dbo.TipoDvds");
        }
    }
}
