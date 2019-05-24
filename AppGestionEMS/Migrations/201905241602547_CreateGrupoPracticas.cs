namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGrupoPracticas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrupoPracticas",
                c => new
                    {
                        GrupoPracticasId = c.String(nullable: false, maxLength: 128),
                        activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoPracticasId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GrupoPracticas");
        }
    }
}
