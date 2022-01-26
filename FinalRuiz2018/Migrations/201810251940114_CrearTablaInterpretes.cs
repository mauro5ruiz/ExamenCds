namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaInterpretes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interpretes",
                c => new
                    {
                        InterpreteId = c.Int(nullable: false, identity: true),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        NacionalidadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InterpreteId)
                .ForeignKey("dbo.Nacionalidads", t => t.NacionalidadId)
                .Index(t => t.NacionalidadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interpretes", "NacionalidadId", "dbo.Nacionalidads");
            DropIndex("dbo.Interpretes", new[] { "NacionalidadId" });
            DropTable("dbo.Interpretes");
        }
    }
}
