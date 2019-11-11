using prmToolkit.NotificationPattern;

namespace Dominio.Interfaces.Servicos.Base
{
    public interface IServicoBase<in TRequest, out TResponse> : INotifiable
        where TRequest : class
        where TResponse : class
    {
        TResponse Adicionar(TRequest request);
        TResponse Atualizar(TRequest request);
    }
}
