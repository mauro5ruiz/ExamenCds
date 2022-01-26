namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaEstilos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estiloes",
                c => new
                    {
                        EstiloId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EstiloId)
                .Index(t => t.Descripcion, name: "IX_Estilos_Descripcion");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Estiloes", "IX_Estilos_Descripcion");
            DropTable("dbo.Estiloes");
        }
    }
}
