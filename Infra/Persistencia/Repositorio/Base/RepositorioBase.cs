using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Dominio.Entidades.Base;
using Dominio.Interfaces.Repositorios.Base;

namespace Infra.Persistencia.Repositorio.Base
{
    public class RepositorioBase<TEntidade, TId> : IRepositorioBase<TEntidade, TId>
        where TEntidade : EntidadeBase
        where TId : struct
    {
        private readonly DbContext _context;

        public RepositorioBase(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties) => Listar(includeProperties).Where(where);

        public TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties) => includeProperties.Any() ? Listar(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString()) : _context.Set<TEntidade>().Find(id);

        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties) => includeProperties.Any() ? Include(_context.Set<TEntidade>(), includeProperties) : _context.Set<TEntidade>();


        public TEntidade Adicionar(TEntidade entidade)
        {
            _context.Set<TEntidade>().Add(entidade);
            return entidade;
        }

        public TEntidade Editar(TEntidade entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            return entidade;
        }

        public bool Existe(Func<TEntidade, bool> where) => _context.Set<TEntidade>().Where(x => x.Ativo == true).Any(where);

        public bool Existe(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties) => Listar(includeProperties).Where(x => x.Ativo == true).Any(where);

        private static IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties) => includeProperties.Aggregate(query, (current, property) => current.Include(property));
    }
}
