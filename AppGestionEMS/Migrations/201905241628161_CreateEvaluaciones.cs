namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEvaluaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluaciones",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CursoId = c.Int(nullable: false),
                        GrupoId = c.String(nullable: false, maxLength: 128),
                        GrupoPracticasId = c.String(nullable: false, maxLength: 128),
                        ordinariaExtraordinaria = c.Boolean(nullable: false),
                        nota = c.Single(nullable: false),
                        examenPractica = c.Boolean(nullable: false),
                        notaFinal = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CursoId, t.GrupoId, t.GrupoPracticasId })
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.Grupos", t => t.GrupoId, cascadeDelete: true)
                .ForeignKey("dbo.GrupoPracticas", t => t.GrupoPracticasId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CursoId)
                .Index(t => t.GrupoId)
                .Index(t => t.GrupoPracticasId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluaciones", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Evaluaciones", "GrupoPracticasId", "dbo.GrupoPracticas");
            DropForeignKey("dbo.Evaluaciones", "GrupoId", "dbo.Grupos");
            DropForeignKey("dbo.Evaluaciones", "CursoId", "dbo.Cursos");
            DropIndex("dbo.Evaluaciones", new[] { "GrupoPracticasId" });
            DropIndex("dbo.Evaluaciones", new[] { "GrupoId" });
            DropIndex("dbo.Evaluaciones", new[] { "CursoId" });
            DropIndex("dbo.Evaluaciones", new[] { "UserId" });
            DropTable("dbo.Evaluaciones");
        }
    }
}
