using Dominio.Argumentos.Base;
using Dominio.Argumentos.Categoria;
using Dominio.Interfaces.Servicos;
using Infra.Transacao;
using System;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/aluno")]
    public class AlunoController : ControllerBase<CategoriaRequest, ResponseBase>
    {
        private readonly IServicoCategoria _servico;

        public AlunoController(IUnitOfWork unitOfWork, IServicoCategoria servico)
            : base(unitOfWork)
        {
            _servico = servico;
        }

        [HttpPost, Route("adicionar")]
        public HttpResponseMessage Adicionar(CategoriaRequest request)
        {
            try
            {
                var response = _servico.Adicionar(request);
                return Response(response, _servico);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpPut, Route("atualizar")]
        public HttpResponseMessage Atualizar(CategoriaRequest request)
        {
            try
            {
                var response = _servico.Atualizar(request);
                return Response(response, _servico);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet, Route("listar")]
        public HttpResponseMessage Listar()
        {
            try
            {
                var response = _servico.Listar();
                return Response(response, _servico);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }
    }
}