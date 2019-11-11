using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dominio.Interfaces.Repositorios.Base
{
    public interface IRepositorioBase<TEntidade, in TId>
        where TEntidade : class
        where TId : struct
    {
        bool Existe(Func<TEntidade, bool> where);

        IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);


        bool Existe(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade Adicionar(TEntidade entidade);

        TEntidade Editar(TEntidade entidade);
    }
}
