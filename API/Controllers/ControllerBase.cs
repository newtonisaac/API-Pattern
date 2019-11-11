using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio.Interfaces.Servicos.Base;
using Infra.Transacao;

namespace API.Controllers
{
    public class ControllerBase<TRequest, TResponse> : ApiController
        where TRequest : class
        where TResponse : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private IServicoBase<TRequest, TResponse> _serviceBase;

        protected ControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public HttpResponseMessage Response(object result, IServicoBase<TRequest, TResponse> serviceBase)
        {
            _serviceBase = serviceBase;

            if (serviceBase.Notifications.Any())
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = serviceBase.Notifications });
            }

            try
            {
                _unitOfWork.Commit();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        public HttpResponseMessage ResponseException(Exception ex)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { errors = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            _serviceBase?.Dispose();
            base.Dispose(disposing);
        }
    }
}