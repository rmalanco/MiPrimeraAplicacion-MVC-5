namespace MiPrimeraAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnos",
                c => new
                    {
                        AlumnoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(),
                        FechaMatricula = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AlumnoId);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        MatriculaId = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        AlumnoId = c.Int(nullable: false),
                        Precio = c.Double(nullable: false),
                        AnteriorCurso_CursoId = c.Int(),
                        SiguienteCurso_CursoId = c.Int(),
                    })
                .PrimaryKey(t => t.MatriculaId)
                .ForeignKey("dbo.Alumnos", t => t.AlumnoId, cascadeDelete: true)
                .ForeignKey("dbo.Cursoes", t => t.AnteriorCurso_CursoId)
                .ForeignKey("dbo.Cursoes", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.Cursoes", t => t.SiguienteCurso_CursoId)
                .Index(t => t.CursoId)
                .Index(t => t.AlumnoId)
                .Index(t => t.AnteriorCurso_CursoId)
                .Index(t => t.SiguienteCurso_CursoId);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(maxLength: 50),
                        Creditos = c.Int(nullable: false),
                        NumeroClases = c.Int(nullable: false),
                        TStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.CursoId)
                .Index(t => t.Creditos);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaAlta = c.DateTime(nullable: false),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LicenciaConducirs",
                c => new
                    {
                        NumeroLicencia = c.Int(nullable: false),
                        Pais = c.String(nullable: false, maxLength: 128),
                        FechaExpedicion = c.DateTime(nullable: false),
                        FechaCaducidad = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.NumeroLicencia, t.Pais });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "SiguienteCurso_CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Matriculas", "AnteriorCurso_CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Matriculas", "AlumnoId", "dbo.Alumnos");
            DropIndex("dbo.Cursoes", new[] { "Creditos" });
            DropIndex("dbo.Matriculas", new[] { "SiguienteCurso_CursoId" });
            DropIndex("dbo.Matriculas", new[] { "AnteriorCurso_CursoId" });
            DropIndex("dbo.Matriculas", new[] { "AlumnoId" });
            DropIndex("dbo.Matriculas", new[] { "CursoId" });
            DropTable("dbo.LicenciaConducirs");
            DropTable("dbo.Clientes");
            DropTable("dbo.Cursoes");
            DropTable("dbo.Matriculas");
            DropTable("dbo.Alumnos");
        }
    }
}
