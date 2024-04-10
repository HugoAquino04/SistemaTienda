namespace SistemaTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrelacionPedDetallePedidoProducto : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PedidoDetalle", "PedidoId");
            CreateIndex("dbo.PedidoDetalle", "ProductoId");
            AddForeignKey("dbo.PedidoDetalle", "PedidoId", "dbo.Pedido", "PedidoId");
            AddForeignKey("dbo.PedidoDetalle", "ProductoId", "dbo.Producto", "ProductoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoDetalle", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.PedidoDetalle", "PedidoId", "dbo.Pedido");
            DropIndex("dbo.PedidoDetalle", new[] { "ProductoId" });
            DropIndex("dbo.PedidoDetalle", new[] { "PedidoId" });
        }
    }
}
