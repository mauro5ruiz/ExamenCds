
namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaCanciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cancions",
                c => new
                    {
                        CancionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Duracion = c.DateTime(nullable: false),
                        CdId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CancionId)
                .ForeignKey("dbo.Cds", t => t.CdId)
                .Index(t => new { t.CdId, t.Nombre }, unique: true, name: "IX_Cancion_CdId_Nombre");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cancions", "CdId", "dbo.Cds");
            DropIndex("dbo.Cancions", "IX_Cancion_CdId_Nombre");
            DropTable("dbo.Cancions");
        }
    }
}
