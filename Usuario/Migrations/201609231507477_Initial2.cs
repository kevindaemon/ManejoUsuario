namespace Usuario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grupoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        group_name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Grupoes");
        }
    }
}
