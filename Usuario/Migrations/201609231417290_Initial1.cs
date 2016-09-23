namespace Usuario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "name");
        }
    }
}
