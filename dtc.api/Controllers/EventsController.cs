using dtc.api.Models;
using Microsoft.AspNetCore.Http;
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
            throw new NotImplementedException();
        }
    }
}
