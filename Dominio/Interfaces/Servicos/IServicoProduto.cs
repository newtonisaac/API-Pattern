using Dominio.Argumentos.Base;
using Dominio.Argumentos.Produto;
using Dominio.Interfaces.Servicos.Base;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos
{
    public interface IServicoProduto : IServicoBase<ProdutoRequest, ResponseBase>
    {
        IEnumerable<ProdutoResponse> Listar();
    }
}

