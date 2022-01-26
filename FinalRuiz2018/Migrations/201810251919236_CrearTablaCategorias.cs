namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaCategorias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoriaId)
                .Index(t => t.Descripcion, name: "IX_Categorias_Descripcion");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categorias", "IX_Categorias_Descripcion");
            DropTable("dbo.Categorias");
        }
    }
}
