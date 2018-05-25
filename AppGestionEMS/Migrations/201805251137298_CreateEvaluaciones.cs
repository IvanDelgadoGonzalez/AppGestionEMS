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
                        Id = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Convocatoria = c.Int(nullable: false),
                        Trabajo1 = c.Int(nullable: false),
                        Trabajo2 = c.Int(nullable: false),
                        Trabajo3 = c.Int(nullable: false),
                        Test = c.Int(nullable: false),
                        Practica = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CursoId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluaciones", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Evaluaciones", "CursoId", "dbo.Cursos");
            DropIndex("dbo.Evaluaciones", new[] { "UserId" });
            DropIndex("dbo.Evaluaciones", new[] { "CursoId" });
            DropTable("dbo.Evaluaciones");
        }
    }
}
