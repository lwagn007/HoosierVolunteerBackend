using HoosierVolunteer.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoosierVolunteer.Contracts
{
    public interface IEventService
    {
        bool CreateEvent(EventCreate model);
        IEnumerable<EventListItem> GetEvents();
        EventDetail GetEventById(int eventId);
        bool UpdateEvent(EventEdit model);
        bool DeleteEvent(int eventId);
    }
}
