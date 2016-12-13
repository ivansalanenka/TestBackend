using Owin.Server;
using System.Configuration;
using Topshelf;

namespace Owin.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<Owin.Server.Server>(server =>
                {
                    server.ConstructUsing(name => new Owin.Server.Server(ConfigurationManager.AppSettings["Url"]));
                    server.WhenStarted(tc => tc.Start());
                    server.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalService();

                x.SetDisplayName(ConfigurationManager.AppSettings["ServiceName"]);
                x.SetServiceName(ConfigurationManager.AppSettings["ServiceDisplayName"]);
            });
        }
    }
}
