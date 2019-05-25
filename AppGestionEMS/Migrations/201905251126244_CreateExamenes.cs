namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateExamenes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Examenes",
                c => new
                    {
                        ExamenesId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ExamenesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Examenes");
        }
    }
}
