namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaUsuarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false, maxLength: 256),
                        Apellido = c.String(nullable: false, maxLength: 100),
                        Nombres = c.String(nullable: false, maxLength: 100),
                        Celular = c.String(),
                        Direccion = c.String(),
                        Foto = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .Index(t => t.NombreUsuario, unique: true, name: "IX_Usuarios_NombreUsuario");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuarios", "IX_Usuarios_NombreUsuario");
            DropTable("dbo.Usuarios");
        }
    }
}
