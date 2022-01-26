namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificarDatoCancion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cancions", "Duracion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cancions", "Duracion", c => c.DateTime(nullable: false));
        }
    }
}
