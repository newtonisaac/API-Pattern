using Infra.Persistencia;

namespace Infra.Transacao
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogoContexto _context;

        public UnitOfWork(CatalogoContexto context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
