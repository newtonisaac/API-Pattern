using System.Data.Entity.ModelConfiguration;

namespace Infra.Persistencia.Map
{
    public class MapCurso : EntityTypeConfiguration<Dominio.Entidades.Produto>
    {
        public MapCurso()
        {
            ToTable("Produto");

            Property(p => p.Id).HasColumnName("ProdutoId");
            Property(p => p.Nome).HasColumnName("Nome").IsRequired();
            Property(p => p.CategoriaId).HasColumnAnnotation("ForeignKey", "Categoria").IsRequired();
        }
    }
}