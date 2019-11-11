using AutoMapper;
using Dominio.Argumentos.Categoria;
using Dominio.Argumentos.Produto;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Repositorios.Base;
using Dominio.Interfaces.Servicos;
using Dominio.Interfaces.Servicos.Base;
using Dominio.Servicos;
using Infra.Persistencia;
using Infra.Persistencia.Repositorio;
using Infra.Transacao;
using Microsoft.Practices.Unity;
using prmToolkit.NotificationPattern;
using System.Data.Entity;

namespace IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, CatalogoContexto>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            container.RegisterType(typeof(IServicoBase<,>), typeof(IServicoBase<,>));
            container.RegisterType<IServicoCategoria, ServicoCategoria>(new HierarchicalLifetimeManager());
            container.RegisterType<IServicoProduto, ServicoProduto>(new HierarchicalLifetimeManager());
            
            //Repositorio
            container.RegisterType(typeof(IRepositorioBase<,>), typeof(IRepositorioBase<,>));
            container.RegisterType<IRepositorioCategoria, RepositorioCategoria>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositorioProduto, RepositorioProduto>(new HierarchicalLifetimeManager());
            
            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Categoria, CategoriaResponse>();
                    cfg.CreateMap<Produto, ProdutoResponse>();
                });
        }
    }
}
