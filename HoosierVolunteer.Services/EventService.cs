using HoosierVolunteer.Contracts;
using HoosierVolunteer.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoosierVolunteer.Services
{
    public class EventService : IEventService
    {
        public bool CreateEvent(EventCreate model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEquipment(int equipmentId)
        {
            throw new NotImplementedException();
        }

        public EventDetail GetEventById(int eventId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventListItem> GetEvents()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEquipment(EventEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
