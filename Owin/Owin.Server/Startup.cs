using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin.Authentication.Middlewares;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Owin.Server.Startup))]

namespace Owin.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<VelocidiAuthenticationMiddleware>();

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultJsonApi",
                routeTemplate: "api/v1.1/{controller}.json/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1.1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            app.UseWebApi(config);

            app.Map("", spa =>
            {
                spa.Use((context, next) =>
                {
                    if (context.Request.Path.ToUriComponent().Contains(".js")) { return next(); }
                    if (context.Request.Path.ToUriComponent().Contains(@"/img/")) { return next(); }
                    if (context.Request.Path.ToUriComponent().Contains(@"/fonts/")) { return next(); }
                    if (context.Request.Path.ToUriComponent().Contains(@"/css/")) { return next(); }
                    if (context.Request.Path.ToUriComponent().Contains(@"/files/")) { return next(); }

                    context.Request.Path = new PathString("/");

                    return next();
                });

                var physicalFileSystem = new PhysicalFileSystem(ConfigurationManager.AppSettings["ClientFolder"]);
                var options = new FileServerOptions
                {
                    EnableDefaultFiles = true,
                    FileSystem = physicalFileSystem
                };
                options.StaticFileOptions.FileSystem = physicalFileSystem;
                options.StaticFileOptions.ServeUnknownFileTypes = true;
                options.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" };
                spa.UseFileServer(options);
            });
        }
    }
}
