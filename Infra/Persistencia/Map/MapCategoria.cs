using System.Data.Entity.ModelConfiguration;

namespace Infra.Persistencia.Map
{
    public class MapCategoria : EntityTypeConfiguration<Dominio.Entidades.Categoria>
    {
        public MapCategoria()
        {
            ToTable("Categoria");

            Property(p => p.Id).HasColumnName("CategoriaId");
            Property(p => p.Nome).HasColumnName("Nome").IsRequired();
        }
    }
}