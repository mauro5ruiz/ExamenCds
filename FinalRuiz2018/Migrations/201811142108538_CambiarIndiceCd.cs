namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiarIndiceCd : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cds", new[] { "InterpreteId" });
            DropIndex("dbo.Cds", "IX_Cd_Nombre");
            CreateIndex("dbo.Cds", new[] { "InterpreteId", "Nombre" }, unique: true, name: "IX_Cd_InterpreteId_Nombre");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cds", "IX_Cd_InterpreteId_Nombre");
            CreateIndex("dbo.Cds", "Nombre", unique: true, name: "IX_Cd_Nombre");
            CreateIndex("dbo.Cds", "InterpreteId");
        }
    }
}
