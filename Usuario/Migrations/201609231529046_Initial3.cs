namespace Usuario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(),
                        UrlProgram = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Programas");
        }
    }
}
