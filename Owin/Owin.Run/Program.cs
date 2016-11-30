using Owin.Server;

namespace Owin.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = new Owin.Server.Server(ConfigurationManager.Url))
            {
                server.Start();
                System.Console.WriteLine("Application is started...");
                System.Console.WriteLine("Url: {0}", ConfigurationManager.Url);
                System.Console.WriteLine("Press a key to stop..");
                System.Console.ReadKey();
            }
        }
    }
}
