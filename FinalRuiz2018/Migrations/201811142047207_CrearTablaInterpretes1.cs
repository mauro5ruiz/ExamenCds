namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaInterpretes1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Interpretes", new[] { "NacionalidadId" });
            CreateIndex("dbo.Interpretes", new[] { "Apellido", "Nombres", "NacionalidadId" }, unique: true, name: "IX_Interprete_Apellido_Nombres_NacionalidadId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Interpretes", "IX_Interprete_Apellido_Nombres_NacionalidadId");
            CreateIndex("dbo.Interpretes", "NacionalidadId");
        }
    }
}
