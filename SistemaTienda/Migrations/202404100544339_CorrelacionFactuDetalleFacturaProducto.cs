namespace SistemaTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrelacionFactuDetalleFacturaProducto : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.FacturaDetalle", "FacturaId");
            CreateIndex("dbo.FacturaDetalle", "ProductoId");
            AddForeignKey("dbo.FacturaDetalle", "FacturaId", "dbo.Factura", "FacturaId");
            AddForeignKey("dbo.FacturaDetalle", "ProductoId", "dbo.Producto", "ProductoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaDetalle", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.FacturaDetalle", "FacturaId", "dbo.Factura");
            DropIndex("dbo.FacturaDetalle", new[] { "ProductoId" });
            DropIndex("dbo.FacturaDetalle", new[] { "FacturaId" });
        }
    }
}
