namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaNacionalidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nacionalidads",
                c => new
                    {
                        NacionalidadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.NacionalidadId)
                .Index(t => t.Nombre, name: "IX_Nacionalidades_Nombre");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Nacionalidads", "IX_Nacionalidades_Nombre");
            DropTable("dbo.Nacionalidads");
        }
    }
}
