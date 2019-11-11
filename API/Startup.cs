using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Web.Http;
using IoC.Unity;
using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using Microsoft.Owin.Cors;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            // Swagger
            SwaggerConfig.Register(config);

            // Configure Dependency Injection
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);
            config.DependencyResolver = new UnityResolver(container);

            ConfigureWebApi(config);
            //ConfigureOAuth(app, container);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            // Remove o XML
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            //Compacta retorno de cada requisição realizada para api
            config.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));

            // Modifica a identação
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Modifica a serialização
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            Register(config);
        }

        public static void Register(HttpConfiguration config)
        {
            //add Uow action filter globally
            //config.Filters.Add(new UnitOfWorkActionFilter());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}