using System;

namespace dtc.api.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        public DateTime TimeStamp { get; set; }

        public string EventType { get; set; }
    }
}
