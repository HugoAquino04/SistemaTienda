namespace SistemaTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdiccionTablaUnidadMedida : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnidadMedida",
                c => new
                    {
                        UnidadMediaId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 50),
                        Descripcion = c.String(maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UnidadMediaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UnidadMedida");
        }
    }
}
