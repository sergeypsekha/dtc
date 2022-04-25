using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

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
            throw new NotImplementedException();
        }
    }
}
