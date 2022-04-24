using dtc.api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dtc.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
       public IActionResult Get([FromQuery] string type)
        {
            IEnumerable<Event> events = this.GetAllEventsFromRepo();
            if(!string.IsNullOrEmpty(type))
            {
                events = events.Where(e => e.EventType.Equals(type, StringComparison.InvariantCultureIgnoreCase));
            }

            return this.Ok(events);
       }

        private IEnumerable<Event> GetAllEventsFromRepo()
        {
            return new List<Event> 
            {
                new Event()
                {
                    EventId = Guid.Parse("fb1087d6-437a-4163-a226-9368f32a0cf3"),
                    TimeStamp = DateTime.Parse("2022-04-24T00:00:00.00000000"),
                    EventType = "SearchView"
                },
                new Event()
                {
                    EventId = Guid.Parse("60f06190-198b-4e49-b415-e21be2344895"),
                    TimeStamp = DateTime.Parse("2022-04-23T00:00:00.00000000"),
                    EventType = "DetailsView"
                },
                new Event()
                {
                    EventId = Guid.Parse("80e1a755-5b05-4edc-855b-27188638225d"),
                    TimeStamp = DateTime.Parse("2022-04-22T00:00:00.00000000"),
                    EventType = "SearchView"
                }
            };
        }
    }
}
