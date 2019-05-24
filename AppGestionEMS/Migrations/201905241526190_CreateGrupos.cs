namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGrupos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grupos",
                c => new
                    {
                        GrupoId = c.String(nullable: false, maxLength: 128),
                        mañanatarde = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Grupos");
        }
    }
}
