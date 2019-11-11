namespace Infra.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataInclusao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        CategoriaId = c.Int(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ForeignKey",
                                    new AnnotationValues(oldValue: null, newValue: "Categoria")
                                },
                            }),
                        DataInclusao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "CategoriaId" });
            DropTable("dbo.Produto",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CategoriaId",
                        new Dictionary<string, object>
                        {
                            { "ForeignKey", "Categoria" },
                        }
                    },
                });
            DropTable("dbo.Categoria");
        }
    }
}
