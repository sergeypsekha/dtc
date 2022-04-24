using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace dtc.api.tests
{
    public class EventApiFixture : IDisposable
    {
        private readonly IHost server;

        public Uri ServerUri { get; }

        public EventApiFixture()
        {
            this.ServerUri = new Uri("http://localhost:9222");
            this.server = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls(this.ServerUri.ToString());
                    webBuilder.UseStartup<TestStartup>();
                })
                .Build();

            this.server.Start();
        }

        public void Dispose()
        {
            this.server.Dispose();
        }
    }
}
