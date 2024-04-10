namespace SistemaTienda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrelacionProductoCategoriaUnidadMedia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producto", "Categorias_CategoriasId", c => c.Int());
            AddColumn("dbo.Producto", "UnidadMedida_UnidadMediaId", c => c.Int());
            CreateIndex("dbo.Producto", "Categorias_CategoriasId");
            CreateIndex("dbo.Producto", "UnidadMedida_UnidadMediaId");
            AddForeignKey("dbo.Producto", "Categorias_CategoriasId", "dbo.Categorias", "CategoriasId");
            AddForeignKey("dbo.Producto", "UnidadMedida_UnidadMediaId", "dbo.UnidadMedida", "UnidadMediaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producto", "UnidadMedida_UnidadMediaId", "dbo.UnidadMedida");
            DropForeignKey("dbo.Producto", "Categorias_CategoriasId", "dbo.Categorias");
            DropIndex("dbo.Producto", new[] { "UnidadMedida_UnidadMediaId" });
            DropIndex("dbo.Producto", new[] { "Categorias_CategoriasId" });
            DropColumn("dbo.Producto", "UnidadMedida_UnidadMediaId");
            DropColumn("dbo.Producto", "Categorias_CategoriasId");
        }
    }
}
