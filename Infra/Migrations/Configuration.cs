namespace Infra.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infra.Persistencia.CatalogoContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Infra.Persistencia.CatalogoContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Categoria.AddOrUpdate(new Dominio.Entidades.Categoria("Categoria1"));
            context.Categoria.AddOrUpdate(new Dominio.Entidades.Categoria("Categoria2"));
            
            context.Produto.AddOrUpdate(new Dominio.Entidades.Produto("Categoria1", new Dominio.Entidades.Categoria("CategoriaProduto")));

            context.SaveChanges();

        }
    }
}
