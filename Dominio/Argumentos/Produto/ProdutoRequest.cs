using Dominio.Argumentos.Base;

namespace Dominio.Argumentos.Produto
{
    public class ProdutoRequest : ArgumentoBase
    {
        public string Nome { get;  set; }
        public int CategoriaId { get; set; }
    }
}
