namespace FinalRuiz2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablaProductos1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dvds", "PrecioCosto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Dvds", "PrecioVenta", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dvds", "PrecioVenta");
            DropColumn("dbo.Dvds", "PrecioCosto");
        }
    }
}
