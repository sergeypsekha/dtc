using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using PactNet;
using PactNet.Infrastructure.Outputters;
using PactNet.Verifier;
using System.IO;

namespace dtc.api.tests
{
    public class EventApiTests : IClassFixture<EventApiFixture>
    {
        private EventApiFixture fixture;
        private ITestOutputHelper output;

        public EventApiTests(EventApiFixture fixture, ITestOutputHelper output)
        {
            this.fixture = fixture;
            this.output = output;
        }

        [Fact]
        public void EnsureEventApiHonoursPactWithConsumer()
        {
            var config = new PactVerifierConfig
            {
                LogLevel = PactLogLevel.Information,
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(this.output)
                }
            };

            string pactPath = Path.Combine(
                "..",
                "..",
                "..",
                "..",
                "Consumer.Tests",
                "pacts",
                "Event API Consumer-Event API.json");

            IPactVerifier verifier = new PactVerifier(config);
            verifier
                .ServiceProvider("Event API", this.fixture.ServerUri)
                .WithFileSource(new FileInfo(pactPath))
                .WithProviderStateUrl(new Uri(this.fixture.ServerUri, "/provider-states"))
                .WithRequestTimeout(TimeSpan.FromSeconds(2))
                .WithSslVerificationDisabled()
                .Verify();
        }
    }
}
