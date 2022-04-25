using System.Collections.Generic;

namespace dtc.api.tests
{
    public class ProviderState
    {
        public string State { get; set; }

        public IDictionary<string, string>  Params { get; set; }
    }
}