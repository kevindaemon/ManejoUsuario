namespace Usuario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsuarioGrupoes",
                c => new
                    {
                        idUsuario = c.Int(nullable: false),
                        idGrupo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idUsuario, t.idGrupo })
                .ForeignKey("dbo.Grupoes", t => t.idGrupo, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idGrupo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioGrupoes", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioGrupoes", "idGrupo", "dbo.Grupoes");
            DropIndex("dbo.UsuarioGrupoes", new[] { "idGrupo" });
            DropIndex("dbo.UsuarioGrupoes", new[] { "idUsuario" });
            DropTable("dbo.UsuarioGrupoes");
        }
    }
}
