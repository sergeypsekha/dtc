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

            const string serviceUri = "http://localhost:9222";

            var config = new PactVerifierConfig
            {
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(this.output)
                }
            };


        }
    }
}
