using Dominio.Entidades.Base;
using Dominio.Recursos;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public Produto()
        {

        }

        public Produto(string nome, Categoria categoria)
        {
            Nome = nome;
            Categoria = categoria;

            new AddNotifications<Produto>(this).IfNull(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
            new AddNotifications<Produto>(this).IfNull(x => x.Categoria, Mensagem.X0_NAO_INFORMADO.ToFormat("Categoria"));

        }



        public Produto(string nome, int categoriaId)
        {
            Nome = nome;
            CategoriaId = categoriaId;

            new AddNotifications<Produto>(this).IfNull(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
            new AddNotifications<Produto>(this).IfNull(x => x.CategoriaId, Mensagem.X0_NAO_INFORMADO.ToFormat("Categoria"));
        }

        internal void Atualizar(string nome, int categoriaId)
        {
            Nome = nome;
            CategoriaId = categoriaId;
            
            new AddNotifications<Produto>(this).IfNull(x => x.Nome, Mensagem.X0_NAO_INFORMADO.ToFormat("Nome"));
            new AddNotifications<Produto>(this).IfNull(x => x.CategoriaId, Mensagem.X0_NAO_INFORMADO.ToFormat("Categoria"));
        }
    }
}
