namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateConvocatorias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Convocatorias",
                c => new
                    {
                        ConvocatoriaId = c.String(nullable: false, maxLength: 128),
                        actual = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ConvocatoriaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Convocatorias");
        }
    }
}
