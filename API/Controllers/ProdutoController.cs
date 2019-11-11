using Dominio.Argumentos.Base;
using Dominio.Argumentos.Produto;
using Dominio.Interfaces.Servicos;
using Infra.Transacao;
using System;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/colegio")]
    public class ColegioController : ControllerBase<ProdutoRequest, ResponseBase>
    {
        private readonly IServicoProduto _servico;

        public ColegioController(IUnitOfWork unitOfWork, IServicoProduto servico)
            : base(unitOfWork)
        {
            _servico = servico;
        }

        [HttpPost, Route("adicionar")]
        public HttpResponseMessage Adicionar(ProdutoRequest request)
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
        public HttpResponseMessage Atualizar(ProdutoRequest request)
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