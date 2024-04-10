namespace SistemaTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdiccionTablaCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 15),
                        Nombre = c.String(maxLength: 50),
                        Apellidos = c.String(maxLength: 50),
                        GrupoDescuentoId = c.Int(nullable: false),
                        CondicionPagoId = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
