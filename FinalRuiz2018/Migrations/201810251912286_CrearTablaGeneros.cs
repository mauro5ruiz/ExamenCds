namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaGeneros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        GeneroId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GeneroId)
                .Index(t => t.Descripcion, name: "IX_Generos_Descripcion");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Generoes", "IX_Generos_Descripcion");
            DropTable("dbo.Generoes");
        }
    }
}
