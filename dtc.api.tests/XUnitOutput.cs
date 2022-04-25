using PactNet.Infrastructure.Outputters;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace dtc.api.tests
{
    public class XUnitOutput : IOutput
    {
        private ITestOutputHelper output;

        public XUnitOutput(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string line)
        {
            this.output.WriteLine(line);
        }
    }
}