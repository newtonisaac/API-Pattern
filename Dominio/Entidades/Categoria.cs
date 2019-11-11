using Dominio.Entidades.Base;
using Dominio.Recursos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace Dominio.Entidades
{
    public class Categoria : EntidadeBase
    {
        public Categoria()
        {

        }

        public Categoria(string nome)
        {
            Nome = nome;
       
            new AddNotifications<Categoria>(this).IfNullOrWhiteSpace(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
        }

        public void Atualizar(string nome)
        {
            Nome = nome;
   
            new AddNotifications<Categoria>(this).IfNullOrWhiteSpace(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
        }

        public string Nome { get; private set; }
    }
}
