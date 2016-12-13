using System;
using Microsoft.Owin.Hosting;

namespace Owin.Server
{
    public class Server : IDisposable
    {
        private IDisposable _server;
        private readonly string _url;

        public Server(string url)
        {
            _url = url;
        }

        public void Start()
        {
            var startOptions = new StartOptions();

            startOptions.Urls.Add(_url);
            _server = WebApp.Start<Startup>(startOptions);
        }

        public void Stop()
        {
            _server.Dispose();
        }

        public void Dispose()
        {
            if (_server != null)
            {
                _server.Dispose();
            }
        }
    }
}