namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTutorias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tutorias",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GrupoPracticasId = c.String(nullable: false, maxLength: 128),
                        CursoId = c.Int(nullable: false),
                        ConvocatoriaId = c.String(nullable: false, maxLength: 128),
                        IdTutoria = c.String(),
                        IdAsignatura = c.String(),
                        fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GrupoPracticasId, t.CursoId, t.ConvocatoriaId })
                .ForeignKey("dbo.Convocatorias", t => t.ConvocatoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.GrupoPracticas", t => t.GrupoPracticasId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GrupoPracticasId)
                .Index(t => t.CursoId)
                .Index(t => t.ConvocatoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutorias", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tutorias", "GrupoPracticasId", "dbo.GrupoPracticas");
            DropForeignKey("dbo.Tutorias", "CursoId", "dbo.Cursos");
            DropForeignKey("dbo.Tutorias", "ConvocatoriaId", "dbo.Convocatorias");
            DropIndex("dbo.Tutorias", new[] { "ConvocatoriaId" });
            DropIndex("dbo.Tutorias", new[] { "CursoId" });
            DropIndex("dbo.Tutorias", new[] { "GrupoPracticasId" });
            DropIndex("dbo.Tutorias", new[] { "UserId" });
            DropTable("dbo.Tutorias");
        }
    }
}
