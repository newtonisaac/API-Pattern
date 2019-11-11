using Dominio.Argumentos.Base;
using Dominio.Argumentos.Categoria;
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
    public class ServicoCategoria : Notifiable, IServicoCategoria
    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public ServicoCategoria(IRepositorioCategoria repositorioAluno)
        {
            _repositorioCategoria = repositorioAluno;
        }

        public ResponseBase Adicionar(CategoriaRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = new Categoria(request.Nome);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioCategoria.Adicionar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public ResponseBase Atualizar(CategoriaRequest request)
        {
            if (request == null)
            {
                AddNotification("request", Mensagem.X0_E_OBRIGATORIO.ToFormat("request"));
                return null;
            }

            var entidade = _repositorioCategoria.ObterPorId(request.Id);
            entidade.Atualizar(request.Nome);
            AddNotifications(entidade);

            if (IsInvalid()) return null;

            _repositorioCategoria.Editar(entidade);

            return new ResponseBase(Mensagem.OPERACAO_REALIZADA_COM_SUCESSO);
        }

        public IEnumerable<CategoriaResponse> Listar()
        {
            return _repositorioCategoria.Listar().ToList().ToMap<Categoria, CategoriaResponse>();
        }
    }
}
