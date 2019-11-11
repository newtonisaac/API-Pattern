using Dominio.Argumentos.Base;
using Dominio.Argumentos.Categoria;
using Dominio.Interfaces.Servicos.Base;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos
{
    public interface IServicoCategoria : IServicoBase<CategoriaRequest, ResponseBase>
    {
        IEnumerable<CategoriaResponse> Listar();
    }
}
