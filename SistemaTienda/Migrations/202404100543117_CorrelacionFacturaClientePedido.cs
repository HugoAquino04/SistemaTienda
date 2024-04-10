namespace SistemaTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrelacionFacturaClientePedido : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Factura", "ClienteId");
            CreateIndex("dbo.Factura", "PedidoId");
            AddForeignKey("dbo.Factura", "ClienteId", "dbo.Cliente", "ClienteId");
            AddForeignKey("dbo.Factura", "PedidoId", "dbo.Pedido", "PedidoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factura", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.Factura", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Factura", new[] { "PedidoId" });
            DropIndex("dbo.Factura", new[] { "ClienteId" });
        }
    }
}
