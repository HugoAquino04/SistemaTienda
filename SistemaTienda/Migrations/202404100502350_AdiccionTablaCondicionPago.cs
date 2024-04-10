namespace SistemaTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdiccionTablaCondicionPago : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CondicionPago",
                c => new
                    {
                        CondicionPagoId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 50),
                        Descripcion = c.String(maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                        Dias = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CondicionPagoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CondicionPago");
        }
    }
}
