using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infra.Persistencia.Repositorio.Base;

namespace Infra.Persistencia.Repositorio
{
    public class RepositorioProduto : RepositorioBase<Produto, int>, IRepositorioProduto
    {
        protected readonly CatalogoContexto _context;

        public RepositorioProduto(CatalogoContexto context)
            : base(context)
        {
            _context = context;
        }
    }
}
