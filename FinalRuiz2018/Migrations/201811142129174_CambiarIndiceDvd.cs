namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiarIndiceDvd : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Dvds", new[] { "CategoriaId" });
            DropIndex("dbo.Dvds", new[] { "TipoDvdId" });
            DropIndex("dbo.Dvds", new[] { "GeneroId" });
            CreateIndex("dbo.Dvds", new[] { "GeneroId", "CategoriaId", "TipoDvdId", "Titulo" }, unique: true, name: "IX_Dvd_GeneroId_CategoriaId_TipoDvdId_Titulo");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Dvds", "IX_Dvd_GeneroId_CategoriaId_TipoDvdId_Titulo");
            CreateIndex("dbo.Dvds", "GeneroId");
            CreateIndex("dbo.Dvds", "TipoDvdId");
            CreateIndex("dbo.Dvds", "CategoriaId");
        }
    }
}
