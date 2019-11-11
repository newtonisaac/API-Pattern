using System;
using prmToolkit.NotificationPattern;

namespace Dominio.Entidades.Base
{
    public abstract class EntidadeBase : Notifiable
    {
        protected EntidadeBase()
        {
            DataInclusao = DateTime.Now;
            Ativo = true;
        }

        public int Id { get; set; }
        public DateTime DataInclusao { get; private set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
