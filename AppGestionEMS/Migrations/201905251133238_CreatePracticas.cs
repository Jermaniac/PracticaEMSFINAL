namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePracticas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Practicas",
                c => new
                    {
                        PracticasId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PracticasId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Practicas");
        }
    }
}
