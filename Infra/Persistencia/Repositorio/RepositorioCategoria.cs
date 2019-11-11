using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infra.Persistencia.Repositorio.Base;

namespace Infra.Persistencia.Repositorio
{
    public class RepositorioCategoria : RepositorioBase<Categoria, int>, IRepositorioCategoria
    {
        protected readonly CatalogoContexto _context;

        public RepositorioCategoria(CatalogoContexto context)
            : base(context)
        {
            _context = context;
        }
    }
}
