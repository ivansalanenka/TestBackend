using Owin.Server;
using System.Configuration;

namespace Owin.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = new Owin.Server.Server(ConfigurationManager.AppSettings["Url"]))
            {
                server.Start();
                System.Console.WriteLine("Application is started...");
                System.Console.WriteLine("Url: {0}", ConfigurationManager.AppSettings["Url"]);
                System.Console.WriteLine("Press a key to stop..");
                System.Console.ReadKey();
            }
        }
    }
}
