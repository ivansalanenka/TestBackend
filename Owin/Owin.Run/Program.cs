using Owin.Server;
using Topshelf;

namespace Owin.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<Owin.Server.Server>(s =>
                {
                    s.ConstructUsing(name => new Owin.Server.Server(ConfigurationManager.Url));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
    
                x.SetDisplayName("MoboTest");
                x.SetServiceName("MoboTest");
            });
        }
    }
}
