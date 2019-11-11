using Dominio.Argumentos.Base;
using Dominio.Argumentos.Produto;
using Dominio.Entidades;
using Dominio.Extensoes;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Recursos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Servicos
{
    public class ServicoProduto : Notifiable, IServicoProduto
    {
        private readonly IRepositorioProduto _repositorioProduto;

        public ServicoProduto(IRepositorioProduto repositorioColegio)
        {
            _repositorioProduto = repositorioColegio;
        }

        public ResponseBase Adicionar(ProdutoRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = new Produto(request.Nome, request.CategoriaId);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioProduto.Adicionar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public ResponseBase Atualizar(ProdutoRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = _repositorioProduto.ObterPorId(request.Id);
            entidade.Atualizar(request.Nome, request.CategoriaId);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioProduto.Editar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public IEnumerable<ProdutoResponse> Listar()
        {
            return _repositorioProduto.Listar().ToList().ToMap<Produto, ProdutoResponse>();
        }
    }
}
