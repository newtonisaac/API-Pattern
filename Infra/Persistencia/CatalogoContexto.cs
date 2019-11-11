using Dominio.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infra.Persistencia
{
    public class CatalogoContexto : DbContext
    {
        public CatalogoContexto()
            : base("Catalogo")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove a pluralização dos nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Remove exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Setar para usar varchar ou invés de nvarchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Caso eu esqueça de informar o tamanho do campo ele irá colocar varchar de 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //Mapeia as entidades
            //modelBuilder.Configurations.Add(new MapExemplo());

            #region Adiciona entidades mapeadas - Automaticamente via Assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(CatalogoContexto).Assembly);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}