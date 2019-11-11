namespace Dominio.Argumentos.Base
{
    public class ResponseBase
    {
        public ResponseBase(string mensagem)
        {
            Mensagem = mensagem;
        }

        public ResponseBase(string mensagem, int id)
        {
            Id = id;
            Mensagem = mensagem;
        }

        public int Id { get; set; }
        public string Mensagem { get; set; }
    }
}
