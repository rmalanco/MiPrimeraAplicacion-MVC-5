namespace MiPrimeraAplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "UserName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Usuarios", "Password", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Password", c => c.String());
            AlterColumn("dbo.Usuarios", "UserName", c => c.String());
        }
    }
}
